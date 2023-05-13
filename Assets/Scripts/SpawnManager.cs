using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpawnManager : MonoBehaviour
{
    public static int totalEnemy = 40;

    public GameObject ball;

    public GameObject[] enemyList;
    public GameObject[] difficultEnemyList;
    public GameObject[] specialEnemyList;
    
    private InputDevice targetDevice;

    private bool b1 = false;
    private bool b2 = false;

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

        stageCountDown = 80f;
        index = 0;
        totalEnemy = 40;
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

        if (totalEnemy > 0)
        {
            if (cooldown <= 0 && stageCountDown > 0)
            {
                index = Random.Range(0, enemyList.Length);

                offset = new Vector3(0f, Random.Range(-0.5f, 0.5f), 0);
                Instantiate(enemyList[index], enemyList[index].transform.position + offset, enemyList[index].transform.rotation);
                cooldown = Random.Range(6, 8);
                PlayAudioFeedback();
                totalEnemy--;
            }

            if (cooldown <= 0 && stageCountDown <= 0)
            {
                index = Random.Range(0, difficultEnemyList.Length);
                offset = new Vector3(0f, Random.Range(-0.5f, 0.5f), 0);
                Instantiate(difficultEnemyList[index], difficultEnemyList[index].transform.position + offset, difficultEnemyList[index].transform.rotation);
                cooldown = Random.Range(5, 7);

                if (!b1 && totalEnemy == 11)
                {
                    Instantiate(specialEnemyList[0], specialEnemyList[0].transform.position + offset, specialEnemyList[0].transform.rotation);
                    b1 = true;
                }

                PlayAudioFeedback();
                totalEnemy--;
            }

            if (totalEnemy == 2)
            {

                offset = new Vector3(0f, Random.Range(-0.5f, 0.5f), 0);

                if (!b2)
                {
                    Instantiate(specialEnemyList[1], specialEnemyList[1].transform.position + offset, specialEnemyList[1].transform.rotation);
                    b2 = true;
                }
                PlayAudioFeedback();
                totalEnemy--;
            }
        }

        if (stageCountDown > 0)
        {
            stageCountDown -= Time.deltaTime;
        }
    }



    private void PlayAudioFeedback()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
