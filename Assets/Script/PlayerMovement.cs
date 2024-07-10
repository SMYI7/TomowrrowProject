using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput;
    [SerializeField] float Speed;
    [SerializeField] float JumpForce;
    private bool isJumping;
    private Rigidbody2D rb;
     void Start()
     {
        isJumping = false;
        PlayerInput input = new PlayerInput();
        input.Enable();
        input.Gamplay.Move.performed += i => moveInput = i.ReadValue<Vector2>();
        input.Gamplay.Move.canceled += i => moveInput = i.ReadValue<Vector2>();
        input.Gamplay.Jump.performed += Jump;
     }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveInput.x * Speed * Vector2.right;
        
    }
    void Jump(InputAction.CallbackContext context)
    {
        if (!isJumping)
        {
            rb.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);
        }
    }
}
