using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 2.5f;
    public bool canMove, dead, player1, player2;
    public int gridX, gridY;
    Vector3 pos;
    Transform tr;
    public bool X_isAxisInUse = false, Y_isAxisInUse = false;

    void Start()
    {
        

    }

    void Update()
    {
        var deadzone = 0.1f;
         //Debug.DrawRay(transform.position, (transform.forward - transform.up).normalized * 1, Color.yellow);
         //Debug.DrawRay(transform.position, (-transform.forward - transform.up).normalized * 1, Color.yellow);
         //Debug.DrawRay(transform.position, (transform.right - transform.up).normalized * 1, Color.yellow);
         //Debug.DrawRay(transform.position, (-transform.right - transform.up).normalized * 1, Color.yellow);

        RaycastHit checkTile;

        if (Physics.Raycast(transform.position, -transform.up, out checkTile, 1))
        {

        }
        else
        {
            if (!dead)
            {
                gameObject.AddComponent<Rigidbody>();
                dead = true;
            }
        }

        if (player1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove)
            {
                RaycastHit hit;
                Debug.Log("Trigger");


                if (Physics.Raycast(transform.position, (-transform.right - transform.up).normalized, out hit, 1))
                {
                    transform.Translate(Vector3.left * speed);
                    gridX += 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && canMove)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, (-transform.forward - transform.up).normalized, out hit, 1))
                {
                    transform.Translate(Vector3.back * speed);
                    gridY += 1;
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && canMove)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.right - transform.up).normalized, out hit, 1))
                {
                    transform.Translate(Vector3.right * speed);
                    gridX -= 1;
                }

            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && canMove)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.forward - transform.up).normalized, out hit, 1))
                {
                    transform.Translate(Vector3.forward * speed);
                    gridY -= 1;
                }

            }
        }

        if (player2)
        {
            //Debug.Log(Input.GetAxis("BiggerBenjamin"));

            if (Input.GetAxis("ControllerX") <= -deadzone && canMove && X_isAxisInUse == false)
            {


                X_isAxisInUse = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (-transform.right - transform.up).normalized, out hit, 1))
                {
                    transform.Translate(Vector3.left * speed);
                    gridX += 1;
                }
            }
            if (Input.GetAxis("ControllerY") >= deadzone && canMove && Y_isAxisInUse == false)
            {
                Y_isAxisInUse = true;
                RaycastHit hit;

                if (Physics.Raycast(transform.position, (-transform.forward - transform.up).normalized, out hit, 1))
                {
                    transform.Translate(Vector3.back * speed);
                    gridY += 1;
                }

            }
            if (Input.GetAxis("ControllerX") >= deadzone && canMove && X_isAxisInUse == false)
            {
                X_isAxisInUse = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.right - transform.up).normalized, out hit, 1))
                {
                    transform.Translate(Vector3.right * speed);
                    gridX -= 1;
                }

            }
            if (Input.GetAxis("ControllerY") <= -deadzone && canMove && Y_isAxisInUse == false)
            {
                Y_isAxisInUse = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (transform.forward - transform.up).normalized, out hit, 1))
                {
                    transform.Translate(Vector3.forward * speed);
                    gridY -= 1;
                }

            }

            if (Input.GetAxisRaw("ControllerX") < deadzone && Input.GetAxisRaw("ControllerX") > -deadzone)
            {
                X_isAxisInUse = false;
            }

            if (Input.GetAxisRaw("ControllerY") < deadzone && Input.GetAxisRaw("ControllerY") > -deadzone)
            {
                Y_isAxisInUse = false;
            }
        }
        
        
    }

    public Vector3 targetPosition()
    {
        return transform.position;


    }
}
