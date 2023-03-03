using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDebugger : MonoBehaviour
{

    [SerializeField]

    private float maxVel = 20f;

    

    // Update is called once per frame
    private void Update()
    {
        GetComponent<Renderer>().material.color = ColorForVelocity();

    }

    private Color ColorForVelocity()
    {
        float vel = GetComponent<Rigidbody>().velocity.magnitude;
        return Color.Lerp(Color.green, Color.red, vel / maxVel);
    }
}
