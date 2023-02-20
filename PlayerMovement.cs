using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Camera cam;
    private float movementSpeed = 500f;
    private Vector2 mousePos;
    private Vector2 aimDirection;

    void Update()
    {
        cam.transform.position = new Vector3(rb.position.x, rb.position.y, -10);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(aimDirection.x, aimDirection.y) * Mathf.Rad2Deg + 90f;
        rb.rotation = -angle;
    }

    void FixedUpdate()
    {
        //WASD movements
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * movementSpeed * Time.deltaTime);
        }
    }
}
