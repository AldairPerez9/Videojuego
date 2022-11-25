using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rig2D;
    public float speed;
    private Vector2 dir;

    private void Awake()
    {
        rig2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig2D.velocity = dir * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        dir = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        EnemyController enemy = collision.GetComponent<EnemyController>();

        if(player != null)
        {
            player.Hit();
        }
        if(enemy != null)
        {
            enemy.Hit();
        }
        DestroyBullet();
    }
}

 