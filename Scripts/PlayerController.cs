using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController obj;


    public GameObject bulletP;
    private Rigidbody2D rb2D;
    private Animator animator;
    public float horizontal;
    public float jump = 3;
    public float lastShoot;
    public int health = 5;

    public bool isImmune = false;
    public float immuneTimeCnt = 0.0f;
    public float immuneTime = 0.5f;
    private SpriteRenderer spr;

    private void Awake()
    {
        obj = this;
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.obj.gamePause)
        {
            horizontal = 0.0f;
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0.0f)
        {
            transform.localScale = new Vector2(-1.0f, 1.0f);
        }
        else if (horizontal > 0.0f)
        {
            transform.localScale = new Vector2(1.0f, 1.0f);
        }


        if (isImmune)
        {
            spr.enabled = !spr.enabled;
            immuneTimeCnt -= Time.deltaTime;
            if (immuneTimeCnt <= 0.0f)
            {
                isImmune = false;
                spr.enabled = true;

            }

        }
    }
    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(horizontal, rb2D.velocity.y);
        if (Input.GetButton("Jump") && Jump.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jump);
            AudioController.obj.playJump();
        }

        if (Input.GetButtonDown("Fire1") && Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.deltaTime;
        }

        if (Jump.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if (Jump.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Run", horizontal != 0.0f);
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
        GameObject bullet = Instantiate(bulletP, transform.position + direc * 0.14f, Quaternion.identity);

        bullet.GetComponent<Bullet>().SetDirection(direc);
        AudioController.obj.playShoot();
    }

    public void addLive()
    {
        health++;
    }

    public void Hit()
    {
        if(health <= 0)
        {
            return;
        }
        health--;
        goImmune();
        UIManager.obj.updateLives();
        if(health == 0)
        {
            animator.SetBool("Dead", true);
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnDestroy()
    {
        obj = null;
    }

    public void goImmune()
    {
        isImmune = true;
        immuneTimeCnt = immuneTime;
    }
}
