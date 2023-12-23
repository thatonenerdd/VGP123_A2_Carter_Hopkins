using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Build;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    AudioSourceManager asm;
    ShootScript ssc;

    Coroutine Speedchange;

    public float speed = 5.5f;
    public float jumpForce = 300.0f;
    public bool isgrounded;
    public Transform groundcheck;
    public LayerMask isGroundlayer;
    public float groundcheckradius = 0.02f;
    public int _health;
    public int maxhealth;

    public AudioClip jumpSound;
    public AudioClip shootSound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        asm = GetComponent<AudioSourceManager>();
        ssc = GetComponent<ShootScript>();


        if (_health <= 0)
        {
            _health = maxhealth;
        };
        if (rb == null)
            Debug.Log("No Rigid Body");
        if (sr == null) Debug.Log("No Sprite Renderer");

        if (groundcheckradius <= 0) groundcheckradius = 0.02f;
        if (speed <= 0) speed = 5.5f;
        if (jumpForce <= 0) jumpForce = 300.0f;

        if (groundcheck == null)
        { GameObject obj = new GameObject();
            obj.transform.SetParent(gameObject.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.name = "GroundCheck";
            groundcheck = obj.transform;
        }
        ssc.OnProjectileSpawned += OnProjectileSpawned;
    }

    void OnProjectileSpawned()
    {
        asm.PlayOneShot(shootSound, false);
    }
    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");

        isgrounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, isGroundlayer);

        if (isgrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce);
            asm.PlayOneShot(jumpSound, false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Shoot");
        }

        Debug.Log(xInput);
        Vector2 moveDirection = new Vector2(xInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        anim.SetBool("Isgrounded", isgrounded);
        anim.SetFloat("xInput", Mathf.Abs(xInput));
        if (xInput < 0 && sr.flipX || xInput > 0 && !sr.flipX)
            sr.flipX = !sr.flipX;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint")) {
            Transform newSpawnPoint = collision.transform;
            gamemanager.Instance.UpdateSpawnPoint(newSpawnPoint); }

    }
     public void StartSpeedChange()
        {

            Speedchange = StartCoroutine(SpeedChange());

        }
        IEnumerator SpeedChange()
        {
            speed = speed * 1.2f;
            yield return new WaitForSeconds(5);
            speed = 5;
            Speedchange = null;
        }
    } 
