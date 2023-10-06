using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FindPrefs : MonoBehaviour
{
    protected static FindPrefs instance;
    public static FindPrefs Instance { get => instance; }

    private void Awake()
    {
        if (FindPrefs.instance != null)
        {
            Debug.LogError("Only 1 FindPrefs allow to exist!");
        }
        FindPrefs.instance = this;
    }
    private void Reset()
    {
        if (FindPrefs.instance != null)
        {
            Debug.LogError("Only 1 FindPrefs allow to exist!");
        }
        FindPrefs.instance = this;
    }

    public virtual GameObject FindPrefabByName(string targetName)
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
}
