using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform spawnPoint;
    public GameObject monsterPrefab; // 몬스터 프리팹
    private List<MonsterDataLoader.MonsterData> monsterDataList;
    private int currentMonsterIndex = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // MonsterDataLoader 인스턴스를 생성하고 메서드 호출
        MonsterDataLoader dataLoader = gameObject.AddComponent<MonsterDataLoader>();
        monsterDataList = dataLoader.LoadMonsterData("Monsters");
    }

    private void Start()
    {
        if (monsterDataList != null && monsterDataList.Count > 0)
        {
            SpawnNextMonster();
        }
        else
        {
            Debug.LogError("MonsterDataList is null or empty.");
        }
    }

    public void SpawnNextMonster()
    {
        if (currentMonsterIndex < monsterDataList.Count)
        {
            Debug.Log("소환!");
            MonsterDataLoader.MonsterData data = monsterDataList[currentMonsterIndex];
            GameObject monsterObject = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
            Monster monster = monsterObject.GetComponent<Monster>();
            monster.Initialize(data.Name, data.Grade, data.Speed, data.Health);
            currentMonsterIndex++;
        }
        else
        {
            Debug.LogError("No more monsters to spawn.");
        }
    }
}
