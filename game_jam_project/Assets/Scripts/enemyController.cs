using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed;
    public float damage;
    public bool isAttacking = true;
    public float health;
    public GameObject player, gameController;
    private Vector3 playerPosition;
    private float enemyDist = 1.5f;
    public float timer = 0, MaxTime;
    private Vector3 scale;
    public bool attackDir; //true = right

    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        if (distance(transform.position, playerPosition) >= enemyDist && transform.position.x - playerPosition.x < 0)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y);
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
            attackDir = true;
        }
        else if(distance(transform.position, playerPosition) >= enemyDist && transform.position.x - playerPosition.x > 0)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y);
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
            attackDir = false;
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
            gameController.GetComponent<gameController>().currentNumberofEnemies -= 1;
        }

        if (!isAttacking && timer <= MaxTime)
        {
            timer += Time.deltaTime;

        } else
        {
            transform.Find("GoblinAttack").gameObject.SetActive(true);
            isAttacking = true;
        }

    }
    
    float distance(Vector2 pos1, Vector2 pos2)
    {
        return Mathf.Sqrt(Mathf.Pow(pos1.y - pos2.y, 2) + Mathf.Pow(pos1.x - pos2.x, 2));
    }
}
