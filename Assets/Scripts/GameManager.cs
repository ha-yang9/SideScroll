using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform spawnPoint;
    public GameObject monsterPrefab; // ���� ������
    private List<MonsterDataLoader.MonsterData> monsterDataList;
    private int currentMonsterIndex = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        MonsterDataLoader dataLoader = new MonsterDataLoader();
        monsterDataList = dataLoader.LoadMonsterData(Application.dataPath + "/Resources/Monsters.csv");
    }

    private void Start()
    {
        SpawnNextMonster();
    }

    public void SpawnNextMonster()
    {
        if (currentMonsterIndex < monsterDataList.Count)
        {
            MonsterDataLoader.MonsterData data = monsterDataList[currentMonsterIndex];
            GameObject monsterObject = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
            Monster monster = monsterObject.GetComponent<Monster>();
            monster.Initialize(data.Name, data.Grade, data.Speed, data.Health);
            currentMonsterIndex++;
        }
        else
        {
            Debug.Log("��� ���Ͱ� ��ȯ�Ǿ����ϴ�!");
        }
    }
}
