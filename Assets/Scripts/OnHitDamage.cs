using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDamage : MonoBehaviour
{
    [SerializeField]
    private int health;
    private int gravityType = 0;
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
            health = 2;
        }
        else if (gameObject.name.Contains("spike"))
        {
            health = 1;
        }
        else if (gameObject.name.Contains("spider"))
        {
            health = 1;
        }
        else if (gameObject.name.Contains("gravity1"))
        {
            health = 1;
            gravityType = 1;
        }
        else if (gameObject.name.Contains("gravity2"))
        {
            health = 1;
            gravityType = 2;
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

            other.gameObject.GetComponent<MagneticBall>().hit = 0;

            if (health > 0)
            {
                GetComponent<Animator>().SetBool("isDamaged", true);
                health -= 1;


                GetComponentInChildren<Light>().color = Color.yellow;



                if (health <= 0)
                {
                    GetComponent<Animator>().SetBool("death", true);
                    PlayAudioFeedback();

                    energyCore.GetComponent<EnergyCore>().addDeath();

                    if (GetComponent<GravityChange>() != null)
                    {
                        GetComponent<GravityChange>().changeGravity(gravityType);
                    }


                }
            }
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
