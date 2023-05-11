using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneData : MonoBehaviour
{

    [SerializeField]
    private TMP_Text enemyKilled;

    [SerializeField]
    private TMP_Text crystalDmg;
    [SerializeField]
    private TMP_Text time;

    // Start is called before the first frame update
    void Start()
    {
        enemyKilled.SetText(EnergyCore.death + "");
        crystalDmg.SetText((100 - EnergyCore.health) + "%");
        time.SetText((int)EnergyCore.gameTime + "s");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
