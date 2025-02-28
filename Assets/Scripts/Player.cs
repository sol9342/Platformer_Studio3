using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedOriginal;
    [SerializeField] private float jumpSpeed;
    private Rigidbody rb;
    [SerializeField] private bool isTouching;
    [SerializeField] private bool canDoubleJump;
    //public int jumpsLeft;

    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnJump.AddListener(JumpPlayer);
        rb = GetComponent<Rigidbody>();
        
        moveSpeedOriginal = moveSpeed;
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isTouching = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isTouching = false;
        } 
    }

    void Update()
    {
        if(!isTouching)
        {
            moveSpeed = moveSpeedOriginal / 15;
        }else{
            moveSpeed = moveSpeedOriginal;
        }
    }

    public void MovePlayer(Vector3 direction)
    {
        Vector3 moveDirection = new(direction.x, 0f, direction.z);
        rb.AddForce(moveSpeed * moveDirection);
    }

    public void JumpPlayer(Vector3 dir)
    {
        //Debug.Log("jumps left: "+jumpsLeft);
        if(isTouching)
        {
            rb.linearVelocity = dir*jumpSpeed; 
            canDoubleJump = true;
        }else{
            if(Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                canDoubleJump = false;
                rb.linearVelocity = dir*jumpSpeed; 
            }
        }
    }

}
