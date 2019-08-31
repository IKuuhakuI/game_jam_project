using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerController : MonoBehaviour
{
    public float speed, jumpForce, damage;
    public float life, maxLife;
    public float timeToDeath, deathTimer, damageTimeMultiplier; //deathTimer -> time remaining //timeToDeath -> gameplay duration
    public TextMeshProUGUI lifeText, timeText, scoreText, highScoreText;
    private float boundaryLeft = -8.89f;
    private float boundaryRight = 8.89f;
    public int phase;
    private bool isOld1, isOld2;
    private Vector3 scale;
    public Animator animator;
    public int score;
    public GameObject gameOver, scoreKeeperObject;
    public SpriteRenderer playerSpriteRender;
    public AudioSource damageAudioSource, clockAudioSource;
    public bool takingDmg;
    public float timeDmg;
    public Image clock;
    private Color red, white;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeperObject = GameObject.FindGameObjectWithTag("scoreKeeper");
        red = new Color(1f, 0.6f, 0.6f);
        white = new Color(1f, 1f, 1f);
        takingDmg = false;
        score = 0;
        deathTimer = timeToDeath;
        life = maxLife;
        scale = transform.localScale;
        phase = 1;
        isOld1 = false;
        isOld2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //lifeText.text = life.ToString();
        scoreText.text = "Current Score: " + score;
        highScoreText.text= "High Score: " + scoreKeeperObject.GetComponent<scoreKeeper>().highScore;
        deathTimer -= Time.deltaTime*damageTimeMultiplier;
        timeText.text = deathTimer.ToString("F2");
        if (deathTimer<=2*timeToDeath/3 && phase==1)
        {
            phase = 2;
            speed = speed * 0.75f;
            jumpForce = jumpForce * 0.75f;
            animator.SetBool("isOld1", true);
        }
        else if (deathTimer <= timeToDeath / 3 && phase == 2)
        {
            phase = 3;
            speed = speed * 0.75f;
            jumpForce = jumpForce * 0.75f;
            damage = damage / 2;
            animator.SetBool("isOld1", false);
            animator.SetBool("isOld2", true);
            GetComponent<BoxCollider2D>().size = new Vector2(.4f, .47f);
        }
        if (deathTimer <= 0)
        {
            timeText.text = "0";
            if (score> scoreKeeperObject.GetComponent<scoreKeeper>().highScore)
            {
                scoreKeeperObject.GetComponent<scoreKeeper>().highScore = score;
            }
            gameOver.SetActive(true);
            gameOver.GetComponentInChildren<TextMeshProUGUI>().text = score.ToString();
            this.gameObject.SetActive(false);
        }       

        //Andar para direita
        if (Input.GetKey("right")&&transform.position.x+0.7f+speed<=boundaryRight)
        {
            transform.localScale = new Vector3(scale.x, scale.y);
            transform.position= new Vector3(transform.position.x+speed, transform.position.y,transform.position.z);
            //animator.SetBool("isWalking", true);
        }

        //Andar para esquerda
        if (Input.GetKey("left") && transform.position.x - 0.7f - speed >= boundaryLeft)
        {
            transform.localScale = new Vector3(-scale.x, scale.y);
            transform.position=new Vector3(transform.position.x-speed, transform.position.y,transform.position.z);
            //animator.SetBool("isWalking", true);
        }

        
        if (Input.GetKeyUp("left")|| Input.GetKeyUp("right"))
        {
            //animator.SetBool("isWalking", false);
        }

        //Ataque
        if (Input.GetKeyDown("space"))
        {
            transform.Find("player attack").gameObject.SetActive(true);
            animator.SetBool("isAttacking", true);
        }

        //Pulo
        if (Input.GetKeyDown("up")&& transform.position.y<= -0.8f)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, jumpForce));
            //animator.SetBool("isJumping", true);
        }

        //

        if (takingDmg)                                                     //MUDA COR QUANDO TOMA DANO
        {
            timeDmg += Time.deltaTime;
            if (timeDmg <= 0.5)
            {
                clock.color = red;
                timeText.color = red;
                playerSpriteRender.color = red;
            }
            else
            {
                takingDmg = false;
                timeDmg = 0f;
                timeText.color = white;
                playerSpriteRender.color = white;
                clock.color = white;
            }
        }

    }


    public void setJumpingFalse()
    {
        animator.SetBool("isJumping", false);
    }
    public void setAttackingFalse()
    {
        animator.SetBool("isAttacking", false);
    }
    public void setDamageFalse()
    {
        animator.SetBool("isDamage", false);
    }
}
