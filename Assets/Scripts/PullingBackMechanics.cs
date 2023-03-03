using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PullingBackMechanics : MonoBehaviour
{
    private InputDevice targetDevice;
    private Rigidbody rb;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool buttondown);
        if (buttondown)
        {
            rb.velocity = (player.transform.position - transform.position) * 0.5f *Time.deltaTime;
        }


        rb.velocity = (player.transform.position - transform.position) * 5f * Time.deltaTime;
    }
}
