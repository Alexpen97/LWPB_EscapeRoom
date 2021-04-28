using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ChargingPortScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){

        GameObject go=collision.gameObject;

        // if it is an empty powercell, put it in the right position and charge it.
        if(go.tag.Equals("powercell")){
            if(go.GetComponent<powercell_script>().cellState==CellState.EMPTY){
                chargeCell(go);
            }
        }
    }

    void chargeCell(GameObject go){
        //var grabi= go.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
        var rigi = go.GetComponent<Rigidbody>();
        rigi.isKinematic=true;

        go.transform.SetPositionAndRotation(this.transform.position,this.transform.rotation);
        go.GetComponent<powercell_script>().switchState(CellState.CHARGING);
    }
}
