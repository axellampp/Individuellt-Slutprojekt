using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyManager : MonoBehaviour
{
    [Header("---------- GameObjects ---------")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject door;
    public GameObject keyNotFoundText;
    public GameObject keyFoundText;
    public GameObject pickupSound;

    [Header("---------- Values ----------")]
    public bool isPickedUp;
    private Vector2 vel;
    public float smoothTime;
    private SinMovement sin;

    void Start()
    {
        sin = GetComponent<SinMovement>();
        keyFoundText.SetActive(false);
        pickupSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            Vector3 offset = new Vector3(0, 1, 0);
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position + offset, ref vel, smoothTime);
            keyNotFoundText.SetActive(false);
            keyFoundText.SetActive(true);
            pickupSound.SetActive(true);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
            sin.enabled = !sin.enabled;
            door.GetComponent<door>().keyPickedUp = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, door.transform.position);
    }

}
