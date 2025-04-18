using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float speed;
    float currentSpeed;

    bool aboutToCollide;

    void Start()
    {
        speed = Random.Range(0.6f, .7f);
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = speed * CarManager.i.speed * Time.deltaTime;

        transform.position += Vector3.back * currentSpeed;

        if (transform.position.z < -150)
            Destroy(gameObject);
    }

    void CheckForCollision()
    {

    }
}
