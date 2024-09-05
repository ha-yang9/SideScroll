using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public List<GameObject> monsterPrefabs;
    private Queue<GameObject> monsterQueue = new Queue<GameObject>();

    private GameObject currentMonster;

    private void Start()
    {
        foreach (var prefab in monsterPrefabs)
        {
            monsterQueue.Enqueue(prefab);
        }

        SpawnNextMonster();
    }
    public void SpawnNextMonster()
    {
        if (monsterQueue.Count > 0)
        {
        if (currentMonster != null)
        {
            Destroy(currentMonster);
        }

        GameObject nextMonsterPrefab = monsterQueue.Dequeue();
            currentMonster = Instantiate(nextMonsterPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        }
        else
        {
            Debug.Log("몬스터가 생성되었습니다.");
        }
    }
}
