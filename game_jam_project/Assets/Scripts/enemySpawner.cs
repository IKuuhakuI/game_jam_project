using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public float spawnTimer, spawnTime, maxSpawnTime, spawnMultiplier;
    public GameObject enemyPrefab, gameController, rangedPrefab;
    private GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
        spawnTime = Random.Range(0f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GetComponent<gameController>().currentNumberofEnemies<= gameController.GetComponent<gameController>().maxNumberofEnemies)
        {
            spawnTimer += Time.deltaTime;
        }
        if (spawnTimer>=spawnTime)
        {
            if (Random.Range(0f,1f)>=0.3)
            {
                temp = Instantiate(enemyPrefab, transform);
                temp.transform.localScale = new Vector3(transform.localScale.x * 3, 3, 0);
            }
            else
            {
                temp = Instantiate(rangedPrefab, transform.position, transform.rotation);
                temp.transform.localScale = new Vector3(transform.localScale.x*3, 3, 0);
            }
            spawnTimer = 0;
            spawnTime = Random.Range(1.5f * spawnMultiplier, maxSpawnTime * spawnMultiplier);
            
            gameController.GetComponent<gameController>().currentNumberofEnemies += 1;
        }
    }
}
