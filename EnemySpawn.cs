using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float time;
    public float enemies;
    [SerializeField] private GameObject Enemy;

    void Start()
    {
        time = 5;
        enemies = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            StartCoroutine(SpawnWave(enemies));
        }
    }

    IEnumerator SpawnWave(float enemiesToSpawn)
    {
        time = 10;
        if (enemiesToSpawn > 0)
        {
            enemiesToSpawn -= 1;
            yield return new WaitForSeconds(1f);
            GameObject enemy = Instantiate (Enemy, transform.position, transform.rotation);
            StartCoroutine(SpawnWave(enemiesToSpawn));
        }
        enemies = enemies * enemies + 1;
        enemies = Mathf.Sqrt(enemies);
    }
}
