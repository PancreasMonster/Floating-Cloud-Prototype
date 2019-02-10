using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcMovement : MonoBehaviour
{
    private Vector3 targetDir;
    private Vector3 target;
    private float dist;
    private float angle;
    public float velocity;

    public GameObject projectile;
    public Vector3 targetObj;
    public float shootAngle;
    public float bolfSpeed;

    private float ballCharge = 0;

    private Vector3 sizeIncrement;

    private float energyLevel;

    public Energy boltEnergyscript;
    
    // Start is called before the first frame update
    void Start()
    {
        energyLevel = Random.Range(10, 100);
    }

    // Update is called once per frame
    void Update()
    {
        print(energyLevel);
        if (Input.GetKey(KeyCode.Space))
        {
            ChargeBolt();

        }
       
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject thunderBolt = Instantiate(projectile, transform.position, Quaternion.identity);
            thunderBolt.transform.localScale += ChargeBolt();
            Rigidbody boltRB = thunderBolt.GetComponent<Rigidbody>();
            boltRB.velocity = BallisticVel(targetObj, shootAngle);
            //boltEnergyscript.energyLevel() += energyLevel;
            EnergyHolder EH = thunderBolt.AddComponent<EnergyHolder>();
            EH.EnergyLevel(ballCharge);

            sizeIncrement = Vector3.zero;
            ballCharge = 0;

            

        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == "Tile")
                {
                    targetObj = hitInfo.transform.gameObject.transform.position;
                }
            }
        }
    
        
       
        
    }



    public Vector3 ChargeBolt()
    {
        ballCharge += 1 / 10f;
        energyLevel -= 1 / 10f;
        sizeIncrement = new Vector3(ballCharge,ballCharge,ballCharge);
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
