using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EnergyCore : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;
    [SerializeField]
    private GameObject lights;
    [SerializeField]
    private Gradient gradient;

    [SerializeField]
    private TMP_Text scoreboard;
    [SerializeField]
    private TMP_Text killed;

    private int death;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        death = 0;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        scoreboard.SetText(health + "" );
        killed.SetText(death + "");
    }


    public void damaged(float damage)
    {
        health -= damage;
        lights.GetComponent<Light>().color = gradient.Evaluate(health / 100);


        
    }

    public void addDeath()
    {
        death++;
    }
}
