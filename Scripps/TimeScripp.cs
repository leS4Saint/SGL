using UnityEngine;
using System.Collections;

public class TimeScripp : MonoBehaviour
{
    //current time
    public float tiem = 0;
    //yeah
    public float timeADay = 360;
    //the sundial
    public GameObject sunDial;
    public GameObject lightSource;
    public float lightIntensity = 1;
    private int sunHash = Animator.StringToHash("SunSetting");
    //the UFO event gameobject
    public GameObject ufoevent;
    //has the ufo been spawned this night?
    private bool spawnwe = false;
    //has the ufo spawn chance been calculated?
    private bool calce = false;
    public float skyboxLight = 1;

    void Update()
    {
        //increments time by 1 every second
        tiem += Time.deltaTime;

        //if time exceeds the time per day, wrap around and reset the ufo event bools
        if (tiem > timeADay)
        {
            tiem = 0;
            calce = false;
            spawnwe = false;
        }
     
        //if time of day is less than half, it's day
        if (tiem < timeADay / 2)
        {
            lightSource.GetComponent<Animator>().SetBool(sunHash, true);
            if (skyboxLight <= 1)
            {
                skyboxLight += Time.deltaTime / 10;
            }
            //sets the skybox brightness
            RenderSettings.skybox.SetFloat("_Exposure", skyboxLight);
        }
        //if time of day is more than half, its night
        if (tiem > timeADay / 2)
        {
            lightSource.GetComponent<Animator>().SetBool(sunHash, false);
            if (skyboxLight >= 0.1f)
            {
                skyboxLight -= Time.deltaTime / 10;
            }
            RenderSettings.skybox.SetFloat("_Exposure", skyboxLight);
        }

        //ufo spawn time
        if (tiem > 200 && spawnwe == false && calce == false && CalcEventChance())
        {
            spawnwe = true;
            Instantiate(ufoevent);
        }

        //for manually changing the time
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            tiem += 1;
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            tiem -= 1;
        }
        //sets the sundial to display the tiem
        sunDial.transform.localRotation = Quaternion.Euler(sunDial.transform.rotation.x, sunDial.transform.rotation.y, -tiem);
    }
    
    //calculates the chance a UFO will spawn
    bool CalcEventChance()
    {
        int swag = Random.Range(0, 100);

        calce = true;

        if (swag >= 80)
        {
            Debug.Log("calc is go");
            return true;
        }
        else
        {
            Debug.Log("calc is fals");
            return false;
        }
    }
}
