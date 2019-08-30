using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerController : MonoBehaviour
{
    public float speed, jumpForce, damage;
    public float life, maxLife;
    public TextMeshProUGUI lifeText;
    private float boundaryLeft = -8.89f;
    private float boundaryRight = 8.89f;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = life.ToString();
        if (Input.GetKey("right")&&transform.position.x+0.7f+speed<=boundaryRight){
            transform.localScale = new Vector3(scale.x, scale.y);
            transform.position= new Vector3(transform.position.x+speed, transform.position.y,transform.position.z);
        }
        if (Input.GetKey("left") && transform.position.x - 0.7f - speed >= boundaryLeft)
        {
            transform.localScale = new Vector3(-scale.x, scale.y);
            transform.position=new Vector3(transform.position.x-speed, transform.position.y,transform.position.z);
        }
        if (Input.GetKeyDown("up")&& transform.position.y<= -0.8f)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, jumpForce));
        }
        if (Input.GetKeyDown("space"))
        {
            transform.Find("player attack").gameObject.SetActive(true);
        }
    }
}
