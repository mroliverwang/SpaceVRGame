using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCore : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;
    [SerializeField]
    private GameObject lights;
    [SerializeField]
    private Gradient gradient;



    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void damaged(float damage)
    {
        health -= damage;
        lights.GetComponent<Light>().color = gradient.Evaluate(health / 100);


        
    }
}
