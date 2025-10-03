using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float time = 1f;
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
            Destroy(gameObject);
        
    }
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Fix();
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

