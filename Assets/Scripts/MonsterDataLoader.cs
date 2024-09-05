using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MonsterDataLoader : MonoBehaviour
{
    public List<MonsterData> LoadMonsterData(string filePath)
    {
        List<MonsterData> monsterDataList = new List<MonsterData>();
        TextAsset csvFile = Resources.Load<TextAsset>(filePath);

        if (csvFile == null)
        {
            Debug.LogError("CSV file not found at path: " + filePath);
            return monsterDataList;
        }

        using (StringReader reader = new StringReader(csvFile.text))
        {
            bool isFirstLine = true;
            while (reader.Peek() > -1)
            {
                string line = reader.ReadLine();
                if (isFirstLine)
                {
                    isFirstLine = false; // 첫 줄은 제목이니까 건너뜀
                    continue;
                }

                string[] values = line.Split(',');

                // 몬스터 데이터를 생성해서 리스트에 추가
                MonsterData newMonster = new MonsterData(values[0], values[1], float.Parse(values[2]), int.Parse(values[3]));
                monsterDataList.Add(newMonster);
            }
        }

        return monsterDataList;
    }

    public class MonsterData
    {
        public string Name;
        public string Grade;
        public float Speed;
        public int Health;

        public MonsterData(string name, string grade, float speed, int health)
        {
            this.Name = name;
            this.Grade = grade;
            this.Speed = speed;
            this.Health = health;
        }
    }
}
