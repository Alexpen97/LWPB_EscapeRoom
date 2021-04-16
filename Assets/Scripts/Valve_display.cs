using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Valve_display : MonoBehaviour
{
    public Slider nutrient_display;
    public GameObject valve;
    public float offset_val;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(valve.transform.rotation.eulerAngles.z);
        if(valve.transform.rotation.eulerAngles.z > 10 && valve.transform.rotation.eulerAngles.z < 180) {
            subtract(); 
        }
        if(valve.transform.rotation.eulerAngles.z < 350 && valve.transform.rotation.eulerAngles.z > 180)
        {
            add();
        }
    }
    public void subtract()
    {
        nutrient_display.GetComponent<Slider>().value = nutrient_display.GetComponent<Slider>().value + offset_val;
    }
    public void add()
    {
        nutrient_display.GetComponent<Slider>().value = nutrient_display.GetComponent<Slider>().value - offset_val;
    }
}
