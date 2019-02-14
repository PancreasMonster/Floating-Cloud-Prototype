using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters : MonoBehaviour
{
    //ArcMovement arc_script;
    Movement move_script;
    Animator anim;

    void Start()
    {
        //arc_script = GetComponent<ArcMovement>();
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

        if (move_script.dead == true)
        {
            anim.SetBool("Dead", true);
        }

        if (move_script.canMove == false)
        {
            anim.SetBool("Is Charging", true);
        } else
        {
            anim.SetBool("Is Charging", false);
        }
    }
}
