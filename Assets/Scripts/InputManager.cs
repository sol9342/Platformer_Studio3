using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.Cinemachine;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    public UnityEvent<Vector3> OnJump = new UnityEvent<Vector3>();
    public UnityEvent<Vector3> OnDash = new UnityEvent<Vector3>();
    [SerializeField] private Transform forwardMovement; 

    void Update()
    {
        Vector3 input = Vector3.zero;
        Vector3 jump = Vector3.zero;
        Vector3 dash = Vector3.zero;
        
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
        }
        if(Input.GetKey(KeyCode.Q)) 
        {
            dash += forwardMovement.forward;
        }
        
        OnMove?.Invoke(input);
        OnJump?.Invoke(jump);
        OnDash?.Invoke(dash);
    }
}
