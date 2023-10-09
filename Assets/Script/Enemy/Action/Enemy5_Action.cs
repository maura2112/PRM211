using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5_Action : MonoBehaviour
{
    [Header("Bullet/Projectile prefab")]
    [SerializeField] protected GameObject bulletPref;

    [Header("Shooting's attribute")]
    [SerializeField] protected List<Transform> shootingPoint;
    [SerializeField] protected float shootingDelay = 1f;
    [SerializeField] protected bool canShoot = true;

    [Header("Enemy's attribute")]
    [SerializeField] protected float speed = 1f;

    [Header("Enemy's Rigidbody")]
    [SerializeField] protected Rigidbody2D rb;

    private void Start()
    {
        
        
    }

    private void Reset()
    {
        this.LoadComponents();
        this.RotateShootingPoint();
    }

    private void Update()
    {
        this.Move();
        this.Attack();


    }

    protected virtual void LoadComponents()
    {
        this.rb = this.getModel().GetComponent<Rigidbody2D>();
        this.bulletPref = FindPrefs.Instance.FindPrefabByName("EnemyBullet");
        for (int i = 1; i <= 3; i++)
        {
            this.shootingPoint.Add(transform.parent.Find("Model").Find("ShootingPoint" + i).transform);
        }
    }

    private void RotateShootingPoint()
    {
        Transform leftShootingPoint = this.shootingPoint[1];
        Transform rightShootingPoint = this.shootingPoint[2];
        Quaternion leftRotation = Quaternion.Euler(0, 30, 0);
        Quaternion rightRotation = Quaternion.Euler(0, 60, 0);
        leftShootingPoint.rotation *= leftRotation;
        rightShootingPoint.rotation *= rightRotation;
    }

    protected virtual GameObject getModel()
    {
        return transform.parent.Find("Model").gameObject;
    }
    public void Attack()
    {
        if (canShoot)
        {
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(ShootingDelay(this.shootingDelay, shootingPoint[i]));
            }

        }
    }

    public void Move()
    {
        this.rb.velocity = new Vector2(0f, -speed);
        Destroy(transform.parent.gameObject, 15f);
    }

    protected virtual IEnumerator ShootingDelay(float delayTime, Transform shootpoint)
    {
        canShoot = false;
        Instantiate(this.bulletPref, shootpoint.position, Quaternion.identity);
        yield return new WaitForSeconds(delayTime);
        canShoot = true;

    }
}
