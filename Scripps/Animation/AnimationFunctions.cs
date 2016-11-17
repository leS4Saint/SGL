using UnityEngine;
using System.Collections;

public class AnimationFunctions : MonoBehaviour
{
    //this function can be triggered by an animation clip, i used it for the splashing animation
    public void ParticleCreate(int amount)
    {
        GetComponentInChildren<ParticleSystem>().Emit(amount);
    }
}
