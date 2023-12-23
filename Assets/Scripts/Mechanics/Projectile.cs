using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public int damage;
    public float lifetime;

    [HideInInspector]
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0) lifetime = 2.0f;
        if (damage <= 0) damage = 2;

        GetComponent <Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Geometry"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("enemy") && gameObject.CompareTag("playerprojectile"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gamemanager.Instance.Lives--;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
