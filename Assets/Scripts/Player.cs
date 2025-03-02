using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
using TMPro;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedOriginal;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float dashSpeed;
    private Rigidbody rb;
    private bool isTouching;
    private bool canDoubleJump;

    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnJump.AddListener(JumpPlayer);
        inputManager.OnDash.AddListener(DashInAir);
        rb = GetComponent<Rigidbody>();
        
        moveSpeedOriginal = moveSpeed;
        dashSpeed = moveSpeed * 10;
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
            moveSpeed = moveSpeedOriginal / 30;
        }else{
            moveSpeed = moveSpeedOriginal;
        }
    }

    public void MovePlayer(Vector3 direction)
    {
        Vector3 moveDirection = new(direction.x, 0f, direction.z);
        rb.AddForce(moveSpeed * moveDirection, ForceMode.Impulse);
        //rb.linearVelocity = moveDirection*moveSpeed;
    }

    public void DashInAir(Vector3 direction)
    {
        if(!isTouching)
        {
            //Debug.Log(direction);
            Vector3 moveDirection = new(direction.x, 0f, direction.z);
            rb.AddForce(dashSpeed * moveDirection, ForceMode.Impulse);
            //rb.transform.Translate(Vector3.forward * 1f * Time.deltaTime);
            //rb.linearVelocity = dashSpeed * moveDirection;
        }
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
