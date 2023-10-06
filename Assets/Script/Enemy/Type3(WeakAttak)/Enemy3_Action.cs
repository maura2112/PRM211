using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy3_Action : MonoBehaviour,IEnemy
{
    [Header("Bullet/Projectile prefab")]
    [SerializeField] protected GameObject bulletPref;

    [Header("Shooting's attribute")]
    [SerializeField] protected Transform shootingPoint;
    [SerializeField] protected float shootingDelay = 1f;
    [SerializeField] protected bool canShoot = true;

    [Header("Enemy's attribute")]
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float zigzagDistance = 2.5f;
    [SerializeField] protected Vector3 startPosition;

    [Header("Enemy's Rigidbody")]
    [SerializeField] protected Rigidbody2D rb;

    private void Start()
    {
    }
    private void Reset()
    {
        this.LoadComponents();
    }

    private void Update()
    {
        this.Move();
        this.Attack();

    }

    protected virtual void LoadComponents()
    {
        this.rb = this.getModel().GetComponent<Rigidbody2D>();
        this.startPosition = this.getModel().transform.position;
        this.bulletPref = FindPrefabByName("Bullet"); ;
        this.shootingPoint = transform.parent.Find("Model").Find("ShootingPoint").transform ;
        this.Flip();
    }

    protected virtual void Flip()
    {
        Vector2 currentScale = getModel().transform.localScale;
        currentScale.x *= -1;
        getModel().transform.localScale = currentScale;
    }

    protected virtual GameObject getModel()
    {
        return transform.parent.Find("Model").gameObject;
    }
    public void Attack()
    {
        if (canShoot)
        {
            StartCoroutine(ShootingDelay(this.shootingDelay));
        }
    }

    public void Move()
    {
        float newX = this.startPosition.x + Mathf.Sin(Time.time * speed) * zigzagDistance;
        Vector3 newPosition = new Vector3(newX, this.getModel().transform.position.y, this.getModel().transform.position.z);
        this.getModel().transform.position = newPosition;
        Destroy(transform.parent.gameObject, 10f);
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


    protected virtual IEnumerator ShootingDelay(float delayTime)
    {
        canShoot = false;
        Instantiate(this.bulletPref, this.shootingPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(delayTime);
        canShoot = true;

    }
}