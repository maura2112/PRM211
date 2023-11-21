using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectEnemyBullet : EnemyBullet
{
    public override void Start()
    {
        //base.Start();
        this.Spawning(this.direction);
    }

    public virtual void Spawning(Vector2 direction) 
    {
        GameObject obj = (GameObject)Instantiate(shoot_effect, transform.position - new Vector3(0, 0, 5), Quaternion.identity); //Spawn muzzle flash
        this.rb.velocity = direction * speed;
        Destroy(gameObject, 5f); //Bullet will despawn after 5 seconds
    }
}
