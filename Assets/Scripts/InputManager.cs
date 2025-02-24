using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.Cinemachine;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    public UnityEvent<Vector3> OnJump = new UnityEvent<Vector3>();
    [SerializeField] private Transform forwardMovement;
    //private bool isTouching;
/*
    private void OnCollisionStay()
    {
        isTouching = true;
    }
    */

    void Update()
    {
        Vector3 input = Vector3.zero;
        Vector3 jump = Vector3.zero;
        
        if(Input.GetKey(KeyCode.W))
        {
           input += forwardMovement.forward;
        }
        if(Input.GetKey(KeyCode.A))
        {
           input += -1*forwardMovement.right;
        } 
        if(Input.GetKey(KeyCode.D))
        {
            input += forwardMovement.right;
        } 
        if(Input.GetKey(KeyCode.Space))
        {
            jump += Vector3.up;
            //OnJump?.Invoke(jump);
            //isTouching = false;
        }
        
        OnMove?.Invoke(input);
        OnJump?.Invoke(jump);
    }
}
