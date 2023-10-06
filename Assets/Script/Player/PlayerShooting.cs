using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Bullet/Projectile prefab")]
    [SerializeField] protected GameObject bulletPref;

    [Header("Shooting's attribute")]
    [SerializeField] protected KeyCode button;
    [SerializeField] protected Transform shootingPoint;
    [SerializeField] protected float shootingDelay = 0.25f;
    [SerializeField] protected bool canShoot = true;

    private void Reset()
    {
        this.LoadComponents();
    }

    private void Update()
    {
        this.Shooting();
    }
    protected virtual void LoadComponents()
    {
        this.bulletPref = FindPrefabByName("Bullet"); ;
        this.button = KeyCode.Space;
        this.shootingPoint = transform.parent.Find("Model").Find("ShootingPoint").transform;
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

    protected virtual void Shooting()
    {
        if (Input.GetKey(this.button)){
            if (canShoot)
            {
                StartCoroutine(ShootingDelay(this.shootingDelay));
            }
        }
    }

    protected virtual IEnumerator ShootingDelay(float delayTime)
    {
        canShoot = false;
        Instantiate(this.bulletPref, this.shootingPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(delayTime);

        canShoot = true;
        
    }

}
