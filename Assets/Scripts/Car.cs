using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float speed;
    float currentSpeed;

    public LayerMask car;

    void Start()
    {
        speed = Random.Range(0.6f, .7f);
    }

    void Update()
    {
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.back, 5, car))
            speed -= .15f;

        currentSpeed = Mathf.Clamp(speed * CarManager.i.speed * Time.deltaTime, 0.5f, 0.7f);
        transform.position += Vector3.back * currentSpeed;

        if (transform.position.z < -150)
            Destroy(gameObject);
    }
}
