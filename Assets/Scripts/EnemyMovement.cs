using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 surfaceNormal;
    private Vector3 currentNormal;
    private Vector3 currentForward;
    private float gravity = 10f;



    // Start is called before the first frame update
    void Start()
    {
        currentNormal = transform.up;
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(-gravity * GetComponent<Rigidbody>().mass * currentNormal);

        //currentForward = 
        transform.Translate(Vector3.forward * Time.deltaTime);


    }
}
