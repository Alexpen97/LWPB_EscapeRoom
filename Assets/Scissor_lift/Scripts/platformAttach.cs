using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformAttach : MonoBehaviour
{

    public GameObject vrPlayer;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == vrPlayer)
        {
            vrPlayer.transform.parent = transform;
            print("ben ik er van af");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == vrPlayer)
        {
            vrPlayer.transform.parent = null;
            print("ben ik er van af");
        }
    }


}
