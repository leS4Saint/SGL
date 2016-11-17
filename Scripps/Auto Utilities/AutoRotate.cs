using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour
{
    public float rotSpeed;


    //randomizes the rotation at start, for extra differentness
    void Update()
    {
        transform.Rotate(0, 0, rotSpeed);
    }
}
