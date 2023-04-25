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
        pullingSpeed = 1.0f;
        maxPull = 1200f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(targetDevice);
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggervalue);
        
        if (triggervalue > 0.1f)
        {
            //Debug.Log("ssss");
            if (pullingSpeed < maxPull)
            {
                pullingSpeed += 400f * Time.deltaTime;
            }    
            curVel = rb.velocity;
            newVel = (player.transform.position - transform.position).normalized;
            rb.velocity = (curVel+newVel).normalized * pullingSpeed *Time.deltaTime;
        }


        
    }
}
