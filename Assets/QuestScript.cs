using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    [SerializeField] GameManger gm;
    [SerializeField] RTLTextMeshPro coins;
    [SerializeField] RTLTextMeshPro enemies;

    
    
    void Start()
    {
        coins.text = (gm.coinsCount * 3).ToString();
        enemies.text = gm.EnemiesCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
