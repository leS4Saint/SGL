using UnityEngine;
using System.Collections.Generic;
using System.Collections;

//this is the governing component that controls a gondola, very imbordand

public class GondolaAI : MonoBehaviour
{
    //reference to the nav mesh agent
    public NavMeshAgent gondoAgent;

    //references to all states the gondola will have
    public Igondola currentState;
    public GondoIdle gondoIdle;
    public GondoTravel gondoTravel;
    public GondoPlay gondoPlay;
    public GondoMeetup gondoMeetup;
    public GondoHeld gondoHeld;

    //animator component
    public Animator anim;
    //timers for switching behaviours
    public float idleTime;
    public float boredom;
    public float lonely;
    //buddy for meeting up with
    public GameObject buddyGondola = null;

    //whatever the gondola is touching, like water or hot places
    public string currentTouch;

    //all effects the gondola may want to use, now its just the splashing particle effect
    public GameObject[] effects;

    //hashes for the animations, don't ask me how this works, it just does
    [HideInInspector]
    public int walkHash;
    [HideInInspector]
    public int heldHash;
    [HideInInspector]
    public int panicHash;
    [HideInInspector]
    public int splashHash;
    [HideInInspector]
    public int lieHash;
    [HideInInspector]
    public int sweatHash;

    //the position the gondola was at the last frame
    Vector3 previousPos;
    //velocity of the gondola
    float velocity = 0;

    void Awake()
    {
        //on awake get all references needed
        gondoAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        gondoIdle = new GondoIdle(this);
        gondoTravel = new GondoTravel(this);
        gondoPlay = new GondoPlay(this);
        gondoMeetup = new GondoMeetup(this);
        gondoHeld = new GondoHeld(this);

        //anim init
        walkHash = Animator.StringToHash("Walking");
        heldHash = Animator.StringToHash("Held");
        panicHash = Animator.StringToHash("Panic");
        splashHash = Animator.StringToHash("Splash");
        lieHash = Animator.StringToHash("Lie");
        sweatHash = Animator.StringToHash("Sweat");
    }

	void Start ()
    {
        //of course we are idle at start
        currentState = gondoIdle;
        //adds this gondola to the big list of gondolas
        GameObject.FindWithTag("Rules").GetComponent<GameRules>().gondolas.Add(gameObject);

        //randomizes these values for every spawned gondola
        idleTime = Random.Range(0, 4);
        boredom = Random.Range(0, 25);
        lonely = Random.Range(0, 45);
}
	
	void Update ()
    {
        //runs the current state's update function
        currentState.UpdateState();

        //calculates velocity every frame
        velocity = ((transform.position - previousPos).magnitude) / Time.deltaTime;
        previousPos = transform.position;

        //and according to velocity, sets the gondola to walking or not
        if (velocity > 1)
        {
            anim.SetBool(walkHash, true);
        }
        else
        {
            anim.SetBool(walkHash, false);
        }
    }

    //when the gondola triggers something important write down the tag
    public void OnTriggerEnter(Collider boi)
    {
        if (boi.tag == "Water")
        {
            currentTouch = boi.tag;
        }
        if (boi.tag == "Hot")
        {
            currentTouch = boi.tag;
        }
    }

    //when it stops triggering reset this string
    public void OnTriggerExit()
    {
        currentTouch = "swag";
    }

    //creates particles
    public void ParticleCreate(int amount)
    {
        GetComponentInChildren<ParticleSystem>().Emit(amount);
    }
}
