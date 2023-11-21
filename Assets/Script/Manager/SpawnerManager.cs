using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [Header("Enemy's Prefab List")]
    [SerializeField] protected List<GameObject> enemyList = new List<GameObject>();

    [Header("Attribute for spawning")]
    [SerializeField] protected float minCooldownTimer;
    [SerializeField] protected float maxCooldownTimer;
    [SerializeField] protected int randomNumberInList;
    [SerializeField] protected int numberPerTurn;
    [SerializeField] protected bool isSpawning;

    [Header("Spawning Area")]
    [SerializeField] protected Collider2D spawingSize;
    [SerializeField] protected Vector2 spawningPoint;



    private void Start()
    {

    }

    private void Reset()
    {
        LoadComponents();
        this.minCooldownTimer = 2f;
        this.maxCooldownTimer = 5f;
        Debug.Log("Time of random number enemies in list and enemies per turn is changing during the game!");
    }

    private void Update()
    {
        if (!isSpawning)
        {
            StartCoroutine(Spawning());
        }

    }


    protected virtual void LoadComponents()
    {
        for (int i = 1; i <= 4; i++)
        {
            this.enemyList.Add(FindPrefs.Instance.FindPrefabByName("Enemy" + i));
            //this.enemyList.Add(FindPrefs.Instance.FindPrefabByName("Enemy" + i));
            //this.enemyList.Add(FindPrefs.Instance.FindPrefabByName("Enemy" + i));
        }

        this.spawingSize = transform.parent.Find("Size").gameObject.GetComponent<Collider2D>();
    }

    protected virtual IEnumerator Spawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            float cooldownTimer = Random.Range(minCooldownTimer, maxCooldownTimer);
            this.randomNumberInList = Random.Range(0, this.enemyList.Count);
            this.spawningPoint = GetRandomPointInCollider(spawingSize);
            Instantiate(this.enemyList.ToArray()[randomNumberInList], spawningPoint, Quaternion.identity);
            yield return new WaitForSeconds(cooldownTimer);
            isSpawning=false;
           
        }
    }
    //làm thêm phần để khi nó triệu hồi, zoom max thì nó mới bắt đầu hành động
    Vector2 GetRandomPointInCollider(Collider2D collider)
    {
        Vector2 randomPoint = Vector2.zero;

        BoxCollider2D boxCollider = (BoxCollider2D)collider;
        randomPoint = new Vector2(
            Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x),
            Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y)
        );
        return randomPoint;
    }










}
