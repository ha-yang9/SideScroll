using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public string monsterName;
    public string grade;
    public float speed;
    public int maxHealth;
    public int currentHealth;
    public Slider healthBar; // Ã¼·Â¹Ù

    private void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        StartCoroutine(MoveRoutine());
    }

    public void Initialize(string name, string grade, float speed, int health)
    {
        monsterName = name;
        this.grade = grade;
        this.speed = speed;
        maxHealth = health;
        currentHealth = health;
    }

    private void OnMouseDown()
    {
        MonsterInfoPopup popup = FindObjectOfType<MonsterInfoPopup>();
        if (popup != null)
        {
            popup.SetMonsterInfo(this);
        }
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.SpawnNextMonster();
    }
}
