using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour, IProjectile
{
    [Header("Bullet's attribute")]
    [SerializeField] protected float speed = 5;
    [SerializeField] protected float dmg = 1;

    [Header("Bullet's Effect")]
    [SerializeField]protected GameObject shoot_effect;
    [SerializeField]protected GameObject hit_effect;

    [Header("Bullet's Rigidbody")]
    [SerializeField] protected Rigidbody2D rb;


 
    // Use this for initialization
    void Start()
    {
       this.Spawn();
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

        if ( col.gameObject.tag != "Projectile" && col.gameObject.tag!="Player" && col.gameObject.tag != "SpawnPlane")
        {
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(col.transform.parent.gameObject);
        }

    }

    public virtual void Spawn()
    {
        GameObject obj = (GameObject)Instantiate(shoot_effect, transform.position - new Vector3(0, 0, 5), Quaternion.identity); //Spawn muzzle flash
        this.rb.velocity = new Vector2(0f, speed);
        Destroy(gameObject, 5f); //Bullet will despawn after 5 seconds
    }

    
}
