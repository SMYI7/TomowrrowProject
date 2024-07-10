using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject currentCheckpoint;
    [SerializeField]private GameObject Player;
    public int PlayerTries;
    [HideInInspector] public bool Died;
    void Start()
    {
        PlayerTries = 3;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Died)
        {
            if (PlayerTries > 0)
            {
                PlayerTries--;
                Player.transform.position = currentCheckpoint.transform.position;
                Died = false;
            }
            else 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            } 
        }
    }
}
