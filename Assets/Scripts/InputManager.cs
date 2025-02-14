using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnWPressed = new UnityEvent();

    void Update()
    {
        Vector3 input = Vector3.zero;

        
        if(Input.GetKey(KeyCode.W))
        {
            input += Vector3.up;
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            input += Vector3.left;
        } 
        if(Input.GetKey(KeyCode.D))
        {
            input += Vector3.right;
        } 

        OnMove?.Invoke(input);
    }
}
