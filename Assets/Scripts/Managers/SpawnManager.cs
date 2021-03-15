using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject PlayerObject;

    public List<GameObject> Spawnpos;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(PlayerObject.name, Spawnpos[CheckPlayerCount()].transform.position,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private int CheckPlayerCount()
    {
        return PhotonNetwork.CountOfPlayers;
    }
}
