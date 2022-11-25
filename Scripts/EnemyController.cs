using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletP;
    private float lastShoot;
    private int health = 2;
    public int scoreGive = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        Vector2 direction = player.transform.position - transform.position;
        if(direction.x >= 0.0f)
        {
            transform.localScale = new Vector2(1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector2(-1.0f, 1.0f);
        }

        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);

        if(distance < 1.0f && Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }

    }

    private void Shoot()
    {
        Vector3 direc;
        if (transform.localScale.x == 1.0f)
        {
            direc = Vector2.right;
        }
        else
        {
            direc = Vector2.left;
        }
        GameObject bullet = Instantiate(bulletP, transform.position + direc * 0.1f, Quaternion.identity);

        bullet.GetComponent<Bullet>().SetDirection(direc);
        AudioController.obj.playShoot();
    }

    public void Hit()
    {
        health--;
        if(health == 0)
        {
            UIManager.obj.addScore(scoreGive);
            UIManager.obj.updateScore();
            Destroy(gameObject);
        }
    }
}
