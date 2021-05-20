using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public int cellsNeeded=1;
    public float moveInTime=4f;

    public GameObject hatch;

    // Start is called before the first frame update
    void Start(){
        this.GetComponent<LigthScript>().DisableLights();
        hatch.GetComponent<HatchScript>().openHatch();
    }

    
    void OnCollisionEnter(Collision collision){
        if(cellsNeeded<=0) return;

        GameObject go=collision.gameObject;

        // check for full powercell
        if(go.tag.Equals("powercell")){
            if(go.GetComponent<powercell_script>().cellState==CellState.FULL){
                takeCell(go);
            }
        }
    }

    GameObject currentCell;

    void takeCell(GameObject powercell){

        if(powercell==currentCell) return;

        if(currentCell!=null){
            // destroy the cell
            Destroy(currentCell);
            currentCell=null;
        }
        
        currentCell=powercell;

        Debug.Log("Taking cell...");

        // remove from hands
        currentCell.transform.parent=null;

        // make ungrabbable
        var grabi = currentCell.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
        grabi.interactionLayerMask=0; // make ungrabbable
        grabi.enabled=false;
        Destroy(grabi,0f);

        // make unmovable
        var rigi = currentCell.GetComponent<Rigidbody>();
        rigi.isKinematic=true;
        rigi.useGravity=false;
        rigi.freezeRotation=true;
        Destroy(rigi,0f);

        // set relative to the generator
        currentCell.transform.parent=gameObject.transform;

        // Snap to position and rotation
        currentCell.transform.localPosition=new Vector3(0f,0.645f,-0.7f);
        currentCell.transform.localEulerAngles=new Vector3(-90f,0f,0f);
    }

    // Update is called once per frame
    // if there is a current cell, it should move its relative Z position from -0.7 to 0.5 in about 4 seconds.
    void Update(){
        if(currentCell==null|| (currentCell.transform.localPosition.z >=0.5) ) return;
        
        Vector3 transform=currentCell.transform.localPosition;

        // Z movement: 1.2 meter over moveInTime seconds
        transform.z += 1.2f / moveInTime * Time.deltaTime;

        currentCell.transform.localPosition=transform;

        if(transform.z>=0.5) cellTaken();
    }

    // called when the powercell is fully inside the generator.
    void cellTaken(){

        Debug.Log("Cell taken, "+ (cellsNeeded-1) + " cells remaining");

        // if all the cells are inserted, start the generator.
        cellsNeeded--;
        if(cellsNeeded<=0) powerup();
    }


    void powerup(){
        this.GetComponent<LigthScript>().EnableLights();

        hatch.GetComponent<HatchScript>().closeHatch();
        // TODO activate sound
    }

}