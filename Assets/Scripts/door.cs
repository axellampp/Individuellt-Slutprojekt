using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public bool locked;
    public bool keyPickedUp;
    private Animator anim;
    public string getscene;

    [SerializeField] GameObject player;

    void Start()
    {
        locked = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (!locked && distance < 1f)
        {
            StartCoroutine(DoorOpening());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key") && keyPickedUp)
        {
            anim.SetTrigger("Open");
            locked = false;
        }
    }
    
    private IEnumerator DoorOpening()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(getscene);
    }

}
