using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    [SerializeField] private float minTime = 0.5f;
    [SerializeField] private float maxTime = 2f;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    private float timeDelta = 0;

    void Start()
    {
        Debug.Assert(enemyPrefabs.Length > 0, "Enemy prefabs unassigned");   
        timeDelta = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        // Whilst timeDelta is above zero, we minus the time between the last update calls then check timeDelta again
        // if it is below zero we know the correct time has passed and we spawn an enemy from one of four random spawn
        // points. We then reset timeDelta to a random value.
        if (timeDelta > 0)
        {
            timeDelta -= Time.deltaTime;
            if(timeDelta <= 0)
            {
                int randomPoint = Random.Range(0, spawnPoints.Length);
                Vector3 pos = spawnPoints[randomPoint].position;
                GameObject enemy = Spawn(pos);
                if (enemy.GetComponent<GnomeoAIController>() != null)
                {
                    enemy.GetComponent<GnomeoAIController>().SetTarget(player);     //if it is a regular enemy
                }
                timeDelta = Random.Range(minTime, maxTime);
            }
        }
    }

    public GameObject Spawn(Vector3 pos)
    {
        int index = Random.Range(0, enemyPrefabs.Length);   //Pick random enemy from list           //HOW TO GET THE ENEMY'S RAGDOLL DIFFERENTLY!!!!
        return (GameObject)Instantiate(enemyPrefabs[index], pos, Quaternion.identity);
    }
}
