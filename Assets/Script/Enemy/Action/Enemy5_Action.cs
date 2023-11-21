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
        this.bulletPref = FindPrefs.Instance.FindPrefabByName("DirectBullet");
        for (int i = 1; i <= 3; i++)
        {
            this.shootingPoint.Add(transform.parent.Find("Model").Find("ShootingPoint" + i).transform);
        }
    }

    private void RotateShootingPoint()
    {
        //shootingPoint[1].rotation = Quaternion.Euler(new Vector2(Mathf.Cos(Mathf.Deg2Rad * 240), Mathf.Sin(Mathf.Deg2Rad * 240), 0).normalized);
        //Debug.Log(shootingPoint[1].rotation);
        //shootingPoint[2].rotation = Quaternion.Euler(new Vector2(Mathf.Cos(Mathf.Deg2Rad * 240), Mathf.Sin(Mathf.Deg2Rad * 240), 0).normalized);
        //shootingPoint[0].rotation = Quaternion.Euler(new Vector2.down);
    }

    protected virtual GameObject getModel()
    {
        return transform.parent.Find("Model").gameObject;
    }
    public void Attack()
    {
        if (canShoot)
        {
            StartCoroutine(ShootingDelay(this.shootingDelay, shootingPoint[0],  Vector2.down));
            StartCoroutine(ShootingDelay(this.shootingDelay, shootingPoint[1], new Vector2(Mathf.Cos(Mathf.Deg2Rad * 240), Mathf.Sin(Mathf.Deg2Rad * 240)).normalized));
            StartCoroutine(ShootingDelay(this.shootingDelay, shootingPoint[2], new Vector2(Mathf.Cos(Mathf.Deg2Rad * 270), Mathf.Sin(Mathf.Deg2Rad * 270)).normalized));
            //for (int i = 0; i < 3; i++)
            //{
            //    StartCoroutine(ShootingDelay(this.shootingDelay, shootingPoint[i]));
            //}
        }
    }

    public void Move()
    {
        this.rb.velocity = new Vector2(0f, -speed);
        Destroy(transform.parent.gameObject, 15f);
    }

    protected virtual IEnumerator ShootingDelay(float delayTime, Transform shootPoint, Vector2 direction)
    {
        canShoot = false;
        Instantiate(this.bulletPref, shootPoint.position, Quaternion.identity);
        this.bulletPref.GetComponent<Rigidbody2D>().velocity = direction * 8;
        yield return new WaitForSeconds(delayTime);
        canShoot = true;

    }
}
