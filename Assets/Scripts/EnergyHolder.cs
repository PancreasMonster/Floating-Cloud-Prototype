using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyHolder : MonoBehaviour
{
    public float energyLevel;
    private float startY;
    private float yDistTravelled;
    private Rigidbody rb;
    private float dist;
    private Vector3 targetDir;
    private float velocity;
    private Vector3 boltTarget;
    private float boltAngle;

  

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
       rb =  GetComponent<Rigidbody>();
        print(transform.position.x);
        print(transform.position.y);

        print(transform.position.z);

        //transform.Rotate(6.67f,0,0);
        

    }

    // Update is called once per frame
    void Update()
    {
        yDistTravelled = transform.position.y - startY;
        //transform.rotation = Quaternion.LookRotation()
        Vector3 offset = new Vector3 (45,0,0);
        transform.LookAt(BallisticVel(boltTarget, boltAngle));
        
    }

    public void EnergyLevel (float amount)
    {
        energyLevel = amount;
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Tile"))
        {
           col.gameObject.GetComponent<Energy>().energyLevel(energyLevel);
          
           Destroy(gameObject);
            
        }
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

    public void Target(Vector3 target, float angle)
    {
        boltTarget = target;
        boltAngle = angle;
    }

    
}
