using UnityEngine;
using System.Collections;

public class HandMeme : MonoBehaviour
{
    private int meme = Animator.StringToHash("MEME");

	void Update ()
    {
        //if you press M the hand does that epic meme thinf
        if (Input.GetKeyDown(KeyCode.M) && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("MEME"))
        {
            GetComponent<Animator>().SetTrigger(meme);
        }
	}
}
