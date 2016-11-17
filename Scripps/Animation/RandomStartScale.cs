using UnityEngine;
using System.Collections;

public class RandomStartScale : MonoBehaviour
{
	void Start ()
    {
        //at start this script randomizes the scale of the objects it's attached to, i use this for trees and such
        transform.localScale = new Vector3(Random.Range(1, 1.2f), Random.Range(1, 1.2f), Random.Range(1, 1.2f));
    }
}
