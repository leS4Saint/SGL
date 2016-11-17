using UnityEngine;
using System.Collections;

public class GondoHeld : Igondola
{
    //placeholder state for holding a gondola, but didn't really need it i think
    private readonly GondolaAI gondola;

    public GondoHeld(GondolaAI gondolaAI)
    {
        gondola = gondolaAI;
    }

    public void UpdateState()
    {

    }

    public void ToIdle()
    {

    }

    public void ToTravel()
    {

    }

    public void ToPlay()
    {

    }

    public void ToMeetup()
    {

    }

    public void ToHeld()
    {

    }
}
