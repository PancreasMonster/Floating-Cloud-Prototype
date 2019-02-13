using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{

    public float energy, maxEnergy, energyRecharge;
    TextMesh text;
    bool dead;
    public LayerMask layer;
    public List<Light> lights = new List<Light>();
    Color original;
    bool target1, target2;
    //Light[] light;

    Vector3 originalScale;
    public GameObject cloudMesh;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMesh>();
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = transform.position;
        cube.gameObject.layer = 5;
        foreach (Light l in GetComponentsInChildren<Light>())
        {
            lights.Add(l);
        }
        original = lights[1].color;
        originalScale = cloudMesh.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        cloudMesh.transform.localScale = new Vector3(Mathf.Clamp(originalScale.x * (energy / maxEnergy), originalScale.x / 2, originalScale.x), 
            Mathf.Clamp(originalScale.y * (energy / maxEnergy), originalScale.y / 2, originalScale.y), 
            Mathf.Clamp(originalScale.z * (energy / maxEnergy), originalScale.z / 2, originalScale.z));
        //cloudMesh.transform.localScale = originalScale * energy / maxEnergy * 2;
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
                cloudMesh.AddComponent<Rigidbody>();
            }
            Destroy(this.gameObject, 4);
        }

        if (!dead && text != null)
        text.text = (Mathf.RoundToInt(energy)).ToString();
        else
        {
            if (text != null)
            text.text = "";
        }
        //print(energy);

        RaycastHit hit;

        Debug.DrawRay(transform.position, Vector3.up * 1, Color.yellow);

        if (Physics.Raycast(transform.position, Vector3.up, out hit, 1, layer))
        {
            foreach (Light l in lights)
            {
                if (hit.transform.name == "TargetPlayer1")                
                l.color = new Color(.2f, .6f, .2f);
                if (hit.transform.name == "TargetPlayer2")
                    l.color = new Color(.2f, .2f, .6f);
                l.intensity = 5;
            }
        } else
        {
            foreach (Light l in lights)
            {
                l.color = original;
                l.intensity = 1;
            }
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
