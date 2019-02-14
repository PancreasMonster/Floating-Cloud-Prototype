using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyHolder : MonoBehaviour
{
    public float energyLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            GameObject ps = col.gameObject.transform.GetChild(5).gameObject;
            ps.SetActive(true);
           Destroy(gameObject);
            
        }
    }
}
