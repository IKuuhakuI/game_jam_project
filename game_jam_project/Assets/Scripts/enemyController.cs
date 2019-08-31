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
    private float enemyDist = 1.2f;
    public float timer = 0, MaxTime;
    private Vector3 scale;
    public bool attackDir; //true = right
    public bool takingDmg;
    public float timeDmg;
    private Color red, white;
    public SpriteRenderer greenGbSR;

    // Start is called before the first frame update
    void Start()
    {
        red = new Color(1f, 0.4f, 0.6f);
        white = new Color(1f, 1f, 1f);
        takingDmg = false;
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
            gameController.GetComponent<gameController>().currentNumberofEnemies -= 1;
            Destroy(this.gameObject);
            
        }

        if (!isAttacking && timer <= MaxTime)
        {
            timer += Time.deltaTime;

        } else
        {
            transform.Find("GoblinAttack").gameObject.SetActive(true);
            isAttacking = true;
        }

        if (takingDmg)                                                     //MUDA COR QUANDO TOMA DANO
        {
            Debug.Log("danoIni");
            timeDmg += Time.deltaTime;
            if (timeDmg <= 0.5)
            {
                greenGbSR.color = red;
            }
            else
            {
                takingDmg = false;
                timeDmg = 0f;
                greenGbSR.color = white;
            }
        }


    }
    
    float distance(Vector2 pos1, Vector2 pos2)
    {
        return Mathf.Sqrt(Mathf.Pow(pos1.y - pos2.y, 2) + Mathf.Pow(pos1.x - pos2.x, 2));
    }
}
