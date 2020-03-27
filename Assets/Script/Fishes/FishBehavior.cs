using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    float fishSpeed;

    void Start()
    {
        SetFishDirection();
        fishSpeed = Random.Range(1, 5);
    }

    void Update()
    {
        transform.position += transform.forward * fishSpeed * Time.deltaTime;
    }

    void SetFishDirection()
    {
        if (Random.Range(0, 100) < 40)
        {
            transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(Random.Range(-25, 0), Random.Range(0, 360), 0);
        }
    }
}
