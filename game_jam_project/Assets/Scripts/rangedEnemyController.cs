using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedEnemyController : MonoBehaviour
{
    public float damage, maxAttackSpeed;
    public float health;
    public GameObject player, gameController, projectile;
    private GameObject temp;
    private Vector3 playerPosition;
    public float timer = 0, MaxTime;
    private Vector3 scale;
    public bool attackDir; //true = right
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
