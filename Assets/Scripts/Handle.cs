using UnityEngine;

public class Handle : MonoBehaviour
{
    public bool Grabbed;
    public Vector3 returnPos;
        
    private void Start()
    {
        returnPos = transform.localPosition;
    }

    private void Update()
    {
        if (!Grabbed)
            transform.localPosition = returnPos;
    }

    public void grabbed()
    {
        Grabbed = true;
    }

    public void Dropped()
    {
        Grabbed = false;
    }
}
