using UnityEngine;
using System.Collections;

//this state controls all playing functions, and i use the term play loosely

public class GondoPlay : Igondola
{
    //reference to the gondola
    private readonly GondolaAI gondola;

    //how long this state should last
    private float wait = 4;
    //this float tracks how long the state has been going
    private float timer = 0;
    //well
    private bool playing = false;

    private GameObject currentEvent;

    public GondoPlay (GondolaAI gondolaAI)
    {
        gondola = gondolaAI;
    }

    public void UpdateState()
    {   
        //makes the gondola stop
        gondola.gondoAgent.destination = gondola.transform.position;

        //if the gondola is in the water and is not already playing...
        if (gondola.currentTouch == "Water" && playing == false)
        {
            //set the time this state should last to 2,
            wait = 2;
            //make the gondola splash
            gondola.anim.SetTrigger(gondola.splashHash);
            currentEvent = GameObject.Instantiate(gondola.effects[0], gondola.transform.position, Quaternion.identity) as GameObject;
            currentEvent.transform.parent = gondola.transform;
            playing = true;
        }
        //or if the gondola is in a hot place,
        else if (gondola.currentTouch == "Hot" && playing == false)
        {
                //make the state last 4 seconds and play the animations
                wait = 4;
                gondola.anim.SetTrigger(gondola.sweatHash);
                playing = true;
        }
        //and if neither of these, just make it lie down
        else if (playing == false)
        {
            wait = 20;
            gondola.anim.SetBool(gondola.lieHash, true);
            playing = true;
        }

        //increment the timer by 1 second every second
        timer += Time.deltaTime;

        //if the state has been going on long enough, reset everything and go to the idle state
        if (timer > wait)
        {
            gondola.anim.SetBool(gondola.lieHash, false);
            timer = 0;
            playing = false;

            if (currentEvent)
            {
                GameObject.Destroy(currentEvent);
            }
            ToIdle();
        }
    }

    public void ToIdle()
    {
        gondola.boredom = 0;
        gondola.currentState = gondola.gondoIdle;
    }

    public void ToTravel()
    {
        gondola.currentState = gondola.gondoTravel;
    }
    
    public void ToPlay()
    {
        Debug.Log("whoa");
    }

    public void ToMeetup()
    {
        gondola.currentState = gondola.gondoMeetup;
    }

    public void ToHeld()
    {

    }

    //play fucntiuonss
    private void WaterSplash()
    {
        //hi
    }
}
