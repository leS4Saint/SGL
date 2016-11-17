using UnityEngine;
using System.Collections;

public class Traintoggle : MonoBehaviour
{
    public bool train = false;
    public GameObject datrain;
    public GameObject trainset;

    void Start()
    {
        if (train == false)
        {
            datrain.SetActive(false);
            trainset.SetActive(false);
        }
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T) && train == true)
        {
            datrain.SetActive(false);
            trainset.SetActive(false);
            train = false;
        }
        else if (Input.GetKeyDown(KeyCode.T) && train == false)
        {
            datrain.SetActive(true);
            trainset.SetActive(true);
            train = true;
        }
	}
}
