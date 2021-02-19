using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_nerf : MonoBehaviour
{
    private bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 10.0f;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        move = false;
    }
}
