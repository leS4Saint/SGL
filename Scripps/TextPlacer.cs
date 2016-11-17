using UnityEngine;
using System.Collections;

public class TextPlacer : MonoBehaviour
{
    public GameObject[] letterObjects;
    public GameObject[] numberObjects;
    public GameObject[] symbolObjects;

    private Vector3 placePos;
    private Vector3 oGPlacepos;
    private float prevIncrement;

    public string text;
    private string prevText;

    public Material textMaterial;
    public float rainbowSpeed = 1;

    public float scale = 1;
    private float oGScale;

    public float kerning = 3;
    private float oGKerning;


    //PLAY FUNCTIONS
    public bool rotateLetters = false;
    public float rotSpeed = 1;
    public bool scaleJiggle;
    public float jiggle = 1;
    public float jigspeed = 1;

    void Awake()
    {
        placePos = transform.position;
        oGPlacepos = placePos;
        oGKerning = kerning;
        oGScale = scale;
    }

    void Start()
    {
        prevText = text;

        PlaceLetters();
    }

    void Update()
    {
        if (prevText != text || kerning != oGKerning || scale != oGScale)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            prevIncrement = 0;
            placePos = oGPlacepos;
            PlaceLetters();
            prevText = text;
            oGKerning = kerning;
            oGScale = scale;
        }

        if (rotateLetters == true)
        {
            foreach (Transform child in transform)
            {
                child.transform.Rotate(Vector3.up * rotSpeed);
            }
        }

        if (scaleJiggle == true)
        {
            float mathe = (2 - Mathf.Sin(jigspeed * Time.time));
            Vector3 jiggy = new Vector3(mathe, mathe, mathe) * jiggle;
            foreach (Transform child in transform)
            {
                child.transform.localScale = jiggy;
            }
        }

        foreach (Transform child in transform)
        {
            child.GetComponent<RainbowEmission>().speed = rainbowSpeed;
        }

        //if (transform.localScale.x > 0.5f)
        //{

        //    transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        //}
    }
    void Instructions(GameObject instance)
    {
        if (prevIncrement == 0)
        {
            prevIncrement = instance.GetComponent<MeshFilter>().mesh.bounds.extents.x;
        }
        instance.transform.localScale *= scale;
        instance.transform.parent = transform;
        placePos += -transform.right * (((instance.GetComponent<MeshFilter>().mesh.bounds.extents.x) + prevIncrement) + kerning);
        instance.GetComponent<Renderer>().material = textMaterial;
        instance.AddComponent<RainbowEmission>();
        prevIncrement = instance.GetComponent<MeshFilter>().mesh.bounds.extents.x;
    }

    void PlaceLetters()
    {
        for (int i = 0; i <= text.Length - 1; i++)
        {
            if (text[i].ToString() == "a")
            {
                GameObject tempObj = Instantiate(letterObjects[0], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "b")
            {
                GameObject tempObj = Instantiate(letterObjects[1], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "c")
            {
                GameObject tempObj = Instantiate(letterObjects[2], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "d")
            {
                GameObject tempObj = Instantiate(letterObjects[3], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "e")
            {
                GameObject tempObj = Instantiate(letterObjects[4], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "f")
            {
                GameObject tempObj = Instantiate(letterObjects[5], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "g")
            {
                GameObject tempObj = Instantiate(letterObjects[6], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "h")
            {
                GameObject tempObj = Instantiate(letterObjects[7], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "i")
            {
                GameObject tempObj = Instantiate(letterObjects[8], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "j")
            {
                GameObject tempObj = Instantiate(letterObjects[9], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "k")
            {
                GameObject tempObj = Instantiate(letterObjects[10], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "l")
            {
                GameObject tempObj = Instantiate(letterObjects[11], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "m")
            {
                GameObject tempObj = Instantiate(letterObjects[12], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "n")
            {
                GameObject tempObj = Instantiate(letterObjects[13], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "o")
            {
                GameObject tempObj = Instantiate(letterObjects[14], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "p")
            {
                GameObject tempObj = Instantiate(letterObjects[15], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "q")
            {
                GameObject tempObj = Instantiate(letterObjects[16], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "r")
            {
                GameObject tempObj = Instantiate(letterObjects[17], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "s")
            {
                GameObject tempObj = Instantiate(letterObjects[18], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "t")
            {
                GameObject tempObj = Instantiate(letterObjects[19], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "u")
            {
                GameObject tempObj = Instantiate(letterObjects[20], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "v")
            {
                GameObject tempObj = Instantiate(letterObjects[21], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "w")
            {
                GameObject tempObj = Instantiate(letterObjects[22], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "x")
            {
                GameObject tempObj = Instantiate(letterObjects[23], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "y")
            {
                GameObject tempObj = Instantiate(letterObjects[24], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "z")
            {
                GameObject tempObj = Instantiate(letterObjects[25], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "0")
            {
                GameObject tempObj = Instantiate(numberObjects[0], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "1")
            {
                GameObject tempObj = Instantiate(numberObjects[1], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "2")
            {
                GameObject tempObj = Instantiate(numberObjects[2], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "3")
            {
                GameObject tempObj = Instantiate(numberObjects[3], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "4")
            {
                GameObject tempObj = Instantiate(numberObjects[4], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "5")
            {
                GameObject tempObj = Instantiate(numberObjects[5], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
                
            }
            else if (text[i].ToString() == "6")
            {
                GameObject tempObj = Instantiate(numberObjects[6], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "7")
            {
                GameObject tempObj = Instantiate(numberObjects[7], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "8")
            {
                GameObject tempObj = Instantiate(numberObjects[8], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "9")
            {
                GameObject tempObj = Instantiate(numberObjects[9], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "?")
            {
                GameObject tempObj = Instantiate(symbolObjects[0], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "!")
            {
                GameObject tempObj = Instantiate(symbolObjects[1], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == ":")
            {
                GameObject tempObj = Instantiate(symbolObjects[2], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "&")
            {
                GameObject tempObj = Instantiate(symbolObjects[3], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else if (text[i].ToString() == "$")
            {
                GameObject tempObj = Instantiate(symbolObjects[4], placePos, transform.rotation) as GameObject;
                Instructions(tempObj);
            }
            else
            {
                //GameObject tempObj = Instantiate(letterObjects[25], placePos, transform.rotation) as GameObject;
                placePos += -transform.right * (kerning / 2);
            }
        }
    }
}
