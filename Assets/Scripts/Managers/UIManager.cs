﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject UI_VRMenuGameObject;
    // Start is called before the first frame update
    void Start()
    {
      //  UI_VRMenuGameObject.SetActive(false);
    }

    public void OnWorldButtonClicked()
    {
        Debug.Log("worlds is clicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
