using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet/Projectile's Effect")]
    [SerializeField]protected GameObject shoot_effect;
    [SerializeField]protected GameObject hit_effect;

    [Header("Bullet/Projectile's Rigidbody")]
    [SerializeField] protected Rigidbody2D rb;
 
    // Use this for initialization
    void Start()
    {
       this.SpawnBullet();
    }

    private void Reset()
    {
        this.LoadComponents();
    }
    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void SpawnBullet()
    {
        GameObject obj = (GameObject)Instantiate(shoot_effect, transform.position, Quaternion.identity); //Spawn muzzle flash
        Destroy(gameObject, 5f); //Bullet will despawn after 5 seconds
    }
    protected virtual void LoadComponents()
    {
        this.shoot_effect = FindPrefabByName("Muzzle Flash");
        this.hit_effect = FindPrefabByName("Explosion");
        this.rb = gameObject.GetComponent<Rigidbody2D>();
    }

    protected virtual GameObject FindPrefabByName(string targetName)
    {
        string[] allPrefabPaths = AssetDatabase.FindAssets("t:Prefab");

        foreach (string prefabPath in allPrefabPaths)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(prefabPath);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);

            if (prefab != null && prefab.name == targetName)
            {
                Debug.Log("Found: " + prefab.name);
                Selection.activeObject = prefab;
                return prefab;
            }
        }
        Debug.Log("Not Found: " + targetName);
        return null;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        //Don't want to collide with the ship that's shooting this thing, nor another projectile.
        if ( col.gameObject.tag != "Projectile" && col.gameObject.tag!="Player")
        {
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
