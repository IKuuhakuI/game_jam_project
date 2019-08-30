using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerController : MonoBehaviour
{
    public float speed, jumpForce, damage;
    public float life, maxLife;
    public float timeToDeath, deathTimer, damageTimeMultiplier;
    public TextMeshProUGUI lifeText, timeText;
    private float boundaryLeft = -8.89f;
    private float boundaryRight = 8.89f;
    private int phase;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        deathTimer = timeToDeath;
        life = maxLife;
        scale = transform.localScale;
        phase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //lifeText.text = life.ToString();
        deathTimer -= Time.deltaTime*damageTimeMultiplier;
        timeText.text = deathTimer.ToString("F2");
        if (deathTimer<=2*timeToDeath/3 && phase==1)
        {
            phase = 2;
            speed = speed * 0.75f;
            jumpForce = jumpForce * 0.75f;
        }
        else if (deathTimer <= timeToDeath / 3 && phase == 2)
        {
            phase = 3;
            speed = speed * 0.75f;
            jumpForce = jumpForce * 0.75f;
            damage = damage / 2;
        }
        if (deathTimer <= 0)
        {
            timeText.text = "0";
            this.gameObject.SetActive(false);
        }       
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
