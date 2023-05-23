using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    private bool canAttack;
    public float speed;
    public float Enemydamage;
    public float attackCooldown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isWalking", true);
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            Flip();
            currentPoint = pointB.transform;
        }

    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && canAttack == true)
        {
            // Check om spelaren är bakom
            if (other.transform.position.x < transform.position.x && transform.localScale.x > 0 ||
                other.transform.position.x > transform.position.x && transform.localScale.x < 0)
            {
                // spelaren är bakom --> attackera inte
                return;
            }

            // spleran är framför --> attackera
            anim.SetBool("isAttacking", true);
            other.gameObject.GetComponent<playerHealth>().pHealth -= Enemydamage;
            rb.velocity = new Vector2(0, 0);
            canAttack = false;
            StartCoroutine(AttackCooldown());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isAttacking", false);
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;

    }

    public void EndEnemyAttack()
    {
        anim.SetBool("isAttacking", false);
    }
}
