using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float pHealth;
    public float pcurrentHealth;
    public float maxHealth;
    public Image healthBar;
    public GameManagerScript gameManager;
    public GameObject deathsound;
    public static bool isDead;
    private Animator anim;
    void Start()
    {
        maxHealth = pHealth;
        anim = GetComponent<Animator>();
        pcurrentHealth = pHealth;
        isDead = false;
        deathsound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(pcurrentHealth / maxHealth, 0, 1);

        if (pHealth < pcurrentHealth)
        {
            pcurrentHealth = pHealth;
            anim.SetTrigger("isAttacked");
        }

        if (pHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            anim.SetBool("isDead", true);
            deathsound.SetActive(true);
            StartCoroutine(DisablePlayer());
        
        }
    }
    private IEnumerator DisablePlayer()
    {
        yield return new WaitForSeconds(0.45f);
        gameObject.SetActive(false);
    }
}
