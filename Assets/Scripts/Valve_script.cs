using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve_script : MonoBehaviour
{
    private bool Rotate;
    private GameObject playerHand;
    // Start is called before the first frame update
    void Start()
    {
        Rotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Rotate)
        {
            Vector3 eulerRotation = new Vector3(0, 0, playerHand.transform.eulerAngles.z);

            transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }

    public void rotate_valve()
    {
        Rotate = true;
    }
    public void reset_valve()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        playerHand = collision.gameObject;
    }
    public void OnCollisionExit(Collision collision)
    {
        playerHand = null; 
    }
}
