using UnityEngine;

public class Coin : MonoBehaviour
{
    public int rotateSpeed;
    void Start()
    {
        rotateSpeed = 1;
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
