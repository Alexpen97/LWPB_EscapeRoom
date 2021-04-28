using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Plant_pods_controller : MonoBehaviour
{
    public Plants23 Plant_DB;

    private Plant_pod_script[] podscripts;
    void Start()
    {
        podscripts = gameObject.GetComponentsInChildren<Plant_pod_script>();
        PopulatePlantPods();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PopulatePlantPods()
    {
        foreach (Plant_pod_script pod_Script in podscripts)
        {
            int selectionNumber = (int)pod_Script.plant_selection;
            pod_Script.plant_prefabs = Plant_DB.PlantPorperties[selectionNumber].plant_prefabs;
            pod_Script.plantName = Plant_DB.PlantPorperties[selectionNumber].dropDown.ToString().Replace("_"," ");
            pod_Script.target_oxygen = Plant_DB.PlantPorperties[selectionNumber].oxygen;
            pod_Script.target_water = Plant_DB.PlantPorperties[selectionNumber].water;
            pod_Script.target_nutrient = Plant_DB.PlantPorperties[selectionNumber].nutrient;
            pod_Script.spawnPlant();
        }
       
    }

}

