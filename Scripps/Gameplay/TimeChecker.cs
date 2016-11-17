using UnityEngine;
using System.Collections;

public class TimeChecker : MonoBehaviour
{
    public GameObject rules;
    public int emitAmount = 10;

    void Start()
    {
        //gets the game rules object
        rules = GameObject.FindWithTag("Rules");
    }

    void Update()
    {
        //i dont even know anymore what this does, better leave it in
        if (rules.GetComponent<TimeScripp>().tiem > rules.GetComponent<TimeScripp>().timeADay - (rules.GetComponent<TimeScripp>().timeADay / 2))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
