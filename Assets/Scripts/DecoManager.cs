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
    public int minObj;
    public int maxObj;

    public GameObject[] toSpawn;

    // Define the lane boundaries
    private readonly float[] lanePositions = new float[] { -4f, 0f, 4f };
    private const float LANE_WIDTH = 3f; // Increased to better avoid lanes
    private const float MIN_DISTANCE = 3f; // Minimum distance between objects
    private const float SPAWN_RANGE = 50f; // Increased spawn range

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
        SpawnObjects();

        yield return new WaitForSeconds(Random.Range(.5f, 2f));
        StartCoroutine(EverythingElse());
    }

    private void SpawnObjects()
    {
        List<Vector3> usedPositions = new List<Vector3>();

        foreach (GameObject obj in toSpawn)
        {
            Vector3 position = GenerateValidPosition(usedPositions);
            usedPositions.Add(position);

            Instantiate(obj, position, Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
    }

    private Vector3 GenerateValidPosition(List<Vector3> usedPositions)
    {
        Vector3 position;
        int maxAttempts = 100; // Prevent infinite loops
        int attempts = 0;

        do
        {
            // Decide if spawning left or right of the road
            bool spawnLeft = Random.value > 0.5f;
            float x;

            if (spawnLeft)
            {
                // Left side: From -SPAWN_RANGE up to leftmost lane minus LANE_WIDTH
                x = Random.Range(-SPAWN_RANGE, lanePositions[0] - LANE_WIDTH);
            }
            else
            {
                // Right side: From rightmost lane plus LANE_WIDTH up to SPAWN_RANGE
                x = Random.Range(lanePositions[2] + LANE_WIDTH, SPAWN_RANGE);
            }

            position = new Vector3(x, 0, 500);

            // Check distance from other objects
            bool tooClose = false;
            foreach (Vector3 usedPos in usedPositions)
            {
                if (Vector3.Distance(position, usedPos) < MIN_DISTANCE)
                {
                    tooClose = true;
                    break;
                }
            }

            if (!tooClose)
                return position;

            attempts++;
        } while (attempts < maxAttempts);

        // If we couldn't find a valid position after max attempts, return a fallback position
        float fallbackX = Random.value > 0.5f ? 
            Random.Range(-SPAWN_RANGE, lanePositions[0] - LANE_WIDTH) : 
            Random.Range(lanePositions[2] + LANE_WIDTH, SPAWN_RANGE);
        return new Vector3(fallbackX, 0, 500);
    }

    private GameObject[] GenerateArrayToSpawn()
    {
        GameObject[] temp = new GameObject[Random.Range(minObj, maxObj)];

        for (int i = 0; i < temp.Length; i++)
        {
            int objType = Random.Range(1, 4);

            if (objType == 1)
                temp[i] = trees[Random.Range(0, trees.Length)];
            else if (objType == 2)
                temp[i] = rocks[Random.Range(0, rocks.Length)];
            else
                temp[i] = other[Random.Range(0, other.Length)];
        }

        return temp;
    }
}
