using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  
    private Vector3 currentForward;
    
    
    private GameObject target;
    private float damage = 5f;
    

    [SerializeField]
    private float attackCooldown = 4f;
    [SerializeField]
    private bool isAttacking;
    private bool isClimbing;


    private float moveSpeed = 1f;

    private Vector3 offset;
    
    void Start()
    {
        /*surfacen = transform.up;
        currentNormal = transform.up;
        customUp = transform.up;*/
        currentForward = Vector3.forward;
        GetComponent<Rigidbody>().freezeRotation = true;
        isClimbing = false;
        isAttacking = false;

        if (gameObject.name.Contains("razor"))
        {
            moveSpeed = 1f;
            damage = 1f;
        }
        else if (gameObject.name.Contains("shell"))
        {
            moveSpeed = 0.1f;
            damage = 5f;
        }
        else if (gameObject.name.Contains("spike"))
        {
            moveSpeed = 0.2f;
            damage = 2f;
        }
        else if (gameObject.name.Contains("spider"))
        {
            moveSpeed = 0.5f;
            damage = 1f;
        }
        else if (gameObject.name.Contains("gravity"))
        {
            moveSpeed = 0.15f;
            damage = 0f;
        }
        offset = new Vector3(0.5f, 0, 0);
    }



    
    void FixedUpdate()
    {
        //Moving
        if (!isAttacking)
        {
            if (gameObject.name.Contains("razor"))
            {
                transform.Translate(currentForward * moveSpeed * Time.deltaTime);
            }
            else if (gameObject.name.Contains("shell"))
            {
                transform.Translate(currentForward * moveSpeed * Time.deltaTime);
            }
            else if (gameObject.name.Contains("spike"))
            {
                transform.Translate(currentForward * moveSpeed * Time.deltaTime);
                transform.Translate(offset * 0.04f*Mathf.Sin(4f*Time.time));
            }
            else if (gameObject.name.Contains("spider"))
            {
                transform.Translate(currentForward *moveSpeed * Time.deltaTime);
            }
            else if (gameObject.name.Contains("gravity"))
            {
                transform.Translate(currentForward * moveSpeed * Time.deltaTime);
            }

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
                    EnergyCore.enemyNearby = 1;
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
            attackCooldown = 4.0f;
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
        
        GetComponent<Animator>().SetBool("isAttacking", true);
        target.GetComponent<EnergyCore>().damaged(damage);
    }
}
