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
       // Debug.DrawRay(transform.position, (transform.forward - transform.up).normalized * 1, Color.yellow);
       // Debug.DrawRay(transform.position, (-transform.forward - transform.up).normalized * 1, Color.yellow);
       // Debug.DrawRay(transform.position, (transform.right - transform.up).normalized * 1, Color.yellow);
       // Debug.DrawRay(transform.position, (-transform.right - transform.up).normalized * 1, Color.yellow);

        if (Input.GetKeyDown (KeyCode.W) && canMove)
        {
            RaycastHit hit;



            if (Physics.Raycast(transform.position, (-transform.right - transform.up).normalized, out hit, 1))
            {
                transform.Translate(Vector3.left * speed);
                gridX += 1;
            }
        }
        if (Input.GetKeyDown (KeyCode.A) && canMove)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, (-transform.forward - transform.up).normalized, out hit, 1))
            {
                transform.Translate(Vector3.back * speed);
                gridY += 1;
            }
            
        }
        if (Input.GetKeyDown (KeyCode.S) && canMove)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (transform.right - transform.up).normalized, out hit, 1))
            {
                transform.Translate(Vector3.right * speed);
                gridX -= 1;
            }
            
        }
        if (Input.GetKeyDown (KeyCode.D) && canMove)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (transform.forward - transform.up).normalized, out hit, 1))
            {
                transform.Translate(Vector3.forward * speed);
                gridY -= 1;
            }
           
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
