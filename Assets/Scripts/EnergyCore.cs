using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class EnergyCore : MonoBehaviour
{
    [SerializeField]
    public static float health = 100f;
    [SerializeField]
    private GameObject lights;
    [SerializeField]
    private Gradient gradient;

    [SerializeField]
    private TMP_Text scoreboard;
    [SerializeField]
    private TMP_Text killed;
    [SerializeField]
    private TMP_Text totalenemy;

    public static int death;

    public static int enemyNearby = 0;

    private float cd;

    public static float gameTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        death = 0;
        cd = 5f;
        enemyNearby = 0;
        gameTime = 0;
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        scoreboard.SetText(health + "" );
        killed.SetText(death + "");
        totalenemy.SetText(SpawnManager.totalEnemy + "");

        cd -= Time.deltaTime;


        if(health < 0)
        {           
            SceneManager.LoadScene("EndScene");
        }

        if (death == 60)
        {
            SceneManager.LoadScene("WinScene");
        }



        if (enemyNearby == 1 && cd < 0)
        {
            PlayAudioFeedback();
            cd = 5f;
        }

        gameTime += Time.deltaTime;
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


    private void PlayAudioFeedback()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
