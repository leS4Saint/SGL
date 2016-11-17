using UnityEngine;
using System.Collections;

public class MeneSwitcher : MonoBehaviour
{
    //array of memes
    public Material[] menes;

    //renderer of the billboard
    private Renderer bilbord;

	void Start ()
    {
        //at start of game picks a random meme
        bilbord = GetComponent<Renderer>();
        bilbord.material = menes[Random.Range(0, menes.Length)];
	}
}
