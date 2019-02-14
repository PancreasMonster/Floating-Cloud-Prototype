using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class ArcMovement : MonoBehaviour
{
    public Vector3 targetDir;
    private Vector3 target;
    private float dist;
    private float angle;
    public float velocity;

    public GameObject projectile;
    public Vector3 targetObj;
    public float shootAngle;
    public float bolfSpeed;
    

    private bool charging = false;
    private bool charging1 = false;


    private float ballCharge = 0;
    private float energyDrainAmount = 0;
    public float chargeSpeed = 5;

    private Vector3 sizeIncrement;

    private float energyLevel;

    public Energy boltEnergyscript;

    public bool player1, player2;
    

    public Image cursor;

    public float controllerSensitivity;

    public LayerMask layer;

    public GameObject targetObject;

    public Slider sl;

    public Text text;

    Movement move;

    public float drainRate;

    private bool canCharge = true;
    public AudioSource chargeUp;
    public AudioSource chargeRelease;
    public AudioSource boltFlying;


    
    // Start is called before the first frame update
    void Start()
    {
        energyLevel = Random.Range(10, 100);
        move = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        targetObj = targetObject.transform.position;
        //print((Input.GetAxis("Fire2")));
        if (ballCharge < .99)
        text.text = (Mathf.RoundToInt(ballCharge*100+1)).ToString() + "%";
        else
        {
            text.text = "100%";
        }
        // print(energyLevel);
        if (player1)
        {
            if (Input.GetAxis("Fire2")> 0)
            {
                ChargeBolt();
                charging1 = true;
                chargeUp.Play();
                print(charging1);
                sl.value = ballCharge;
                move.canMove = false;
                RaycastHit checkTile;

                if (Physics.Raycast(transform.position, -transform.up, out checkTile, 1, layer))
                {
                    GameObject tileBelow = checkTile.transform.gameObject;
                    tileBelow.GetComponent<Energy>().startDraining();
                    //tileBelow.GetComponent<Energy>().energy -= tileBelow.GetComponent<Energy>().energy / tileBelow.GetComponent<Energy>().maxEnergy;
                }
            }


            if (Input.GetAxis("Fire2")== 0)
            {
                if (charging1)
                {

                    sl.value = 0;
                    move.canMove = true;
                    Vector3 CubeHeight = new Vector3(0, -0.5f, 0);
                    GameObject thunderBolt =
                        Instantiate(projectile, transform.position + CubeHeight, Quaternion.identity);
                    //thunderBolt.transform.localScale += ChargeBolt();
                    Rigidbody boltRB = thunderBolt.AddComponent<Rigidbody>();
                    boltRB.velocity = BallisticVel(targetObj, shootAngle);
                    //boltEnergyscript.energyLevel() += energyLevel;
                    EnergyHolder EH = thunderBolt.AddComponent<EnergyHolder>();
                    EH.Target(targetObj,shootAngle);
                    
                    RaycastHit checkTile;

                    if (Physics.Raycast(transform.position, -transform.up, out checkTile, 1, layer))
                    {
                        //Debug.Log(checkTile.transform.name);
                        GameObject tileBelow = checkTile.transform.gameObject;
                        float energyDrained = Mathf.Floor(tileBelow.GetComponent<Energy>().energy * ballCharge);

                        //tileBelow.GetComponent<Energy>().drainEnergy(ballCharge);
                        tileBelow.GetComponent<Energy>().stopDraining();
                        EH.EnergyLevel(energyDrainAmount);
                    }



                    sizeIncrement = Vector3.zero;
                    ballCharge = 0;
                    energyDrainAmount = 0;
                    charging1 = false;
                }



            }

            /*if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, layer);
                if (hit)
                {
                    if (hitInfo.transform.gameObject.tag == "Tile")
                    {
                        //Vector3 temp = hitInfo.transform.gameObject.transform.position;
                       // targetObj = temp + new Vector3(0, 0f, 0);
                    }
                }
            }*/


        }

        if (player2)
        {
           // Debug.Log("X: " + Input.GetAxis("ControllerX"));
           // Debug.Log("Y: " + Input.GetAxis("ControllerY"));
            var deadzone = 0.1f;
            
            /*if (Input.GetAxis("ControllerX") >= deadzone)              //Change to controller x axis
            {
                cursor.transform.position += Vector3.right * controllerSensitivity;


            }

            if (Input.GetAxis("ControllerX") <= -deadzone)                //Change to controller x axis
            {
                cursor.transform.position -= Vector3.right * controllerSensitivity;


            }

            if (Input.GetAxis("ControllerY") <= -deadzone)                     //Change to controller y axis
            {
                cursor.transform.position += Vector3.up * controllerSensitivity;


            }

            if (Input.GetAxis("ControllerY") >= deadzone)                     //Change to controller y axis
            {
                cursor.transform.position -= Vector3.up * controllerSensitivity;


            }
            
            
            
            Ray ray2 = Camera.main.ScreenPointToRay(cursor.transform.position);
            RaycastHit hit2;

            if (Physics.Raycast(ray2, out hit2, 10000))
            {

                if (hit2.transform.tag == "Player1Tile")
                {

                   
                }
            }*/
            if (Input.GetAxis("Fire1")> 0)
            {
                ChargeBolt();
                if (charging == false)
                {
                    chargeUp.Play();
                }
                charging = true;
                sl.value = ballCharge;
                move.canMove = false;
               
                
                RaycastHit checkTile;
                
                
                if (Physics.Raycast(transform.position, -transform.up, out checkTile, 1, layer))
                {
                    GameObject tileBelow = checkTile.transform.gameObject;
                    tileBelow.GetComponent<Energy>().startDraining();
                    //tileBelow.GetComponent<Energy>().energy -= tileBelow.GetComponent<Energy>().energy / tileBelow.GetComponent<Energy>().maxEnergy;
                }
            }
                    
                    
            if (Input.GetAxis("Fire1")== 0) //Change to controller right trigger
            {
                sl.value = 0;
                if (charging)
                {
                    chargeUp.Stop();
                    
                    chargeRelease.Play();
                    boltFlying.Play();
                    
                    Vector3 CubeHeight = new Vector3(0, -0.5f, 0);
                    //Vector3 temp = hit2.transform.gameObject.transform.position;
                    //targetObj = temp + new Vector3(0, 0f, 0);
                    move.canMove = true;
                    GameObject thunderBolt =
                        Instantiate(projectile, transform.position + CubeHeight, Quaternion.identity);
                    //thunderBolt.transform.localScale += ChargeBolt();
                    //thunderBolt.gameObject.layer = 4;
                    Rigidbody boltRB = thunderBolt.AddComponent<Rigidbody>();
                    boltRB.velocity = BallisticVel(targetObj, shootAngle);
                    thunderBolt.transform.LookAt(BallisticVel(targetObj, shootAngle));
                    //boltEnergyscript.energyLevel() += energyLevel;
                    EnergyHolder EH = thunderBolt.AddComponent<EnergyHolder>();

                    RaycastHit checkTile;

                    if (Physics.Raycast(transform.position, -transform.up, out checkTile, 1, layer))
                    {
                        //Debug.Log(checkTile.transform.name);
                        GameObject tileBelow = checkTile.transform.gameObject;
                        float energyDrained = Mathf.Floor(tileBelow.GetComponent<Energy>().energy * ballCharge);

                        //tileBelow.GetComponent<Energy>().drainEnergy(ballCharge);
                        tileBelow.GetComponent<Energy>().stopDraining();
                        EH.EnergyLevel(energyDrainAmount);
                    } 

                    sizeIncrement = Vector3.zero;
                    ballCharge = 0;
                    energyDrainAmount = 0;
                    charging = false;
                }

            }
        }
        
        RaycastHit checkTileCharge;

        if (Physics.Raycast(transform.position, -transform.up, out checkTileCharge, 1, layer))
        {
            GameObject tileBelow = checkTileCharge.transform.gameObject;
            if (tileBelow.GetComponent<Energy>().energy <= 1f)
            {
                canCharge = false;
            }
            else
            {
                canCharge = true;
            }
            
        }
    }



    public Vector3 ChargeBolt()
    {
       
        if (ballCharge < .99f && canCharge)
        {
            ballCharge += (1 / chargeSpeed) * Time.deltaTime;
            energyLevel -= (1 / chargeSpeed) * Time.deltaTime;
            sizeIncrement = new Vector3(ballCharge, ballCharge, ballCharge);

            RaycastHit checkTile;

            if (Physics.Raycast(transform.position, -transform.up, out checkTile, 1, layer))
            {
                GameObject tileBelow = checkTile.transform.gameObject;
                tileBelow.GetComponent<Energy>().energy -= tileBelow.GetComponent<Energy>().maxEnergy / 61 * (1 / chargeSpeed); 
                energyDrainAmount += tileBelow.GetComponent<Energy>().maxEnergy / 61 * (1 / chargeSpeed);
                

            } 

        }
        return sizeIncrement;
    }
    

    public Vector3 BallisticVel(Vector3 target, float angle)
    {
        targetDir = target - transform.position;            //target direction
        dist = targetDir.magnitude;
        float radAngle = angle * Mathf.Deg2Rad;
        targetDir.y = dist * Mathf.Tan(radAngle);            //set targetDir to elevation angle
        velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(radAngle * 2));
        return velocity * targetDir.normalized;

    }

   
}
