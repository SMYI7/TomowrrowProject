using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddCoin : MonoBehaviour
{
    [SerializeField] int coinNum;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<Inventory>().AddBattery(coinNum);
                Destroy(gameObject);
            }
        }
    }
}
