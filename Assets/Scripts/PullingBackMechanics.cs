using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PullingBackMechanics : MonoBehaviour
{
    private InputDevice targetDevice;
    private Rigidbody rb;
    [SerializeField]
    private GameObject player;

    private Vector3 newVel;
    private Vector3 curVel;
    private float pullingSpeed;
    private float maxPull;
    private Vector3 offset;
    private Vector3 offset2;
    private float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("OVRPlayerController");

        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            
            targetDevice = devices[0];
        }

        rb = GetComponent<Rigidbody>();
        newVel = new Vector3();
        curVel = new Vector3();
        pullingSpeed = 18.0f;
        maxPull = 125f;
        offset = new Vector3(0.3f, -0.05f, -0.7f);
        offset2 = new Vector3(0.1f, -0.1f, 0.9f);
        maxSpeed = 18f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(OVRInput.GetConnectedControllers());
        //OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger)
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggervalue);
        
        if (triggervalue > 0.1f || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger)>0.01f)
        {
            
            if (pullingSpeed < maxPull)
            {
                pullingSpeed += 90f * Time.deltaTime;
            }    
            curVel = rb.velocity;
            //newVel = ((player.transform.position + offset) +  - transform.position).normalized;
            //rb.velocity = (curVel+newVel).normalized * pullingSpeed *Time.deltaTime;
            newVel = ((player.transform.position + offset)  -transform.position);
            
            rb.velocity = newVel * pullingSpeed * Time.deltaTime;
        }
        /*else if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.01f)
        {

            if (pullingSpeed < maxPull)
            {
                pullingSpeed += 100f * Time.deltaTime;
            }
            curVel = rb.velocity;
            
            newVel = ((player.transform.position + offset2) + -transform.position);

            rb.velocity = newVel * pullingSpeed * Time.deltaTime;
        }*/
        else
        {
            pullingSpeed = 18.0f;
        }

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
