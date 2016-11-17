using UnityEngine;
using System.Collections;

//in this state the gondola is idle

public class GondoIdle : Igondola
{
    //the gondola this state belongs to
    private readonly GondolaAI gondola;

    //constructor for this state, sets the gondola that requested this state as the owner
    public GondoIdle (GondolaAI gondolaAI)
    {
        gondola = gondolaAI;
    }

    public void UpdateState()
    {   
        //increments these values while idle
        gondola.boredom += Time.deltaTime;
        gondola.lonely += Time.deltaTime;
        gondola.idleTime += Time.deltaTime;

        //if the gondola has idled enough it will go for a walk, gondolas love to walk
        if (gondola.idleTime > 10)
        {
            gondola.idleTime = 0;
            ToTravel();
        }

        //if its lonely it will try to find another gondola
        if (gondola.lonely > 100)
        {
            ToMeetup();
            ArrangeMeet();
        }

        //well...
        if (gondola.boredom > 50)
        {
            ToPlay();
        }
    }

    public void ToIdle()
    {
        Debug.Log("you're already idle dude");
    }
    
    public void ToTravel()
    {
        gondola.currentState = gondola.gondoTravel;
    }

    public void ToPlay()
    {

    }

    public void ToMeetup()
    {
        gondola.currentState = gondola.gondoMeetup;
    }

    public void ToHeld()
    {

    }

    //this function picks a random gondola from the big list of gondolas to meet up with, and notifies the other gondola that it is needed elsewhere
    public void ArrangeMeet()
    {
        gondola.buddyGondola = GameObject.FindWithTag("Rules").GetComponent<GameRules>().gondolas[Random.Range(0, GameObject.FindWithTag("Rules").GetComponent<GameRules>().gondolas.Count)];
        gondola.buddyGondola.GetComponent<GondolaAI>().buddyGondola = gondola.gameObject;
        gondola.buddyGondola.GetComponent<GondolaAI>().currentState = gondola.buddyGondola.GetComponent<GondolaAI>().gondoMeetup;
        gondola.buddyGondola.GetComponent<GondolaAI>().lonely = 0;
        gondola.lonely = 0;
    }
}
