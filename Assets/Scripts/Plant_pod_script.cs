using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Plant_pod_script : MonoBehaviour
{
    public List<GameObject> plant_prefabs;
    public string plantName;

    [Range(0, 100)]
    public int target_oxygen;
    [Range(0, 100)]
    public int target_water;
    [Range(0, 100)]
    public int target_nutrient;

    public Slider oxygen_current;
    public Slider water_current;
    public Slider nutrient_current;

    public bool oxygen;
    public bool water;
    public bool nutrient;

    public bool onfire;

    public bool Nutrients_balanced;

    [Range(0, 100)]
    public int broken_pod_chance;

    public GameObject plant_placeholder;
    public GameObject fire_placeholder;
    public GameObject barcode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*Nutrient balance checking
         * this part of code checks if the nutrients are correctly balanced
         */
         //oxygen
        if ((oxygen_current.value * 100) > (target_oxygen - 5))
        {
            if ((oxygen_current.value * 100) < (target_oxygen + 5))
            {
                oxygen = true;
            }
            else
            {
                oxygen = false;
            }
        }
        else
        {
            oxygen = false;
        }
        //water
             if ((water_current.value * 100) > (target_water - 5))
        {
            if ((water_current.value * 100) < (target_water + 5))
            {
                water = true;
            }
            else
            {
                water = false;
            }
        }
        else
        {
            water = false;
        }
             //nutrients

        if ((nutrient_current.value * 100) > (target_nutrient - 5))
        {
            if ((nutrient_current.value * 100) < (target_nutrient + 5))
            {
                nutrient = true;
            }
            else
            {
                nutrient = false;
            }
        }
        else
        {
            nutrient = false;
        }

        if (nutrient && water && oxygen)
        {
            Nutrients_balanced = true;
        }
        else
        {
            Nutrients_balanced = false;
        }

        if (onfire)
        {
            fire_placeholder.active = true;
        }
        else
        {
            fire_placeholder.active = false;
        }

    }
    public void spawnPlant()
    {
        GameObject.Destroy(plant_placeholder.transform.GetChild(0).gameObject);
        GameObject newplant = Instantiate(plant_prefabs[Random.Range(0, plant_prefabs.Count)],plant_placeholder.transform);
        newplant.transform.localPosition = new Vector3(0, 0, 0);
        newplant.transform.parent = plant_placeholder.transform;

        barcode.GetComponent<Barcode>().Code_value = plantName;

        int chance = Random.Range(0, 100);

        if (broken_pod_chance > chance)
        {
            oxygen_current.value = Random.Range(0.0f, 1.0f);
            water_current.value = Random.Range(0.0f, 1.0f);
            nutrient_current.value = Random.Range(0.0f, 1.0f);
            if(Random.Range(0, 100) < 25)
            {
             onfire = true;
            }
            
        }

    }
}
