using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(Animator))]
public class Enemy : MonoBehaviour
{
    protected SpriteRenderer sr;
    protected Animator anim;
    public AudioSourceManager asm;
    public canvasmanager cm;

    public int _health;
    private Collider2D enemycollider;
    public int maxhealth;
    public AudioClip explode;


    // Start is called before the first frame update
    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        asm = GetComponent
            <AudioSourceManager>();
        cm = GetComponent<canvasmanager>();

        if (maxhealth <= 0)
            maxhealth = 5;

        _health = maxhealth;


    }

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0) {
            anim.SetTrigger("Death");
            enemycollider = GetComponent<Collider2D>();
            enemycollider.GetComponent<Collider2D>().isTrigger = true ;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            asm.PlayOneShot(explode, false);
            gamemanager.Instance.score++;
           
            Destroy(gameObject, 0.9f);
           
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            gamemanager.Instance.Lives--;
    }
}

   
