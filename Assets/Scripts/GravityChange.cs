using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    private float timer;
    private bool change = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 20f;
        change = false;
        ball = GameObject.Find("ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (change && timer>0)
        {
            timer -= Time.deltaTime;
        }
        if(timer<=0)
        {
            change = false;
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<Rigidbody>().mass = 3f;
            timer = 20f;
        }
    }


    public void changeGravity(int index)
    {
        change = true;
        if(index == 1)
        {
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<Rigidbody>().mass = 1.5f;
        }
        else if (index == 2)
        {
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<PullingBackMechanics>().maxSpeed = 10f;
        }
    }
}
