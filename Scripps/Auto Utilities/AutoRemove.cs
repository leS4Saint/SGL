using UnityEngine;
using System.Collections;

public class AutoRemove : MonoBehaviour
{
    //some random time
    public int time = 8;

	void Start ()
    {
        //auto removes the object after set time
        Destroy(gameObject, time);
	}
}
