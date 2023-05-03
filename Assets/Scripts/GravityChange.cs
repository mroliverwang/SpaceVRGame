using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void changeGravity(int index)
    {
        if(index == 1)
        {
            ball.GetComponent<Rigidbody>().useGravity = true;
        }
        else if (index == 2)
        {
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<Rigidbody>().mass = 10f;
        }
    }
}
