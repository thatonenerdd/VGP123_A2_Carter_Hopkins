using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootScript))]
public class TurretEnemy : Enemy
{
    public float projectilfirerate;
   
    public float Distthreshhold;
    

    public float timesincelastfire = 0;

    // Start is called before the first frame update
    public override void Start()
    {
        if (projectilfirerate <= 0) { projectilfirerate = 2; };
        base.Start();
        if (Distthreshhold <= 0) Distthreshhold = 6.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);


        float distance = Vector3.Distance(gamemanager.Instance.playerInstance.transform.position, transform.position);

        if (distance <= Distthreshhold)
        {
            sr.color = Color.green;
            if (curPlayingClips[0].clip.name != "HammerJoeThrow")
            {
                if (Time.time >= timesincelastfire + projectilfirerate)
                {
                    anim.SetTrigger("shoot");
                    timesincelastfire = Time.time;
                }
            }
        }
        else
        {
            sr.color = Color.white;
        }
        if (gamemanager.Instance.playerInstance == null) return;
        if (gamemanager.Instance.playerInstance.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        else
            sr.flipX = false;
        }
    }
