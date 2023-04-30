using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BatFollower : MonoBehaviour
{

    private BatCube batFollower;
    private Rigidbody rb;
    private Vector3 velocity;

    [SerializeField] private OVRInput.Controller controller; // Assign the appropriate controller (LTouch or RTouch)
    [SerializeField] private float hapticDuration = 0.2f; // Duration of the haptic feedback (in seconds)
    [SerializeField] private float hapticFrequency = 320.0f; // Haptic feedback frequency (in Hz)
    [SerializeField] private float hapticAmplitude = 0.8f; // Haptic feedback amplitude (0.0 to 1.0)

    [SerializeField]
    private float _sensitivity = 96f;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _sensitivity = 100f;
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



    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "ball") 
        {
            OVRInput.SetControllerVibration(hapticFrequency, hapticAmplitude, controller);
            StartCoroutine(StopVibrationAfterDelay(hapticDuration));
        }
    }

    private IEnumerator StopVibrationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        OVRInput.SetControllerVibration(0, 0, controller);
    }


}





   

    
