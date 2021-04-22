using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powercell_script : MonoBehaviour
{
    // charge indicator object and chargespeed variable
    public GameObject chargeObject;
    public float chargeSpeed = 0.25f;

    public CellState cellState = CellState.FULL;


    // the current charge value.
    private float charge = 0f;
    private float chargeh = 0f;
    
    private const float EMPTYCHARGE=16.2147f;
    private const float FULLCHARGE=87.2531f;

    

    // Start is called before the first frame update
    void Start()
    {
        // set charge to correct base value.
        switchState(cellState);
    }

    public void switchState(CellState state){
        Debug.Log("CELL changed state: "+cellState.ToString()+">>"+state.ToString());
        cellState=state;

        switch(cellState){
            case(CellState.EMPTY):
                chargeh=EMPTYCHARGE;
                setScaleY(chargeh);

            break;

            case(CellState.CHARGING):
                chargeh+= Time.deltaTime * chargeSpeed;
                setScaleY(chargeh);

            break;

            default:
            case(CellState.FULL):
                chargeh=FULLCHARGE;
                setScaleY(chargeh);

            break;
        }
    }

    // Update is called once per frame
    void Update(){
        // update the TEXTURE, not the charging itself.
        charge+= Time.deltaTime * chargeSpeed;
        chargeObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, charge));

        // switch to state FULL if charging is complete.
        if(cellState==CellState.CHARGING){

            chargeh+= Time.deltaTime * chargeSpeed * (FULLCHARGE-EMPTYCHARGE);
            setScaleY(chargeh);

            if(chargeh>=FULLCHARGE)
                switchState(CellState.FULL);
        }
    }

    private void setScaleY(float newY){
        Vector3 old =chargeObject.transform.localScale;
        chargeObject.transform.localScale= new Vector3(old.x, newY, old.z);
    }

}

public enum CellState {
    EMPTY, CHARGING, FULL
};

/*
public class powercell_script : MonoBehaviour
{
    // charge indicator object and chargespeed variable
    public GameObject chargeObject;
    public float chargeSpeed = 0.25f;

    public CellState cellState = CellState.FULL;


    // the current charge value.
    private float charge = 0f;
    
    private const float EMPTYCHARGE=0;//16.2147f;
    private const float FULLCHARGE=87.2531f;

    

    // Start is called before the first frame update
    void Start()
    {
        // set charge to correct base value.
        updateCharge(cellState, charge);
    }

    // Update is called once per frame
    void Update()
    {

        switch(cellState){
            case(CellState.EMPTY):
                UpdateEmpty();
            break;

            case(CellState.CHARGING):
                UpdateCharging();
            break;

            default:
            case(CellState.FULL):
                UpdateFull();
            break;
        }
    }

    void UpdateEmpty(){}
    void UpdateCharging(){
        charge+= Time.deltaTime * chargeSpeed;
        updateCharge(cellState, charge);
    }
    void UpdateFull(){}

    
    void updateCharge(CellState newstate, float newcharge){
        CellState oldstate=newstate;

        if(newstate==CellState.EMPTY || newcharge <= EMPTYCHARGE ) newcharge=EMPTYCHARGE;
        if(newstate==CellState.FULL  || newcharge >= FULLCHARGE  ) newcharge=FULLCHARGE;
        
        if(cellState!=CellState.CHARGING){
            chargeObject.GetComponent<Animation>().enabled=false;
            //chargeObject.GetComponent<Animation>()[].normalizedTime
        }else{
            chargeObject.GetComponent<Animation>().Stop();
            if()
            chargeObject.GetComponent<Animation>()
        }
        
        chargeObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, charge));
       //chargeObject.GetComponent<Animation>().enabled=false;

        cellState=newstate;
        charge=newcharge;

        if(oldstate!=newstate) Debug.Log("Cell changed state: "+newstate);
        else Debug.Log("diff:" + (FULLCHARGE-newcharge));
    }
}

public enum CellState {
    EMPTY, CHARGING, FULL
};
*/