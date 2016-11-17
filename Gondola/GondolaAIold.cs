using UnityEngine;
using System.Collections;

//THIS IS THE OLD GONDOLA AI, it worked pretty well but got bloated, so i tried a state machine instead

public class GondolaAIold : MonoBehaviour
{
    //width of the terrain when i started the game, can you believe this?
    public int terrainWidth = 50;
    public int terrainHeight = 50;
    public Animator anim;
    [HideInInspector] public int walkHash;
    [HideInInspector] public int heldHash;
    [HideInInspector] public int panicHash;
    [HideInInspector] public int splashHash;
    private float idleTime = 0;
    private float randumbTime = 0.1f;
    private float lonely = 0;
    private float meetupTime = 5f;
    //public bool inWater = false;
    //public GameObject splashy;
    public Vector3 pickedPos;

    private GameObject gameRules;

    private NavMeshAgent bro;

    void Start()
    {
        gameRules = GameObject.FindGameObjectWithTag("Rules");
        gameRules.GetComponent<GameRules>().gondolas.Add(gameObject);
        bro = GetComponent<NavMeshAgent>();
        pickedPos = gameObject.transform.position;
        anim = GetComponent<Animator>();
        walkHash = Animator.StringToHash("Walking");
        heldHash = Animator.StringToHash("Held");
        panicHash = Animator.StringToHash("Panic");
        splashHash = Animator.StringToHash("Splash");
        Decide();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, pickedPos) < 4)
        {
            Decide();
        }

        if (GetComponent<NavMeshAgent>().velocity.magnitude > 0.3f)
        {
            anim.SetBool(walkHash, true);
        }
        else
        {
            anim.SetBool(walkHash, false);
        }
    }

    void Decide()
    {
        if (idleTime > randumbTime)
        {
            PickPlace();
            randumbTime = Random.Range(1, 20);
            idleTime = 0;
        }

        if (lonely > meetupTime && gameRules.GetComponent<GameRules>().gondolas.Count > 1)
        {
            FindPal();
            lonely = 0;
            meetupTime = Random.Range(1, 20);
        }
        
        lonely += Time.deltaTime / 2;
        idleTime += Time.deltaTime;
    }

    void PickPlace()
    {
        pickedPos = new Vector3(Random.Range(0 + (terrainWidth / 2), 0 - (terrainWidth / 2)), 0, Random.Range(0 + (terrainHeight / 2), 0 - (terrainHeight / 2)));
        bro.destination = pickedPos;
    }

    void FindPal()
    {
        int listlength = gameRules.GetComponent<GameRules>().gondolas.Count;
        pickedPos = gameRules.GetComponent<GameRules>().gondolas[Random.Range(0, listlength)].transform.position;
        bro.destination = pickedPos;
    }
}
