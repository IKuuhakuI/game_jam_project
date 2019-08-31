using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curvedArrowController : MonoBehaviour
{
    public float newRotation;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x<0)
        {
            newRotation = Vector2.SignedAngle(Vector2.left, rb.velocity);
        }
        else
        {
            newRotation = Vector2.SignedAngle(Vector2.right, rb.velocity);
        }
     
        transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, transform.localRotation.y, newRotation));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            collision.GetComponent<playerController>().damageTimeMultiplier += 0.2f;
            collision.GetComponent<playerController>().takingDmg = true;
            collision.GetComponent<AudioSource>().Play();

        }
        Destroy(gameObject);
    }
}
