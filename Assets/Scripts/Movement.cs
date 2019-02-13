using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2.5f;
    public bool canMove, dead, player1, player2;
    public int gridX, gridY;
    Vector3 pos;
    Transform tr;
    public bool X_isAxisInUse = false, Y_isAxisInUse = false;
    public LayerMask layer;

    void Start()
    {
       

    }

    void Update ()
    {
        Debug.DrawRay(transform.position, (transform.forward - transform.up).normalized * 1, Color.yellow);
         Debug.DrawRay(transform.position, (-transform.forward - transform.up).normalized * 1, Color.yellow);
         Debug.DrawRay(transform.position, (transform.right - transform.up).normalized * 1, Color.yellow);
         Debug.DrawRay(transform.position, (-transform.right - transform.up).normalized * 1, Color.yellow);

        RaycastHit checkTile;

        if (Physics.Raycast(transform.position, -transform.up, out checkTile, 14, layer)) {

        }
        else
        {
            if (!dead)
            {
                gameObject.AddComponent<Rigidbody>();
                dead = true;
                canMove = false;
            }
        }

        if (player1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove)
            {
                RaycastHit hit;



                if (Physics.Raycast(transform.position, (-transform.right - transform.up).normalized, out hit, 6f, layer))
                {
                    transform.Translate(Vector3.left * speed);
                    gridX += 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && canMove)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, (-transform.forward - transform.up).normalized, out hit, 6f, layer))
                {
                    transform.Translate(Vector3.back * speed);
                    gridY += 1;
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && canMove)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.right - transform.up).normalized, out hit, 6f, layer))
                {
                    transform.Translate(Vector3.right * speed);
                    gridX -= 1;
                }

            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && canMove)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.forward - transform.up).normalized, out hit, 6f, layer))
                {
                    transform.Translate(Vector3.forward * speed);
                    gridY -= 1;
                }

            }
        }

        if (player2)
        {
            //Debug.Log(Input.GetAxis("BiggerBenjamin"));

            if (Input.GetAxisRaw ("BigBob") == -1 && canMove && X_isAxisInUse == false)
            {
                

                X_isAxisInUse = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (-transform.right - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.left * speed);
                    gridX += 1;
                }
            }
            if (Input.GetAxisRaw("BiggerBenjamin") == -1 && canMove && Y_isAxisInUse == false)
            {
                Y_isAxisInUse = true;
                RaycastHit hit;

                if (Physics.Raycast(transform.position, (-transform.forward - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.back * speed);
                    gridY += 1;
                }

            }
            if (Input.GetAxisRaw("BigBob") == 1 && canMove && X_isAxisInUse == false)
            {
                X_isAxisInUse = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.right - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.right * speed);
                    gridX -= 1;
                }

            }
            if (Input.GetAxisRaw("BiggerBenjamin") == 1 && canMove && Y_isAxisInUse == false)
            {
                Y_isAxisInUse = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.forward - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.forward * speed);
                    gridY -= 1;
                }

            }

            if (Input.GetAxisRaw("BigBob") == 0)
            {
                X_isAxisInUse = false;
            }

            if (Input.GetAxisRaw("BiggerBenjamin") == 0)
            {
                Y_isAxisInUse = false;
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
