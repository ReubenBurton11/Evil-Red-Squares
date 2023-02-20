using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameManager GameManager;
    private Vector3 dir;
    private Transform Player;
    [SerializeField] private Rigidbody2D rb;
    private float movementSpeed;
    private float speedMultiplier;

    void Start()
    {
        speedMultiplier = 0.5f * Mathf.Sqrt(GameObject.Find("UI Manager").GetComponent<UIManager>().tSS);
        if (speedMultiplier < 3f)
        {
            movementSpeed = 3f;
        }
        else
        {
            movementSpeed = speedMultiplier;
        }
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Player = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        dir = Player.position - transform.position;
    }

    void FixedUpdate()
    {
        transform.position += dir.normalized * movementSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(GameManager.GetComponent<GameManager>().Die());
            Destroy(other.gameObject);
        }
    }

    public void enemyDie()
    {
        GameObject.Find("UI Manager").GetComponent<UIManager>().AddPoints(5);
        Destroy(gameObject);
    }
}
