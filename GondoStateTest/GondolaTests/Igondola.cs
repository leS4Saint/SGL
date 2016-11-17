using UnityEngine;
using System.Collections;

//gondola interface, dont know how this works so please do not ask

public interface Igondola
{
    void UpdateState();

    void ToIdle();

    void ToTravel();

    void ToPlay();

    void ToMeetup();

    void ToHeld();
}