using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class UfoEvent : MonoBehaviour
{
    private int leaveHash = Animator.StringToHash("Leave");

    public bool togglemusic = false;

    public AudioSource ayylmao;

    public GameObject[] gondos;

    public List<Transform> gondoplaek;


    void Start()
    {
        ayylmao = GetComponent<AudioSource>();
        ayylmao.volume = 0;
        UfoAppear();
    }

    void Update()
    {
        if (togglemusic == true)
        {
            ayylmao.volume += Time.deltaTime / 10;
            Camera.main.GetComponent<AudioSource>().volume -= Time.deltaTime / 10;
        }
        else
        {
            ayylmao.volume -= Time.deltaTime / 20;
            Camera.main.GetComponent<AudioSource>().volume += Time.deltaTime / 20;
        }

        if (GameObject.FindWithTag("Rules").GetComponent<TimeScripp>().tiem > 300)
        {
            UfoLeave();
        }
    }

    void UfoAppear()
    {
        togglemusic = true;
    }

    public void UfoLeave()
    {
        togglemusic = false;
        GetComponent<Animator>().SetTrigger(leaveHash);
        foreach (GameObject gond in gondos)
        {
            if (gond.GetComponent<Marker>())
            {
                gond.GetComponent<Animator>().enabled = false;
                gond.tag = "Untagged";
                GameObject.FindWithTag("Rules").GetComponent<GameRules>().gondolas.Remove(gond);
                gond.transform.parent = transform;
            }
        }
    }

    public void ActivateGondos()
    {
        foreach (GameObject feg in gondos)
        {
            feg.GetComponent<Animator>().enabled = true;
            feg.tag = "Gondola";
            feg.transform.parent = null;
            gondoplaek.Add(feg.transform);
        }
    }

    public void DeletUfo()
    {
        Camera.main.GetComponent<AudioSource>().volume = 1;
        Destroy(gameObject);
    }
}
