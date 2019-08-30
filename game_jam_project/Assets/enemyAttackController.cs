using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackController : MonoBehaviour
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
        if (collision.tag == "Player")
        {
            collision.GetComponent<playerController>().life -= GetComponentInParent<enemyController>().damage;
            GetComponentInParent<enemyController>().isAttacking = false;
            GetComponentInParent<enemyController>().timer = 0;
            gameObject.SetActive(false);
            if (GetComponentInParent<enemyController>().attackDir)
            {
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(150, 300));
            }
            else
            {
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-150, 300));
            }
            
        }

    }
}
