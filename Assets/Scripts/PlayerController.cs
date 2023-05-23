using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move;
    private bool canMove = true;
    SoundManager soundManager;
    [Header("---------- Objects")]
    public GameObject attackPoint;
    public GameObject footstep;
    public GameObject attacksound;
    public LayerMask enemies;
    public Animator anim;

    [Header("--------- Floats & Bools ----------")]
    public float radius;
    public float speed;
    public float jump;
    public bool isFacingRight;
    public bool isJumping;
    public float playerDamage;

    void Start()
    {
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
        footstep.SetActive(false);
        attacksound.SetActive(false);
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

    void Update()
    {
        if (!GameManagerScript.isPaused)
        {
            if (canMove == true)
            {
                move = Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(move * speed, rb.velocity.y);

                if (Input.GetButtonDown("Jump") && isJumping == false)
                {
                    rb.AddForce(new Vector2(rb.velocity.x, jump));
                }
            }
            if (!isFacingRight && move > 0f)
            {
                Flip();
            }
            else if (isFacingRight && move < 0f)
            {
                Flip();
            }

            if (move > .1f || move < -.1f)
            {
                anim.SetBool("isWalking", true);
                // en koll för att se om isWalking = yes           
                // Debug.Log("isWalking = " + anim.GetBool("isWalking"));
            }
            else
            {
                anim.SetBool("isWalking", false);
                // Debug.Log("isWalking = " + anim.GetBool("isWalking"));
            }

            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("isAttacking", true);
                attacksound.SetActive(true);

            }
            if (gameObject.GetComponent<playerHealth>().pHealth <= 0)
            {
                canMove = false;
                rb.velocity = new Vector2(0.0f, 0.0f);


            }
        }

        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            footsteps();
        }

        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            StopFootsteps();
        }
    }

    public void footsteps()
    {
        footstep.SetActive(true);
    }

    public void StopFootsteps()
    {
        footstep.SetActive(false);
    }

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameobject in enemy)
        {
            // se om fienden blir slagen
            //Debug.Log("Hit enemy");
            enemyGameobject.GetComponent<enemyHealth>().eHealth -= playerDamage;
        }
    }
    public void endAttack()
    {
        anim.SetBool("isAttacking", false);
        attacksound.SetActive(false);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
