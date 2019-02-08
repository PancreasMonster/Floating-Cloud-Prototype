using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2.5f;
    public bool canMove;
    public int gridX, gridY;
    Vector3 pos;
    Transform tr;

    void Start()
    {
       

    }

    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.W) && canMove && gridX != 0)
        {
            transform.Translate(Vector3.left * speed);
            gridX += 1;
        }
        if (Input.GetKeyDown (KeyCode.A) && canMove && gridY != 0)
        {
            transform.Translate(Vector3.back * speed);
            gridY += 1;
        }
        if (Input.GetKeyDown (KeyCode.S) && canMove && gridX != -4)
        {
            transform.Translate(Vector3.right * speed);
            gridX -= 1;
        }
        if (Input.GetKeyDown (KeyCode.D) && canMove && gridY != -4)
        {
            transform.Translate(Vector3.forward * speed);
            gridY -= 1;
        }

    }

    void FixedUpdate()
    {
       // if (canMove == true)
      //  {
            //gridMovement();

     //   }

    }
}
