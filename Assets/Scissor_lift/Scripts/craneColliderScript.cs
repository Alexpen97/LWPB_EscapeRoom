using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craneColliderScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("je raak me aan");
    }
}
