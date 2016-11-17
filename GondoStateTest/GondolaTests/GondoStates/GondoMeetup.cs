using UnityEngine;
using System.Collections;

//this state lets a lonely gondola meet another one

public class GondoMeetup : Igondola
{
    private readonly GondolaAI gondola;
    
    //how much fun they're having
    private float fun = 0;
    
    public GondoMeetup(GondolaAI gondolaAI)
    {
        gondola = gondolaAI;
    }

    public void UpdateState()
    {
        //if the gondolas have reached each other, they will stand together
        if (Vector3.Distance(gondola.transform.position, gondola.buddyGondola.transform.position) < 3)
        {
            gondola.gondoAgent.destination = gondola.transform.position;
            fun += Time.deltaTime;
        }
        //if not, keep moving to your pal
        else
        {
            gondola.gondoAgent.destination = gondola.buddyGondola.transform.position;
        }

        //if there was no other gondola found, go to idle
        if (!gondola.buddyGondola)
        {
            gondola.lonely = 0;
            ToIdle();
        }

        //if the gondolas have had some fun
        if (fun > 10)
        {
            fun = 0;
            ToTravel();
        }
    }

    public void ToIdle()
    {
        gondola.currentState = gondola.gondoMeetup;
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
        Debug.Log("whoae");
    }

    public void ToHeld()
    {

    }
}
