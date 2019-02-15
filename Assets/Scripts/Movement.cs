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
    public GameOverScipt GOS;

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

        

        if (player1)
        {

            if (Physics.Raycast(transform.position, -transform.up, out checkTile, 1, layer))
            {

            }
            else
            {
                if (!dead)
                {
                    gameObject.AddComponent<Rigidbody>();
                    dead = true;
                    canMove = false;
                    GOS.Player1Win();
                }
            }

            if (Input.GetAxisRaw ("Dpad2y") == 1 && canMove && Y_isAxisInUse == false)
            {
                

                Y_isAxisInUse = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (-transform.right - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.left * speed);
                    gridX += 1;
                }
            }
            if (Input.GetAxisRaw("Dpad2x") == -1 && canMove && X_isAxisInUse == false)
            {
                X_isAxisInUse = true;
                RaycastHit hit;

                if (Physics.Raycast(transform.position, (-transform.forward - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.back * speed);
                    gridY += 1;
                }

            }
            if (Input.GetAxisRaw("Dpad2y") == -1 && canMove && Y_isAxisInUse == false)
            {
                Y_isAxisInUse = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.right - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.right * speed);
                    gridX -= 1;
                }

            }
            if (Input.GetAxisRaw("Dpad2x") == 1 && canMove && X_isAxisInUse == false)
            {
                X_isAxisInUse = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.forward - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.forward * speed);
                    gridY -= 1;
                }

            }

            if (Input.GetAxisRaw("Dpad2x") == 0)
            {
                X_isAxisInUse = false;
            }

            if (Input.GetAxisRaw("Dpad2y") == 0)
            {
                Y_isAxisInUse = false;
            }
        }
            
            
            
            /*if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove)
            {
                RaycastHit hit;



                if (Physics.Raycast(transform.position, (-transform.right - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.left * speed);
                    gridX += 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && canMove)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, (-transform.forward - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.back * speed);
                    gridY += 1;
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && canMove)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.right - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.right * speed);
                    gridX -= 1;
                }

            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && canMove)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.forward - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.forward * speed);
                    gridY -= 1;
                }

            }*/
        

        if (player2)
        {
            //Debug.Log(Input.GetAxis("BiggerBenjamin"));


            if (Physics.Raycast(transform.position, -transform.up, out checkTile, 1, layer))
            {

            }
            else
            {
                if (!dead)
                {
                    gameObject.AddComponent<Rigidbody>();
                    dead = true;
                    canMove = false;
                    GOS.Player2Win();
                }
            }

            if (Input.GetAxisRaw ("BiggerBenjamin") == -1 && canMove && Y_isAxisInUse == false)
            {
                

                Y_isAxisInUse = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (-transform.right - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.left * speed);
                    gridX += 1;
                }
            }
            if (Input.GetAxisRaw("BigBob") == 1 && canMove && X_isAxisInUse == false)
            {
                X_isAxisInUse = true;
                RaycastHit hit;

                if (Physics.Raycast(transform.position, (-transform.forward - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.back * speed);
                    gridY += 1;
                }

            }
            if (Input.GetAxisRaw("BiggerBenjamin") == 1 && canMove && Y_isAxisInUse == false)
            {
                Y_isAxisInUse = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.right - transform.up).normalized, out hit, 3f, layer))
                {
                    transform.Translate(Vector3.right * speed);
                    gridX -= 1;
                }

            }
            if (Input.GetAxisRaw("BigBob") == -1 && canMove && X_isAxisInUse == false)
            {
                X_isAxisInUse = true;
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
