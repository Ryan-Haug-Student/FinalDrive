using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecortaionObj : MonoBehaviour
{
    private int speed = 25; //link to Player controller speed when made
    private float DFZ = -1; //distance from zero, used for paralax

    private int maxZ = 300;

    private void Start()
    {   //adding and dividing DFZ by 100 to even out the distances, creating a smoother paralax
        DFZ = Mathf.Abs(transform.position.x) + 101;
    }

    private void Update()
    {
        if (transform.position.x < -maxZ)
            Destroy(gameObject);

        transform.position += Vector3.back * speed / (DFZ / 100) * Time.deltaTime;
    }
}
