using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody rb;
    private bool isTouching;

    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnJump.AddListener(JumpPlayer);
        rb = GetComponent<Rigidbody>();
    }
/*
    private void OnCollisionStay()
    {
        isTouching = true;
    }
    */
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isTouching = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        /*
        if(other.gameObject.CompareTag("Ground"))
        {
            isTouching = false;
        }
        */
        isTouching = false;
    }

    public void MovePlayer(Vector3 direction)
    {
        Vector3 moveDirection = new(direction.x, 0f, direction.z);
        rb.AddForce(moveSpeed * moveDirection);
    }

    public void JumpPlayer(Vector3 dir)
    {
        if(isTouching)
        {
            //rb.linearVelocity = Vector3.zero;
            
            rb.AddForce(dir * jumpSpeed, ForceMode.Impulse);
            
            //isTouching = false;
            //rb.linearVelocity = new Vector3(0, jumpSpeed, 0);
           // rb.linearVelocity.y = dir*jumpSpeed; 
            //isTouching = false;
        }
    }

}
