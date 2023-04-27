using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 surfaceNormal;
    private Vector3 customUp;
    private Vector3 currentNormal;
    private Vector3 surfacen;
    private Vector3 currentForward;
    private float gravity = 10f;
    private float lerpSpeed = 10f;
    
    private GameObject target;
    private float damage = 5f;
    

    [SerializeField]
    private float attackCooldown = 2f;
    [SerializeField]
    private bool isAttacking;
    private bool isClimbing;
    

    // Start is called before the first frame update
    void Start()
    {
        surfacen = transform.up;
        currentNormal = transform.up;
        customUp = transform.up;
        currentForward = Vector3.forward;
        GetComponent<Rigidbody>().freezeRotation = true;
        isClimbing = false;
        isAttacking = false;       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moving
        if (!isAttacking)
        {
            //GetComponent<Rigidbody>().AddForce(-gravity * GetComponent<Rigidbody>().mass * currentNormal);
            transform.Translate(currentForward * Time.deltaTime);
        }


        //Climbing the energy core wall
        if (!isClimbing)
        {
            Ray ray;
            RaycastHit hit;
            //Debug.DrawRay(transform.position + transform.up, transform.forward);
            ray = new Ray(transform.position + transform.up, transform.forward);
            if (Physics.Raycast(ray, out hit, 0.5f))
            {
                if (hit.transform.tag == "SideWall") { 
                    isClimbing = true;
                    if (gameObject.name.Contains("right"))
                    {
                        transform.up = hit.normal;
                    }
                    else
                    {
                        transform.up = hit.normal;
                        transform.Rotate(new Vector3(0, 180, 0));
                    }
                }
            }
        }


        attackCooldown -= Time.deltaTime;
        if (isAttacking && attackCooldown <=0 &&target!= null)
        {
            attack(target);
            attackCooldown = 2.0f;
            //GetComponent<Animator>().SetBool("isAttacking", false);
        }
        
























        /*
        Debug.DrawRay(transform.position, -transform.up);
         ray = new Ray(transform.position, -transform.up);
         if (Physics.Raycast(ray, out hit, 1f))
         {
             if (!isClimbing)
             {

                 currentForward = Quaternion.AngleAxis(-90, currentNormal) * Vector3.Cross(transform.right, currentNormal);
             }
         }
         else
         {

             Debug.Log("ssssssss");
             isClimbing = false;
             //transform.up = customUp;

         }
             surfacen = hit.normal;
             currentNormal = Vector3.Lerp(currentNormal, surfacen, lerpSpeed * Time.deltaTime);
             Quaternion targetRot = Quaternion.LookRotation(transform.forward, currentNormal);
             transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, lerpSpeed * Time.deltaTime);
         //currentNormal = Vector3.Lerp(currentNormal, surfacen, lerpSpeed * Time.deltaTime);
         //currentNormal = transform.up;
         //currentForward = transform.forward; Quaternion.AngleAxis(-90, currentNormal) *


         //currentForward = Quaternion.AngleAxis(-90, currentNormal) * Vector3.Cross(transform.right, currentNormal);
         */


    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "EnergyCore" && !isAttacking)
        {
            isAttacking = true;
            target = collision.gameObject;
            
        }
    }

    private void attack(GameObject target) {
        Debug.Log("attacking!!!!");
        GetComponent<Animator>().SetBool("isAttacking", true);
        target.GetComponent<EnergyCore>().damaged(damage);
    }
}
