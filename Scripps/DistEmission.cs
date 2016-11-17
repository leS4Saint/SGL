using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DistEmission : MonoBehaviour
{
    public Color colore;
    public float distance = 1;
    public float brighte = 0;
    private Renderer rendy;
    private GameObject tiles;
    private GameObject player;

    void Start()
    {
        rendy = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        brighte = 1 - (Vector3.Distance(player.transform.position, transform.position) / distance);

        if (brighte < 0)
        {
            brighte = 0;
        }
        
        rendy.material.SetColor("_EmissionColor", colore * brighte);
    }

    void GetKiddos(GameObject parent)
    {
        int numbere = 0;
        var kiddos = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            kiddos.Add(child.gameObject);
        }

        foreach (GameObject child in kiddos)
        {
            numbere++;
            Debug.Log("# " + numbere);
        }
    }

}