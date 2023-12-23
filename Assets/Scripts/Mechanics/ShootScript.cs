using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    public event Action OnProjectileSpawned;

    SpriteRenderer sr;
    public float projectileSpeed;
    public Transform spawnPointRight;
    public Transform spawnPointLeft;

    public Projectile projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (projectileSpeed <= 0) projectileSpeed = 8.0f;



    }

    // Update is called once per frame
    public void Shoot()
    {
        if (sr.flipX)
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            curProjectile.speed = projectileSpeed;
        }
        else
        {
            Projectile curProjectile = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            curProjectile.speed = -projectileSpeed;
        }
        OnProjectileSpawned?.Invoke();
    }
}
