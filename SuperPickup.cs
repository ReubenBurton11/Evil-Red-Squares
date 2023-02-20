using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPickup : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Vector2 dir = player.position - transform.position;
            rb.AddForce(dir.normalized * 5);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "base")
        {
            other.gameObject.GetComponentInParent<Shoot>().canSuper = true;
            GameObject superPickup = Instantiate (gameObject, new Vector3(Random.Range(-40, 40), Random.Range(-28, 28), 0), transform.rotation);
            Destroy(gameObject);
        }
    }
}
