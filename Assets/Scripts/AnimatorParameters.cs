using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters : MonoBehaviour
{

    Movement move_script;
    Animator anim;

    void Start()
    {
        move_script = GetComponent<Movement>();
        anim = GetComponentInChildren<Animator>();
    }
    

    void Update()
    {
        if (move_script.X_isAxisInUse == true || move_script.Y_isAxisInUse == true)
        {
            anim.SetBool("Is Moving", true);
        } else
        {
            anim.SetBool("Is Moving", false);
        }
    }
}
