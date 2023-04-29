using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpawnManager : MonoBehaviour
{
    public GameObject ball;

    public GameObject[] enemyList;
    public GameObject[] difficultEnemyList;
    
    private InputDevice targetDevice;



    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float stageCountDown;
    [SerializeField]
    private int index;

    private Vector3 offset;

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

        cooldown = 7f;

        stageCountDown = 200f;
        index = 0;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
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
        }*/

        cooldown -=   Time.deltaTime;
        stageCountDown -= Time.deltaTime;


        if(cooldown <= 0 && stageCountDown > 0)
        {
            index = Random.Range(0, enemyList.Length);

            offset = new Vector3(0f, Random.Range(-0.5f, 0.5f), 0);
            Instantiate(enemyList[index], enemyList[index].transform.position + offset, enemyList[index].transform.rotation);
            cooldown = Random.Range(16,21);
        }

        if (cooldown <= 0 && stageCountDown <= 0)
        {
            index = Random.Range(0, difficultEnemyList.Length);
            offset = new Vector3(0f, Random.Range(-0.5f, 0.5f), 0);
            Instantiate(difficultEnemyList[index], difficultEnemyList[index].transform.position + offset, difficultEnemyList[index].transform.rotation);
            cooldown = Random.Range(16, 18);
        }

        if (stageCountDown > 0)
        {
            stageCountDown -= Time.deltaTime;
        }
    }
}
