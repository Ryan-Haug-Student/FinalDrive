using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BikeThrottle : MonoBehaviour
{
    public float initialZ;

    public float throttlePerc;
    public bool grabbed;

    public GameObject hand;

    public void Grabbed()
    {
        grabbed = true;
        initialZ = hand.transform.localRotation.z;
    }
    public void Dropped()
    {
        grabbed = false;

        initialZ = 0;
        throttlePerc = 0;
    }

    private void Update()
    {
        if (grabbed)
            throttlePerc = Mathf.Clamp01((hand.transform.localRotation.z - initialZ) * 5);
    }


}
