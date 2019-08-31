using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedEnemyController : MonoBehaviour
{
    public float damage, maxAttackSpeed;
    public float health;
    public GameObject player, gameController, projectile, creator;
    private GameObject temp;
    private Vector3 playerPosition;
    public float timer = 0, MaxTime;
    private Vector3 scale;
    public bool attackDir; //true = right
    public bool takingDmg;
    public float timeDmg;
    private Color red, white;
    public SpriteRenderer orangeGbSR;
    // Start is called before the first frame update
    void Start()
    {
        red = new Color(1f, 0.6f, 0.6f);
        white = new Color(1f, 1f, 1f);
        takingDmg = false;
        scale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
        MaxTime = Random.Range(0.2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=MaxTime)
        {
            timer = 0;
            MaxTime = Random.Range(0.75f, maxAttackSpeed);
            temp=Instantiate(projectile, transform.position, transform.rotation);
            temp.GetComponent<arrowController>().direction = new Vector3(transform.localScale.x, 0, 0);
            temp.transform.localScale = new Vector3(4*(transform.localScale.x / Mathf.Abs(transform.localScale.x)), 2, 0);
        }
        if (health<=0)
        {
            Destroy(this.gameObject);
            gameController.GetComponent<gameController>().currentNumberofEnemies -= 1;
        }

        if (takingDmg)                                                     //MUDA COR QUANDO TOMA DANO
        {
            Debug.Log("danoIni");
            timeDmg += Time.deltaTime;
            if (timeDmg <= 0.5)
            {
                orangeGbSR.color = red;
            }
            else
            {
                takingDmg = false;
                timeDmg = 0f;
                orangeGbSR.color = white;
            }
        }

    }
}
