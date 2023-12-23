using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class WalkingEnemy : Enemy
{
    Rigidbody2D rb;

    public float xSpeed;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();

        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;


    }

    public override void TakeDamage(int damage)
    {
        Destroy(transform.parent.gameObject, 0.9f);
        base.TakeDamage(damage);
    }



    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);

        if (curPlayingClips[0].clip.name == "Metwalk")


        {
            rb.velocity = sr.flipX ? rb.velocity = new Vector2(xSpeed, rb.velocity.y) : rb.velocity = new Vector2(-xSpeed, rb.velocity.y);


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "barrier")
        { sr.flipX = !sr.flipX; }
    }
    }

