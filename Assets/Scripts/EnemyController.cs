using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    bool broken = true;
    Rigidbody2D rigidbody2d;
    public bool vertical;
    public float maxMoveTime = 2f;
    private float currMoveTime;
    private int direction = 1;
    Animator animator;


    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currMoveTime = maxMoveTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currMoveTime -= Time.deltaTime;
        if (currMoveTime < 0)
        {
            direction = direction * -1;
            currMoveTime = maxMoveTime;
            if (Random.Range(1, 100) > 50)
            {
                vertical = !vertical;
            }
        }

    }
    void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }
        Vector2 position = rigidbody2d.position;
        if (vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            position.y = position.y + direction * speed * Time.deltaTime;
        }
        else
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + direction * speed * Time.deltaTime;
        }

        rigidbody2d.MovePosition(position);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
            player.ChangeHealth(-1);
    }
    public void Fix()
    {
        Destroy(gameObject);
    }
}
