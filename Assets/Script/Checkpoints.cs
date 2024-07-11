using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool inRange;
    [SerializeField] private LayerMask playerLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inRange = Physics2D.OverlapCircle(transform.position + offset, radius, playerLayer);
        if (inRange)
        {
            GameObject.FindGameObjectWithTag("GameManger").GetComponent<GameManger>().currentCheckpoint = gameObject;
            GameObject.FindGameObjectWithTag("GameManger").GetComponent<GameManger>().Died = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + offset, radius);
    }
}
