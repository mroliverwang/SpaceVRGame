using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFollower : MonoBehaviour
{

    private BatCube batFollower;
    private Rigidbody rb;
    private Vector3 velocity;

    [SerializeField]
    private float _sensitivity = 96f;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 destination = batFollower.transform.position;
        rb.transform.rotation = transform.rotation;
        velocity = (destination - rb.transform.position) * _sensitivity;
        rb.velocity = velocity;
        transform.rotation = batFollower.transform.rotation;
    }

    public void SetFollowTarget(BatCube bf)
    {
        batFollower = bf;
    }
}
