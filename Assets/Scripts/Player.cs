using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    private Rigidbody rb;
    [SerializeField] private Transform forwardMovement;

    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        rb = GetComponent<Rigidbody>();
        inputManager.OnWPressed.AddListener(MoveForward);
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 moveDirection = new(direction.x, 0f, direction.y);
        //rb.AddForce(speed * moveDirection);
        //rb.AddForce(forwardMovement.forward * speed);
    }

    private void MoveForward()
    {
        rb.AddForce(forwardMovement.forward * speed);
    }


}
