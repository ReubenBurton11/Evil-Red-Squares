using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super : MonoBehaviour
{
    private float time;
    private bool exploding;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private Animator explosion;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            Explode(6);
        }
    }

    void Start()
    {
        time = 0;
        exploding = false;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > 2f)
        {
            Explode(6);
        }
        if (exploding == true && time > 0.5f)
        {
            Destroy(gameObject);
        }
    }

    void Explode(float radius)
    {
        time = 0;
        exploding = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        explosion.enabled = true;
        Collider2D[] Explosion = Physics2D.OverlapCircleAll(transform.position, radius, enemy);
        if (Explosion != null)
        {
            foreach (Collider2D enemy in Explosion)
            {
                enemy.gameObject.GetComponent<EnemyMovement>().enemyDie();
            }
        }
    }
}
