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
    bool target1, target2, draining;
    //Light[] light;
    MeshRenderer rend;
    Color c;

    Vector3 originalScale;
    public GameObject cloudMesh;

    public Material Energy20;
    public Material Energy40;
    public Material Energy50;

    private Vector3 largeLightningPos;
    private GameObject LargeLightning;
    
        


    // Start is called before the first frame update
    void Start()
    {
        largeLightningPos = transform.GetChild(6).gameObject.transform.position;
        LargeLightning = transform.GetChild(6).gameObject;
        rend = cloudMesh.GetComponent<MeshRenderer>();
        c = cloudMesh.GetComponent<MeshRenderer>().material.color;
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
        cloudMesh.transform.localScale = new Vector3(Mathf.Clamp(originalScale.x * (energy / maxEnergy), 3 * (originalScale.x/10), originalScale.x),
            Mathf.Clamp(originalScale.y * (energy / maxEnergy), 3 * (originalScale.x / 10), originalScale.y),
            Mathf.Clamp(originalScale.z * (energy / maxEnergy), 3 * (originalScale.x / 10), originalScale.z));
        //cloudMesh.transform.localScale = originalScale * energy / maxEnergy * 2;
        if (!draining) { 
        if (energy < maxEnergy)
        {
            energy += energyRecharge * Time.deltaTime;
        }

        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
    }

        if (energy <= 0)
        {
            if (!dead)
            {
                gameObject.AddComponent<Rigidbody>();
                dead = true;
                cloudMesh.AddComponent<Rigidbody>();
                
                
                LargeLightning.SetActive(true);

            }
            
            Destroy(this.gameObject, 4);
        }
        LargeLightning.transform.position = largeLightningPos;
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

        if (energy > 40)
            rend.sharedMaterial.color = Color.Lerp(rend.sharedMaterial.color, Energy20.color, .5f * Time.deltaTime);
        else if (energy > 20)
        {
            rend.sharedMaterial.color = Color.Lerp(rend.sharedMaterial.color, Energy40.color, .5f * Time.deltaTime);
        }
        else
        {
            rend.sharedMaterial.color = Color.Lerp(rend.sharedMaterial.color, Energy50.color, .5f * Time.deltaTime);
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

    public void startDraining ()
    {
        draining = true;
    }

    public void stopDraining()
    {
        draining = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Bolt"))
        {
            GameObject ps = transform.GetChild(5).gameObject;
            ps.SetActive(false);
            ps.SetActive(true);
            //Invoke("DisablePS", 4);
            
            
        }

    }


    void DisablePS()
    {
        GameObject ps = transform.GetChild(5).gameObject;
        ps.SetActive(false);
    }
}
