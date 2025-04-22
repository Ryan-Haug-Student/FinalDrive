using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public static CarManager i { get; private set; }

    [Header("Stats")]
    public float speed;
    public float timeBetween; //frequency
    public float timeScale;


    private Vector3[] lanes;

    [Header("Logic")]
    public bool canSpawn;
    public GameObject[] cars;

    private void Start()
    {
        if (i == null)
            i = this;

        lanes = new Vector3[]
        { new Vector3(-4f, 0, 500),     //left lane
          new Vector3(0, 0, 500),       //right lane
          new Vector3(4f, 0, 500)      //right lane 
        };

        timeBetween = PlayerPrefs.GetInt("carFreq", 3);
        print(PlayerPrefs.GetInt("carFreq"));
    }

    private void Update()
    {
        if (canSpawn)
            StartCoroutine("SpawnCars");

        Time.timeScale = timeScale;
    }

    private IEnumerator SpawnCars()
    {
        canSpawn = false;
        int quantity = Random.Range(1, 3);
        int lastSpawnPos = -1; //assigned so first run isnt null and always used

        for (int i = 0; i < quantity; i++)
        {
            int spawnPos = Random.Range(0, 3);
            float laneVarience = Random.Range(-.5f, .5f);

            if (spawnPos != lastSpawnPos)
            { Instantiate(cars[Random.Range(0, 4)], lanes[spawnPos] + (Vector3.right * laneVarience), Quaternion.Euler(0, 0, 0)); lastSpawnPos = spawnPos; }
            else
                break;
        }

        yield return new WaitForSeconds(timeBetween / (speed / 10));
        canSpawn = true;
    }
}