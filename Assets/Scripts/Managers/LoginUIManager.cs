using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginUIManager : MonoBehaviour
{
    public GameObject ConnectWithOption;
    public GameObject ConnectANON;
    // Start is called before the first frame update
    void Start()
    {
        ConnectWithOption.SetActive(true);
        ConnectANON.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
