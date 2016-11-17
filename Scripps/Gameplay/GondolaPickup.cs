using UnityEngine;
using System.Collections;

public class GondolaPickup : MonoBehaviour
{
    //are we carrying anything?
    public bool carrying = false;
    //the gondola to be carried
    public GameObject targetGondola;
    //height at which the gondola should hover
    public float hoverHeight = 3;
    //
    public bool delet = false;
    //reference to the trashcan
    public GameObject trashcan;
    //reference to the hand
    public GameObject zaHando;
    //animator hashes for the hand's animations WHY THE HAND IS CONTROLLED BY THIS SCRIPT PLEASE DO NOT ASK i added the hand as an ebin crank and didn't expect it to become such a nice feature, i should upgrade this sometime
    public int pickupHash = Animator.StringToHash("Pickup");
    public int createHash = Animator.StringToHash("CreateGondola");
    //raycasthit that would not work if i called it rayData so i called it rayData2
    private RaycastHit rayData2;
    //sound played when you drop a gondola into lava
    public AudioClip lavadrop;
    //the particle effect that appears
    public GameObject lavaeffec;
    //the spooky gondola prefab to be created
    public GameObject spookGond;
    //spooky particle effect
    public GameObject spookeffec;

    void Start()
    {
        //gets reference to the trashcan
        trashcan = GameObject.FindWithTag("TrashCan");
        //zaHando = GameObject.FindWithTag("ZaHando");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && carrying == false)
        {
            Pickup();
        }
        //if we press right mouse button and are carrying a gondola;
        else if (Input.GetButtonDown("Fire2") && carrying == true)
        {
            //if hovering over the trash can...
            if (delet == true)
            {
                //remove the gondola from the list and destroy it
                GameObject.FindGameObjectWithTag("Rules").GetComponent<GameRules>().gondolas.Remove(targetGondola.gameObject);
                Destroy(targetGondola.gameObject);
                //play the trashcan animation and sound
                trashcan.GetComponent<TrashCan>().anim.SetBool(trashcan.GetComponent<TrashCan>().openHash, false);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(trashcan.GetComponent<TrashCan>().recycleSound);
                //unsets the hand's pickup animation
                zaHando.GetComponent<Animator>().SetBool(pickupHash, false);
            }
            //if we detect we are hovering over lava...
            else if (Physics.Raycast(new Ray(targetGondola.transform.position, Vector3.down), out rayData2))
            {
                if (rayData2.collider.tag == "Lava")
                {
                    float x;
                    float y;
                    //pick a random spot on the terrain
                    x = Random.Range(-100, 100);
                    y = Random.Range(-100, 100);
                    //remove the gondola that was slam dunked into the lava
                    GameObject.FindGameObjectWithTag("Rules").GetComponent<GameRules>().gondolas.Remove(targetGondola.gameObject);
                    Destroy(targetGondola.gameObject);
                    //instantiate the lava dunk particles, spooky gondola and the spooky effect
                    Instantiate(lavaeffec, rayData2.point, Quaternion.Euler(-90,0,0));
                    Instantiate(spookGond, new Vector3(x, 0, y), Quaternion.identity);
                    Instantiate(spookeffec, new Vector3(x, 0, y), Quaternion.Euler(-90, 0, 0));
                    //plays the lava dunk sound 3 times because it was too soft and i was too lazy to louden it manually
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(lavadrop);
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(lavadrop);
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(lavadrop);
                    zaHando.GetComponent<Animator>().SetBool(pickupHash, false);
                }
                //if we are hovering over the train...
                else if (rayData2.collider.tag == "Train")
                {
                    carrying = false;
                    //targetGondola.GetComponent<CapsuleCollider>().enabled = false;
                    //disable all gondola AI and animations
                    targetGondola.GetComponent<NavMeshAgent>().enabled = false;
                    targetGondola.GetComponent<Animator>().SetBool(targetGondola.GetComponent<GondolaAI>().heldHash, false);
                    targetGondola.GetComponent<Animator>().SetBool(targetGondola.GetComponent<GondolaAI>().walkHash, false);
                    targetGondola.GetComponent<GondolaAI>().enabled = false;
                    targetGondola.GetComponent<Animator>().Play("Idle");
                    targetGondola.transform.parent = rayData2.collider.transform;
                    targetGondola.transform.position = rayData2.point;
                    zaHando.GetComponent<Animator>().SetBool(pickupHash, false);
                }
                //and if instead we hover over regular ground...
                else
                {
                    //release the gondola and re-enable all AI
                    targetGondola.GetComponent<GondolaAI>().currentState = targetGondola.GetComponent<GondolaAI>().gondoIdle;
                    targetGondola.GetComponent<Animator>().SetBool(targetGondola.GetComponent<GondolaAI>().walkHash, false);
                    targetGondola.GetComponent<CapsuleCollider>().enabled = true;
                    targetGondola.GetComponent<NavMeshAgent>().enabled = true;
                    targetGondola.GetComponent<GondolaAI>().anim.SetBool(targetGondola.GetComponent<GondolaAI>().heldHash, false);
                    zaHando.GetComponent<Animator>().SetBool(pickupHash, false);
                }
            }
            //if hover over ground
            else
            {
                //release the gondola and re-enable all AI
                targetGondola.GetComponent<GondolaAI>().currentState = targetGondola.GetComponent<GondolaAI>().gondoIdle;
                targetGondola.GetComponent<Animator>().SetBool(targetGondola.GetComponent<GondolaAI>().walkHash, false);
                targetGondola.GetComponent<CapsuleCollider>().enabled = true;
                targetGondola.GetComponent<NavMeshAgent>().enabled = true;
                targetGondola.GetComponent<GondolaAI>().anim.SetBool(targetGondola.GetComponent<GondolaAI>().heldHash, false);
                zaHando.GetComponent<Animator>().SetBool(pickupHash, false);
            }
            //and of course set the carrying bool to false
            carrying = false;
        }

        //while the carrying bool is true, run this function
        if (carrying == true)
        {
            Carry(targetGondola);
        }

        //this puts the hand wherever you are pointing
        RaycastHit rayData;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rayData))
        {
            zaHando.transform.position = rayData.point + new Vector3(0, hoverHeight, 0);
        }
    }

    //obvious name is obvious
    void Pickup()
    {
        RaycastHit rayData;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rayData))
        {
            if (rayData.collider.tag == "Gondola")
            {
                carrying = true;
                targetGondola = rayData.transform.gameObject;
                targetGondola.GetComponent<CapsuleCollider>().enabled = false;
                targetGondola.GetComponent<NavMeshAgent>().enabled = false;
                targetGondola.GetComponent<GondolaAI>().anim.SetBool(targetGondola.GetComponent<GondolaAI>().heldHash, true);
                zaHando.GetComponent<Animator>().SetBool(pickupHash, true);
                targetGondola.GetComponent<GondolaAI>().currentState = targetGondola.GetComponent<GondolaAI>().gondoHeld;
            }
        }
        //now this is interesting, this marker component i used to mark the space gondolas with in the UFO, so the game would know which space gondolas were picked up and which ones would return to space; if you pick up a gondola with this marker, the marker will be delet
        if (targetGondola.GetComponent<Marker>())
        {
            Destroy(targetGondola.GetComponent<Marker>());
        }
    }

    //duh
    void Carry(GameObject toCarry)
    {
        RaycastHit rayData;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rayData))
        {
            toCarry.transform.position = rayData.point + new Vector3(0, hoverHeight, 0);

            //while carrying and hovering over the trashcan
            if (rayData.collider.tag == "TrashCan")
            {
                //play these animations and set the delet bool to true
                trashcan.GetComponent<TrashCan>().anim.SetBool(trashcan.GetComponent<TrashCan>().openHash, true);
                toCarry.GetComponent<GondolaAI>().anim.SetBool(toCarry.GetComponent<GondolaAI>().panicHash, true);
                delet = true;
            }
            //the opposite 
            else
            {
                trashcan.GetComponent<TrashCan>().anim.SetBool(trashcan.GetComponent<TrashCan>().openHash, false);
                toCarry.GetComponent<GondolaAI>().anim.SetBool(toCarry.GetComponent<GondolaAI>().panicHash, false);
                delet = false;
            }
        }
    }
}
