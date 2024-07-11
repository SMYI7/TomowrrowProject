using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SowrdAttackScript : MonoBehaviour
{
    bool isAttacking;
    bool AttackButton;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private Animator anim;
    [SerializeField] private float radius;
    [SerializeField] private float timer;
    [SerializeField] private float Currenttimer;
    [SerializeField] private LayerMask EnenmyLayer;

    void Start()
    {
        PlayerInput input = new PlayerInput();
        input.Enable();
        input.Gamplay.Attack.performed += i => AttackButton = true;
        input.Gamplay.Attack.canceled += i => AttackButton = false;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isAttacking", isAttacking);

        Currenttimer -= Time.deltaTime;
        if (AttackButton && !isAttacking && Currenttimer < 0) 
        {
            Currenttimer = timer;
            isAttacking = true;
            anim.SetBool("isAttacking", isAttacking);
            Collider2D[] hitInfo = Physics2D.OverlapCircleAll(hitPoint.position, radius, EnenmyLayer);
            foreach(Collider2D enemy in hitInfo)
            {
                if (enemy != null)
                {
                    if (enemy.CompareTag("Enemy"))
                    {
                        Destroy(enemy.gameObject);
                    }
                }
            }
           
        }
        if(Currenttimer < 0 && isAttacking)
        {
            isAttacking = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPoint.position, radius);
    }
}
