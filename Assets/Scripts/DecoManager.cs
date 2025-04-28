using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class DecoManager : MonoBehaviour
{
    [Header("Game Objs")]
    public GameObject roadLine;

    public GameObject[] trees;
    public GameObject[] rocks;
    public GameObject[] other;

    [Header("Logic")]
    public int bounds;
    public int minObj;
    public int maxObj;

    public GameObject[] toSpawn;

    private void Start()
    {
        StartCoroutine(RoadLines());
        StartCoroutine(EverythingElse());
    }

    private IEnumerator RoadLines()
    {
        Instantiate(roadLine, new Vector3(2, -.47f, 500), Quaternion.identity);
        Instantiate(roadLine, new Vector3(-2, -.47f, 500), Quaternion.identity);


        yield return new WaitForSeconds(1);
        StartCoroutine(RoadLines());
    }

    private IEnumerator EverythingElse()
    {
        toSpawn = GenerateArrayToSpawn();



        yield return new WaitForSeconds(Random.Range(1f, 5f));
        StartCoroutine(EverythingElse());
    }

    private GameObject[] GenerateArrayToSpawn()
    {
        GameObject[] temp = new GameObject[Random.Range(minObj, maxObj)];

        for (int i =  0; i < temp.Length; i++)
        {
            int objType = Random.Range(1, 4);

            if (objType == 1)
                temp[i] = trees[Random.Range(0, 5)];
            else if (objType == 2)
                temp[i] = rocks[Random.Range(0, 5)];
            else
                temp[i] = other[Random.Range(0, 5)];
        }


        return temp;
    }
}
