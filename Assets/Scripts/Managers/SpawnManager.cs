using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject PlayerObject;

    public Vector3 SpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(PlayerObject.name, SpawnPos,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
