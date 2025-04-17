using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecortaionObj : MonoBehaviour
{
    private float speed = 25; //link to Player controller speed when made
    private float DFZ = -1; //distance from zero, used for paralax

    private void Start()
    {   //adding and dividing DFZ by 100 to even out the distances, creating a smoother paralax
        DFZ = Mathf.Abs(transform.position.x) + 101;
    }

    private void Update()
    {
        if (transform.position.z < -150)
            Destroy(gameObject);

        speed = CarManager.i.speed;

        transform.position += Vector3.back * speed / (DFZ / 100) * Time.deltaTime;
    }
}
