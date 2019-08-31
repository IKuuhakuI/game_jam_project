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
            //GameObject.Find("skyBox").GetComponent<skyBoxController>().danoPulaTempo += GetComponentInParent<enemyController>().damage; //o dano faz o tempo pular pra frente
            collision.GetComponent<playerController>().life -= GetComponentInParent<enemyController>().damage;
            collision.GetComponent<playerController>().damageTimeMultiplier += 0.4f;
            GetComponentInParent<enemyController>().isAttacking = false;
            GetComponentInParent<enemyController>().timer = 0;
            //
            collision.GetComponent<playerController>().takingDmg = true;
            //
            collision.GetComponent<AudioSource>().Play();
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
