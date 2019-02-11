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
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = transform.position;
        cube.gameObject.layer = 5;
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

        if (!dead)
        text.text = energy.ToString();
        else
        {
            text.text = "";
        }
    }

    public void energyLevel(float amount)
    {
        energy -= amount;
    }

    public void drainEnergy (float amount)
    {
        float reduction = Mathf.Floor(amount * energy);
        energy -= reduction;
        //Debug.Log(reduction);
    } 
}
