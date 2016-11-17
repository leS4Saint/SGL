using UnityEngine;
using System.Collections;

public class GondoTravel : Igondola
{
    private readonly GondolaAI gondola;

    //how long the gondola has been traveling
    private float travelTimer = 0;
    //whether the gondola has picked a spot to go to yet
    private bool pickedSpot = false;
    //the picked spot
    private Vector3 pickedPos;

    public GondoTravel(GondolaAI gondolaAI)
    {
        gondola = gondolaAI;
    }

    public void UpdateState()
    {
        //while moving, increment these timers
        gondola.boredom += Time.deltaTime;
        gondola.lonely += Time.deltaTime;
        travelTimer += Time.deltaTime;
        
        //if it has travelled long enough, go to idle (added this because sometimes gondolas want to go somewhere they can not get to, resulting in a stuck gondola)
        if (travelTimer > 30)
        {
            ToIdle();
        }

        //checks if a place has been picked
        if (pickedSpot == false)
        {
            PickPlace();
            pickedSpot = true;
        }

        //if the gondola has reached the place it wants to be
        if (Vector3.Distance(gondola.transform.position, pickedPos) < 2)
        {
            pickedSpot = false;
            ToIdle();
        }

        //if while walking the gondola gets bored
        if (gondola.boredom > 50)
        {
            ToPlay();
        }
    }

    public void ToIdle()
    {
        gondola.currentState = gondola.gondoIdle;
        pickedSpot = false;
        travelTimer = 0;
    }

    public void ToTravel()
    {
        Debug.Log("dude");
    }

    public void ToPlay()
    {
        gondola.currentState = gondola.gondoPlay;
        gondola.gondoAgent.destination = gondola.transform.position;
        pickedSpot = false;
    }

    public void ToMeetup()
    {
        gondola.currentState = gondola.gondoMeetup;
        pickedSpot = false;
    }

    public void ToHeld()
    {

    }

    //picks a random place to move to
    private void PickPlace()
    {
        pickedPos = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
        gondola.gondoAgent.destination = pickedPos;
    }
}
