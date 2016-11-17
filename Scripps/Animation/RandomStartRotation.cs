using UnityEngine;
using System.Collections;

public class RandomStartRotation : MonoBehaviour
{
    public bool x = false;
    public bool y = false;
    public bool z = false;

	void Start ()
    {
        //randomizes object rotation
        if (x == true)
        {
            transform.Rotate(new Vector3(Random.Range(0, 360), transform.rotation.y, transform.rotation.z));
        }
        if (y == true)
        {
            transform.Rotate(new Vector3(transform.rotation.x, Random.Range(0, 360), transform.rotation.z));
        }
        if (z == true)
        {
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y), Random.Range(0, 360));
        }
    }
}
