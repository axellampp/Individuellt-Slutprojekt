using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float eHealth;
    public float ecurrentHealth;
    public GameObject player;
    public GameObject enemyfootstep;
    public GameObject enemydie;
    private bool hasDied = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ecurrentHealth = eHealth;
        enemyfootstep.SetActive(true);
        enemydie.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(eHealth < ecurrentHealth)
        {
            ecurrentHealth = eHealth;
            anim.SetTrigger("Attacked");
        }
        
        if(eHealth <= 0 && !hasDied)
        {
            hasDied = true;
            enemyfootstep.SetActive(false);
            anim.SetBool("isDead", true);
            enemyfootstep.SetActive(false);
            enemydie.SetActive(true);
            StartCoroutine(DisableEnemy());

        }
    }
    private IEnumerator DisableEnemy()
    {
        yield return new WaitForSeconds(0.45f);
        gameObject.SetActive(false);
    }

}
