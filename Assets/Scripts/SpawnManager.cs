using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpawnManager : MonoBehaviour
{
    public GameObject ball;
    private InputDevice targetDevice;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
        }

        cooldown = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttondown);
        if (Input.GetKeyDown(KeyCode.Tab) & cooldown <=0 )
        {
            Instantiate(ball, ball.transform.position, ball.transform.rotation);
            cooldown = 2f;
        }
        if (buttondown & cooldown <= 0)
        {
            Instantiate(ball, ball.transform.position, ball.transform.rotation);
            cooldown = 2f;
        }

        cooldown -= 1.5f * Time.deltaTime;
    }
}
