using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float delay;
    [SerializeField] private float Checkradius;
    [SerializeField] private float hitRadius;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform DownCheck;
    [SerializeField] private Transform SideCheck;
    private float Direction;
    [SerializeField] private GameManger GM;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Direction > 0)
        {
            transform.localRotation = new Quaternion(0, 180, 0, 0);
        } else transform.localRotation = new Quaternion(0, 0, 0, 0);

        delay -= Time.deltaTime;
        rb.velocity = Vector2.right * Direction * speed;
        if (Physics2D.OverlapCircle(SideCheck.position, Checkradius, groundLayer) != null && delay < 0)
        {
            Direction *= -1;
            delay = 0.1f;
        }
        if (!Physics2D.OverlapCircle(DownCheck.position, Checkradius, groundLayer) && delay < 0)
        {
            delay = 0.1f;
            Direction *= -1;
        }
        if (Physics2D.OverlapCircle(transform.position, hitRadius, playerLayer) != null)
        {
            GM.Died = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(SideCheck.position, Checkradius);
        Gizmos.DrawWireSphere(DownCheck.position, Checkradius);
        Gizmos.DrawWireSphere(transform.position, hitRadius);

    }
}
