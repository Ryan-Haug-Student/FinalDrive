using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoManager : MonoBehaviour
{
    [Header("Game Objs")]
    public GameObject roadLine;
       
    [Header("Bools")]
    public bool canSpawnLine = true;

    private void Start()
    {
        StartCoroutine("RoadLines");
    }

    private IEnumerator RoadLines()
    {
        Instantiate(roadLine, new Vector3(2, -.47f, 500), Quaternion.identity);
        Instantiate(roadLine, new Vector3(-2, -.47f, 500), Quaternion.identity);


        yield return new WaitForSeconds(1);
        StartCoroutine("RoadLines");
    }
}
