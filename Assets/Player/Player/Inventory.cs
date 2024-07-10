using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Coins;
    public RTLTextMeshPro scoreText;

    private void Update()
    {
        scoreText.text = "عملاتك : " + Coins;
        Debug.Log(scoreText.text);
    }
    public void AddBattery(int score)
    {
        Coins += score;
    }
    
}
