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
    public Slider healthBar; // ü�¹� UI

    private void Start()
    {
        // ü�� �ʱ� ����
        InitializeHealthBar();
        StartCoroutine(MoveRoutine());
    }

    // ���� �ʱ�ȭ �Լ� (���� ���� �Է�)
    public void Initialize(string name, string grade, float speed, int health)
    {
        monsterName = name;
        this.grade = grade;
        this.speed = speed;
        maxHealth = health;
        currentHealth = health;
        InitializeHealthBar(); // ü�¹� �ʱ�ȭ
    }

    // ü�¹� �ʱ�ȭ
    private void InitializeHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    // ���� ���� �˾� ���� (���콺 Ŭ�� ��)
    private void OnMouseDown()
    {
        MonsterInfoPopup popup = FindObjectOfType<MonsterInfoPopup>();
        if (popup != null)
        {
            popup.SetMonsterInfo(this); // ���� ���� ���� ����
        }
    }

    // ���� �̵� ��ƾ
    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            // �������� �̵�
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }
    }

    // ����� �޴� �Լ�
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ü�¹� ������Ʈ
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }

    // ���Ͱ� �׾��� �� ȣ��
    private void Die()
    {
        Destroy(gameObject); // ���� ���� ����
        GameManager.Instance.SpawnNextMonster(); // ���� ���� ����
    }
}
