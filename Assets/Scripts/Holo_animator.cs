using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holo_animator : MonoBehaviour
{
    public Animator Idle_animator;
    public Animator SOS_animation;
    public Animator HyperSpace;

    private bool IsIdle;
    // Start is called before the first frame update
    void Start()
    {
        IsIdle = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        Debug.Log("trigger enter");
        if (!IsIdle) { 
            Debug.Log("is false");
        if(other.tag == "Player")
        {
                Debug.Log("tag is player");
                IsIdle = true;
            Idle_animator.enabled = false;
            SOS_animation.enabled = true;
        }
    }
}
    public void EnterHyperspace()
    {
        HyperSpace.enabled = true;
    }
}
