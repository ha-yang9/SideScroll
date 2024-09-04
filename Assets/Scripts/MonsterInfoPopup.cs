using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInfoPopup : MonoBehaviour
{
    public Text nameText;
    public Text gradeText;
    public Text speedText;
    public Text healthText;

    public void SetMonsterInfo(Monster monster)
    {
        nameText.text = "Name: " + monster.monsterName;
        gradeText.text = "Grade: " + monster.grade;
        speedText.text = "Speed: " + monster.speed.ToString();
        healthText.text = "Health: " + monster.maxHealth.ToString();
    }
}