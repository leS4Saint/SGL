using UnityEngine;
using System.Collections;

public class CreateGondola : MonoBehaviour
{
    //the base gondola prefab
    public GameObject gondolaBase;
    //array of prebuilt gondolas, if you want to create one
    public GameObject[] gondolaPrebuilts;
    //duh
    public GameObject[] hats;
    //array of rare hats
    public GameObject[] rareHats;
    //regular gondola skins
    public Material[] materials;
    //rare gondola skins
    public Material[] rareMaterials;
    //wow
    public Material[] ultraRareMaterials;
    //toggles the gondola follow
    public bool toggleCamFollow = false;
    //whichever gondola is being carried
    public GameObject pickygondo;
    //the [S4S] hat
    public GameObject s4shat;
    //duh
    public AudioClip createSound;
    
    void Update()
    {
        //this block runs whenever the player presses either mouse button
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            //stores all data a raycast creates
            RaycastHit rayData;
            //this ray goes from the center of the screen to wherever you click
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if this ray hits something...
            if (Physics.Raycast(ray, out rayData))
            {
                //if you left clicked on a gondola while holding F...
                if (Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.F) && rayData.collider.tag == "Gondola")
                {
                    //set this gondola to be followed
                    toggleCamFollow = true;
                    pickygondo = rayData.collider.gameObject;
                }
                //if you did not hold F and you are not carrying a gondola...
                else if (Input.GetButtonDown("Fire1") && GetComponent<GondolaPickup>().carrying == false)
                {
                    //create a new gondola gameobject at the point the player clicked
                    GameObject gondola = Instantiate(gondolaBase, rayData.point, transform.rotation) as GameObject;
                    //if the player held G while clicking, supersize the gondola
                    if (Input.GetKey(KeyCode.G))
                    {
                        gondola.transform.localScale = new Vector3(3, 3, 3);
                    }
                    //if the random number is over 99...
                    if (Random.Range(0, 100) >= 99)
                    {
                        //do second check;
                        if (Random.Range(0, 100) > 90)
                        {
                            //if both are true, give the gondola one of the ultra rare skins
                            gondola.transform.Find("Bode").gameObject.GetComponent<Renderer>().material = ultraRareMaterials[Random.Range(0, ultraRareMaterials.Length)];
                        }
                    }
                    //if not, and a new random number is over 70...
                    else if (Random.Range(0, 100) > 70)
                    {
                        //gondola gets a rare skin
                        gondola.transform.Find("Bode").gameObject.GetComponent<Renderer>().material = rareMaterials[Random.Range(0, rareMaterials.Length)];
                    }
                    //else it gets a regular skin
                    else
                    {
                        gondola.transform.Find("Bode").gameObject.GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length)];
                    }
                    //this finds the head bone of the gondola, so we can attach hats to it
                    Transform head = gondola.transform.Find("Bonere/Root/Head");
                    //if random number is over 90...
                    if (Random.Range(0, 100) > 90)
                    {
                        //idk what this even does, better no touch
                        GameObject hat = gameObject;
                        //second check
                        if (Random.Range(0, 100) > 90)
                        {
                            //if both checks are passed, give gondola a rare hat
                            hat = Instantiate(rareHats[Random.Range(0, rareHats.Length)], head.position, Quaternion.identity) as GameObject;
                        }
                        //else give it a regular hat
                        else
                        {
                            hat = Instantiate(hats[Random.Range(0, hats.Length)], head.position, Quaternion.identity) as GameObject;
                        }
                        //parents the hat to the head bone we specified before
                        hat.transform.parent = head.transform;
                        //sets the scale of the hat to 1 if it for some reason was not already 1
                        hat.transform.localScale = new Vector3(1, 1, 1);
                        //equals the rotation of the hat to that of the gondola
                        hat.transform.rotation = gondola.transform.rotation;
                    }
                    //if the hand is not yet doing the create gondola animation, make it do the animation
                    if (!GameObject.FindWithTag("Rules").GetComponent<GondolaPickup>().zaHando.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("CreateGondola"))
                    {
                        GameObject.FindWithTag("Rules").GetComponent<GondolaPickup>().zaHando.GetComponent<Animator>().SetTrigger(GameObject.FindWithTag("Rules").GetComponent<GondolaPickup>().createHash);
                    }
                    //sets gondola rotation so it faces towards the camera
                    gondola.transform.rotation = Quaternion.Euler(0, 180, 0);
                    //plays the spawn sound
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(createSound);
                }
            }
        }

        //if a gondola is to be followed...
        if (toggleCamFollow == true)
        {
            //place the camera at the gondolas position + the offset
            Camera.main.transform.position = pickygondo.transform.position + new Vector3(0, 10, -15);
        }
        //toggles the following off
        if (toggleCamFollow == true && Input.GetKeyDown(KeyCode.F))
        {
            toggleCamFollow = false;
        }
    }
}