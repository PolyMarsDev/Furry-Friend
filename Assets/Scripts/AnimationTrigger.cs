using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] Animator anim;
    public void Trigger()
    {
        anim.SetTrigger("Trigger");
        tag = "Untagged";
    }
}
