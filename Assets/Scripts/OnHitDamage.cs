using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDamage : MonoBehaviour
{
    private int health;
    private GameObject energyCore;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Contains("razor"))
        {
            health = 1;
        }
        else if (gameObject.name.Contains("shell"))
        {
            health = 3;
        }
        else if (gameObject.name.Contains("spike"))
        {
            health = 1;
        }
        else if (gameObject.name.Contains("spider"))
        {
            health = 1;
        }
        energyCore = GameObject.Find("EnergyCore");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "ball")
        {
            if (health > 0)
            {
                GetComponent<Animator>().SetBool("isDamaged", true);
                health -= 1;
                if (health <= 0)
                {
                    GetComponent<Animator>().SetBool("death", true);
                    energyCore.GetComponent<EnergyCore>().addDeath(); ;
                }
            }
        }
    }
    
}
