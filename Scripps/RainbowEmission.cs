using UnityEngine;
using System.Collections;

public class RainbowEmission : MonoBehaviour
{
    public Color colore;
    public float speed = 1;
    public float brighte = 1;
    public float hue = 0;
    private Renderer rendy;

    void Start()
    {
        rendy = GetComponent<Renderer>();
        //rendy.material.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        hue += Time.deltaTime * speed;
        if (hue > 100)
        {
            hue = 0;
        }

        colore = Color.HSVToRGB(hue / 100, 1, 1);

        //colore = new Color(r, g, b);
        //brighte = (Mathf.Sin(Time.time * speed) / 2) + 0.5f;
        rendy.material.SetColor("_EmissionColor", colore * brighte);
    }
}
