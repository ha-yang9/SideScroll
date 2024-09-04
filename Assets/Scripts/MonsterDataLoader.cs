using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MonsterDataLoader : MonoBehaviour
{
    public class MonsterData
    {
        public string Name;
        public string Grade;
        public float Speed;
        public int Health;
    }

    public List<MonsterData> LoadMonsterData(string filePath)
    {
        List<MonsterData> monsterDataList = new List<MonsterData>();
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            if (line.StartsWith("Name")) continue; // Header °Ç³Ê¶Ù±â

            string[] values = line.Split(',');
            MonsterData data = new MonsterData
            {
                Name = values[0],
                Grade = values[1],
                Speed = float.Parse(values[2]),
                Health = int.Parse(values[3])
            };
            monsterDataList.Add(data);
        }

        return monsterDataList;
    }
}
