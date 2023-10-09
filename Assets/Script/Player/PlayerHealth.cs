using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private static PlayerHealth instance;
    public static PlayerHealth Instance { get => instance; }

    [SerializeField] protected float currentHealth = 10;
    [SerializeField] protected float maxHealth = 10;

    private void Awake()
    {
        if (PlayerHealth.instance != null)
        {
            Debug.LogError("Only 1 PlayerHealth allow to exist!");
        }
        PlayerHealth.instance = this;
    }

    public virtual void LoseHP(float amount)
    {
        this.currentHealth -= amount;
        if (this.currentHealth <= 0)
        {
            Destroy(GameObject.Find("Player"));
        }
    }

    public virtual void HealHP(float amount)
    {
        this.currentHealth += amount;
    }


}
