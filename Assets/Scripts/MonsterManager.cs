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

        // ù ��° ���͸� ����
        SpawnNextMonster();
    }

    public void SpawnNextMonster()
    {
        if (monsterQueue.Count > 0)
        {
            // ���� ���Ͱ� �����ϸ� ����
            if (currentMonster != null)
            {
                Destroy(currentMonster);
            }

            GameObject nextMonsterPrefab = monsterQueue.Dequeue();
            currentMonster = Instantiate(nextMonsterPrefab, new Vector3(5, 0, 0), Quaternion.identity); // ���ϴ� ��ġ�� ����
        }
        else
        {
            Debug.Log("��� ���Ͱ� �׾����ϴ�!");
        }
    }
}
