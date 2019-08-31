using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.tag=="Enemy")
        {
            collision.GetComponent<enemyController>().health -= GetComponentInParent<playerController>().damage;
            collision.GetComponent<enemyController>().takingDmg = true;
            if (collision.GetComponent<enemyController>().health<=0)
            {
                GetComponentInParent<playerController>().score += 1;
            }
            
        }
        else if (collision.tag == "rangedEnemy")
        {
            collision.GetComponent<rangedEnemyController>().health -= GetComponentInParent<playerController>().damage;
            collision.GetComponent<rangedEnemyController>().takingDmg = true;
            collision.GetComponent<rangedEnemyController>().creator.GetComponent<enemySpawner>().spawnedRanged = false;
            if (collision.GetComponent<rangedEnemyController>().health <= 0)
            {
                GetComponentInParent<playerController>().score += 1;
            }
        }

        
    }
}
