using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Super;
    [SerializeField] private Transform firePoint;
    private bool canShoot;
    public bool canSuper;

    void Start()
    {
        canShoot = true;
        canSuper = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot == true)
        {
            shoot(10f);
        }
        if (Input.GetKey(KeyCode.Space) && canSuper == true)
        {
            superShot(3f);
        }
    }

    void shoot(float BulletSpeed)
    {
        canShoot = false;
        StartCoroutine(shootDelay(0.3f));
        GameObject bullet = Instantiate (Bullet, firePoint.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 dir = firePoint.position - transform.position;
        rb.AddForce(dir * BulletSpeed, ForceMode2D.Impulse);
    }

    IEnumerator shootDelay(float time)
    {
        yield return new WaitForSeconds(time);
        canShoot = true;
    }

    void superShot(float speed)
    {
        canSuper = false;
        GameObject super = Instantiate (Super, firePoint.position, transform.rotation);
        Rigidbody2D rb = super.GetComponent<Rigidbody2D>();
        Vector2 dir = firePoint.position - transform.position;
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
    }
}
