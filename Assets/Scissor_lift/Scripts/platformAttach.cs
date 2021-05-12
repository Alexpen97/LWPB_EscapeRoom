﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformAttach : MonoBehaviour
{

    public GameObject vrPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            vrPlayer.transform.parent = transform;
            print("ben ik er op");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            vrPlayer.transform.parent = null;
            print("ben ik er van af");
        }
    }


}
