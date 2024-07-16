using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public GameObject currentCheckpoint;
    [SerializeField]private GameObject Player;
    public int PlayerTries;
    [HideInInspector] public bool Died;
    public GameObject[] Hearts;
    public int coinsCount;
    public int EnemiesCount;
    public bool isPaused;
    public Canvas PauseCanve;
    public UnityEvent onPause;
    public UnityEvent onNotPause;
    private void Awake()
    {
        PlayerTries = 3;
        Player = GameObject.FindGameObjectWithTag("Player");
        coinsCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        EnemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    void Start()
    {
        PlayerInput _input = new PlayerInput();
        _input.Enable();
        _input.Gamplay.PauseButton.performed += PauseFunc;
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
    public void PauseFunc(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            onPause?.Invoke();
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            onNotPause?.Invoke();
            Time.timeScale = 1;
        }
        }

}
