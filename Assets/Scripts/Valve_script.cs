﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve_script : MonoBehaviour
{
  
    private bool grabbed;
    public void reset_valve()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
        transform.localScale = new Vector3(0.07f, 0.1f, 0.02f);
    }

}
