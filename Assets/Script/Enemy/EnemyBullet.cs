using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Bullet's attribute")]
    [SerializeField] protected float speed = 8;
    [SerializeField] protected float dmg = 1;
    [SerializeField] public Vector2 direction;

    [Header("Bullet's Effect")]
    [SerializeField] protected GameObject shoot_effect;
    [SerializeField] protected GameObject hit_effect;

    [Header("Bullet's Rigidbody")]
    [SerializeField] protected Rigidbody2D rb;



    // Use this for initialization
    public virtual void Start()
    {
        this.Spawn();
        //this.Spawning(this.direction);
    }

    private void Reset()
    {
        this.LoadComponents();
    }
    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void LoadComponents()
    {
        this.shoot_effect = FindPrefs.Instance.FindPrefabByName("Muzzle Flash");
        this.hit_effect = FindPrefs.Instance.FindPrefabByName("Explosion");
        this.rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag != "Enemy" && col.gameObject.tag != "Projectile" && col.gameObject.tag != "SpawnPlane")
        {
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Player")
        {
            if (col.gameObject != null)
            {
                PlayerHealth.Instance.LoseHP(this.dmg);
            }
        }

    }

    public virtual void Spawn()
    {
        GameObject obj = (GameObject)Instantiate(shoot_effect, transform.position - new Vector3(0, 0, 5), Quaternion.identity); //Spawn muzzle flash
        this.rb.velocity = new Vector2(0f, -speed);
        Destroy(gameObject, 5f); //Bullet will despawn after 5 seconds
    }

    



}
