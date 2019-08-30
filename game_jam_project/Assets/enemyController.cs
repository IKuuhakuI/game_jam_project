using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed;
    public float health;
    public GameObject player;
    private Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        if (transform.position.x<=playerPosition.x)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y);
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
}
