using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;

    private GameObject target;
    
    private Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
    
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

        // check what speeds the player is at so you can shoot at appropriate speeds too
        if (target.GetComponent<Rigidbody2D>().velocity.magnitude < 4)
        {
            moveDirection = (target.transform.position - transform.position).normalized * 10f;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
        if (target.GetComponent<Rigidbody2D>().velocity.magnitude > 4 && target.GetComponent<Rigidbody2D>().velocity.magnitude < 10 )
        {
            moveDirection = (target.transform.position - transform.position).normalized * 15f;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
        if (target.GetComponent<Rigidbody2D>().velocity.magnitude > 10)
        {
            moveDirection = (target.transform.position - transform.position).normalized * 20f;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }

        Destroy(gameObject,5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate (0,0,360*Time.deltaTime);
    }
}
