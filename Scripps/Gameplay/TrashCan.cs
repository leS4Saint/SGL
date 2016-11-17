using UnityEngine;
using System.Collections;

public class TrashCan : MonoBehaviour
{
    public Animator anim;

    public int openHash = Animator.StringToHash("Open");

    public AudioClip recycleSound;
    public AudioClip openSound;
    public AudioClip closeSound;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
}
