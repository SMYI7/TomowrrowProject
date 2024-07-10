using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    private int tries;
    [SerializeField] private Vector3 offsetBetweenHearts;
    [SerializeField] private GameManger GM;
    [SerializeField] private GameObject HeartGm;
    [SerializeField] private GameObject Parent;
    [SerializeField] private Transform heartPosition;
    bool did = true;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tries = GM.PlayerTries;
        for (int i = 0; i < tries && did; i++) 
        {
            Instantiate(HeartGm, heartPosition.position + i * offsetBetweenHearts, new Quaternion(0,0,0,0), Parent.transform);
            
        }
        did = false;
    }
}
