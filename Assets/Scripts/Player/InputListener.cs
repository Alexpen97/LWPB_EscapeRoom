using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    List<InputDevice> inputDevices;
    InputDeviceCharacteristics inputDeviceCharacteristics;

   public GameObject leftHandController;
   public GameObject rightHandController;
    public GameObject nerfdart;

    private void Awake()
    {
        inputDevices = new List<InputDevice>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputDeviceCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right;
        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, inputDevices);

       

        foreach (InputDevice inputDevice in inputDevices)
        {
            bool inputvalue;
            if (inputDevice.TryGetFeatureValue(CommonUsages.triggerButton,out inputvalue) && inputvalue )
            {
                Debug.Log("trigger");
        if(leftHandController.GetComponent<InHandListener>().HeldObject != null) { }
        if(rightHandController.GetComponent<InHandListener>().HeldObject != null) {
                    Debug.Log("holding an object");
                if(rightHandController.GetComponent<InHandListener>().HeldObject.tag == "gun")
                    {
                        Debug.Log("fire");
                        Instantiate(nerfdart, rightHandController.GetComponent<InHandListener>().HeldObject.transform.Find("barrel").position, rightHandController.GetComponent<InHandListener>().HeldObject.transform.rotation);
                    }
                
                }

            }

        }
    }
}
