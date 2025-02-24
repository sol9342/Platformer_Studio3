using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.Cinemachine;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    [SerializeField] private Transform forwardMovement;

    void Update()
    {
        Vector3 input = Vector3.zero;
        
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
        

        OnMove?.Invoke(input);
    }
}
