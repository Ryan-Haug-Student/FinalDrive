using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    public float lean;
    public GameObject pivot;
    public HingeJoint joint;


    private void Update()
    {
        Lean();
        Move();

        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    private void Lean()
    {
        lean = joint.angle;

        pivot.transform.rotation = Quaternion.Euler(0, 0, -lean * .8f);
    }

    private void Move()
    {
        if (-lean < 0 && pivot.transform.position.x < 5.6f)
            pivot.transform.position += new Vector3(0.0017f * lean, 0, 0);
        else if (-lean > 0 && pivot.transform.position.x > -5.6f)
            pivot.transform.position += new Vector3(0.0017F * lean, 0, 0);
    }
}
