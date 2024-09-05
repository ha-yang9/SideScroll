using System.Collections;
using System.Collections.Generic;
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

        // 첫 번째 몬스터를 스폰
        SpawnNextMonster();
    }

    public void SpawnNextMonster()
    {
        if (monsterQueue.Count > 0)
        {
            // 이전 몬스터가 존재하면 제거
            if (currentMonster != null)
            {
                Destroy(currentMonster);
            }

            GameObject nextMonsterPrefab = monsterQueue.Dequeue();
            currentMonster = Instantiate(nextMonsterPrefab, new Vector3(5, 0, 0), Quaternion.identity); // 원하는 위치에 스폰
        }
        else
        {
            Debug.Log("모든 몬스터가 죽었습니다!");
        }
    }
}
