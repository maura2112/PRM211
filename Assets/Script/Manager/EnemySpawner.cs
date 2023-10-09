using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("List Enemy")]
    [SerializeField] GameObject[] enemyPrefs;

    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }

    private void Awake()
    {
        if (EnemySpawner.instance != null)
        {
            Debug.LogError("Only 1 EnemySpawner allow to exist!");
        }
        EnemySpawner.instance = this;
    }
}
