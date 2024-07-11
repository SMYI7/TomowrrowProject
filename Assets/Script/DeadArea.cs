using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                GameObject.FindGameObjectWithTag("GameManger").GetComponent<GameManger>().Died = true;
            }
        }
    }
}
