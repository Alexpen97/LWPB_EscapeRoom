using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve_script : MonoBehaviour
{

    public void reset_valve()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
        transform.localScale = new Vector3(1, 1, 1);
    }
}
