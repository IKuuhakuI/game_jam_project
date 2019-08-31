using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (direction * speed);
        if (transform.position.x>=10 || transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            collision.GetComponent<playerController>().damageTimeMultiplier += 0.3f;
            collision.GetComponent<playerController>().takingDmg = true;
            collision.GetComponent<AudioSource>().Play();
            
        }
        Destroy(gameObject);
    }
}
