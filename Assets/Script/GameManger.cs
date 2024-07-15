using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject currentCheckpoint;
    [SerializeField]private GameObject Player;
    public int PlayerTries;
    [HideInInspector] public bool Died;
    public GameObject[] Hearts;
    void Start()
    {
        PlayerTries = 3;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Hearts = GameObject.FindGameObjectsWithTag("Heart");
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
        if (PlayerTries < Hearts.Length) 
        {
            Destroy(Hearts[Hearts.Length - 1]);
        }
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(1);
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
