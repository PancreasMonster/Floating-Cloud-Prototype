using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{

    public float energy, maxEnergy, energyRecharge;
    TextMesh text; 
    bool dead;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMesh>();
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
            if (!dead)
            {
                gameObject.AddComponent<Rigidbody>();
                dead = true;
            }
            Destroy(this.gameObject, 4);
        }

        text.text = energy.ToString();
    }

    public void energyLevel(float amount)
    {
        energy -= amount;
    }
}
