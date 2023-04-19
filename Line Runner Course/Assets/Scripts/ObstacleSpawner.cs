using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject[] obstacles;
    Vector3 spawnPosition;
    public float spawnRate;

    void Start()
    {
        spawnPosition = transform.position;

        StartCoroutine("SpawnObstacles");
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn();

            GameManager.instance.UpdateScore();

            yield return new WaitForSeconds(spawnRate);
        }
    }

    void Spawn()
    {
        int randomObstacle = Random.Range(0, obstacles.Length);

        int randomSpot = Random.Range(0, 2); // 0 = Top 1 = buttom

        spawnPosition = transform.position;

        if (randomSpot < 1)
        {
            // Spawn at top
            Instantiate(obstacles[randomObstacle], spawnPosition, transform.rotation);
        }
        else
        {
            // Spawn at bottom
            spawnPosition.y = -transform.position.y;

            if (randomObstacle == 1)
            {
                // Add 1 to the x position if DoubleObstacle element
                spawnPosition.x += 1;
            }
            else if (randomObstacle == 2)
            {
                // Add 2 to the x position if TrippleObstacle element
                spawnPosition.x += 2;
            }

            GameObject obs = Instantiate(obstacles[randomObstacle], spawnPosition, transform.rotation);
            obs.transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }
}
