using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneData : MonoBehaviour
{

    [SerializeField]
    private TMP_Text enemyKilled;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyKilled.SetText(EnergyCore.death + "");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
