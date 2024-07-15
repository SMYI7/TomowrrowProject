using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    Vector2 pVelocity;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        pVelocity = player.GetComponent<Rigidbody2D>().velocity;
        anim.SetBool("isJumping", pVelocity.y > 0.01);
        anim.SetFloat("Velocity", Mathf.Abs(pVelocity.x));
    }
}
