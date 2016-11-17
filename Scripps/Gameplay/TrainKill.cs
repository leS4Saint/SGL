using UnityEngine;
using System.Collections;

public class TrainKill : MonoBehaviour
{
    //this function destroys all gondolas on the train and also removes them from the list
    public void Kill()
    {
        foreach(Transform gondola in transform)
        {
            if (gondola.name.StartsWith("Gondola"))
            {
                GameObject.FindWithTag("Rules").GetComponent<GameRules>().gondolas.Remove(gondola.gameObject);
                Destroy(gondola.gameObject);
            }
        }
    }
}
