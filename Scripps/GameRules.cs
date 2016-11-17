using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class GameRules : MonoBehaviour
{
    //gondola counter
    public Text gondoCount;
    //amount of gondolas last frame
    private int gondoNum = 0;
    //duh
    public bool music = true;
    //sound clip for the train bell
    public AudioClip bellring;
    //sound clip for screenshot sound
    public AudioClip camSnap;
    //suber important, this list keeps all gondolas registered
    public List<GameObject> gondolas;
    //the tutorial text displayed at start
    public GameObject tutorialtext;
    //toggles the tutorial text
    public bool tutbool = true;

    void Start()
    {
        //sets the gondola counter to the string below
        gondoCount.text = "No gondolas yet";

        //checks if the screenies foleder exists
        if (System.IO.Directory.Exists(Application.dataPath.ToString() + "/Screenies"))
        {
            //lel
        }
        //else it creates this folder
        else
        {
            System.IO.Directory.CreateDirectory(Application.dataPath.ToString() + "/Screenies");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            //this string is the time at which you take a screenshot
            string time = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + System.DateTime.Now.Day.ToString() + " - " + System.DateTime.Now.Hour.ToString() + "." + System.DateTime.Now.Minute.ToString() + "." + System.DateTime.Now.Second.ToString() + "," + System.DateTime.Now.Millisecond.ToString();
            //captures the screenshot
            Application.CaptureScreenshot(Application.dataPath.ToString() + "/" + "Screenies/SGL-Screenshot " + time + ".PNG", 1);
            //plays the sound
            Camera.main.GetComponent<AudioSource>().PlayOneShot(camSnap); Camera.main.GetComponent<AudioSource>().PlayOneShot(camSnap);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            string time = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + System.DateTime.Now.Day.ToString() + " - " + System.DateTime.Now.Hour.ToString() + "." + System.DateTime.Now.Minute.ToString() + "." + System.DateTime.Now.Second.ToString() + "," + System.DateTime.Now.Millisecond.ToString();
            Application.CaptureScreenshot(Application.dataPath.ToString() + "/" + "Screenies/SGL-Screenshot-2xSuperSampled " + time + ".PNG", 2);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(camSnap); Camera.main.GetComponent<AudioSource>().PlayOneShot(camSnap);
        }

        //toggles the tutorial text
        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (tutbool ==true)
            {
                tutbool = false;
                tutorialtext.SetActive(false);
            }
            else
            {
                tutbool = true;
                tutorialtext.SetActive(true);
            }
        }

        //checks if what you're right clicking is the bell
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit rayData;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out rayData))
            {
                if (rayData.collider.tag == "Bell")
                {
                    rayData.collider.GetComponent<Animator>().Play("ring");
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(bellring);
                }
            }
        }

        //toggles music
        if (Input.GetKeyDown(KeyCode.N))
        {
            MusicSwitch();
        }

        //checks if any gondolas have entered or exited gondola land and updates the counter
        if (gondoNum != gondolas.Count)
        {
            gondoNum = gondolas.Count;
            gondoCount.text = "Gondolas: " + gondoNum;
        }
    }

    //toggles music
    void MusicSwitch()
    {
        if (music == true)
        {
            Camera.main.GetComponent<AudioSource>().Stop();
            music = false;
        }
        else
        {
            Camera.main.GetComponent<AudioSource>().Play();
            music = true;
        }
    }
}
