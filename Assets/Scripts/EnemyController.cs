using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody2d;
    public bool vertical;
    public float maxMoveTime = 2f;
    private float currMoveTime;
    private int direction;
    private bool random;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currMoveTime = maxMoveTime;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        currMoveTime -= Time.deltaTime;
        if (currMoveTime < 0)
        {
            direction = direction * -1;
            currMoveTime = maxMoveTime;
            if (Random.Range(1,100) > 50){
            vertical = !vertical;
        }
        }
        
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        if (vertical)
        {
            position.y = position.y + direction * speed * Time.deltaTime;
        }
        else
        {
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
}
