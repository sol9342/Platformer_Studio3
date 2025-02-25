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
    public int jumpsLeft;

    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnJump.AddListener(JumpPlayer);
        rb = GetComponent<Rigidbody>();
        
        moveSpeedOriginal = moveSpeed;
        //jumpsLeft = 2;
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isTouching = true;
            Debug.Log("colliding with ground");
            //jumpsLeft = 2;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            jumpsLeft = 1;
            isTouching = false;
            Debug.Log("Leaving ground");
            //jumpsLeft = 1;
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
        if(isTouching || jumpsLeft==1)
        {
            rb.linearVelocity = new Vector3(0, jumpSpeed, 0);
            rb.linearVelocity = dir*jumpSpeed; 
            jumpsLeft = 0;
        }
    }

}
