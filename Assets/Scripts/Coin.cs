using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public int rotateSpeed;
    //private int points;
   // public TextMeshProUGUI scoreText;
    void Start()
    {
        rotateSpeed = 1;
       // points = 0;
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

/*
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            points++;
            scoreText.text = "Score: " + points;
        }
    }
  */  
}
