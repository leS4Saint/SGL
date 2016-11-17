using UnityEngine;
using System.Collections;

public class AnimationPlaySound : MonoBehaviour
{
    public AudioClip[] clips;
    public int number;

    public void PlaySound()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(clips[number]);
    }

    public void Clip1()
    {
        number = 1;
    }

    public void Clip2()
    {
        number = 2;
    }

    public void Clip3()
    {
        number = 3;
    }
}
