using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public int rotateSpeed;
    public int scoreValue = 1;

    void Start()
    {
        rotateSpeed = 1;
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    } 


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
