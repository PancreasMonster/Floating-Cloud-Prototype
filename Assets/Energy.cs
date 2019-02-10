using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{

    public float energy, maxEnergy, energyRecharge; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (energy < maxEnergy)
        {
            energy += energyRecharge * Time.deltaTime;
        }
      if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }

      if (energy <= 0)
        {
            gameObject.AddComponent<Rigidbody>();
            Destroy(this.gameObject, 4);
        }
    }

    public float energyLevel()
    {
        return 0;

    }
}
