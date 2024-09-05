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
    public Slider healthBar; // ü�¹�

    private Coroutine moveCoroutine;

    private void Start()
    {
        if (healthBar != null)
        {
            // ü�� �� �ʱ�ȭ
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        // �̵� ��ƾ ����
        moveCoroutine = StartCoroutine(MoveRoutine());
    }

    // ���� ������ �ʱ�ȭ �޼���
    public void Initialize(string name, string grade, float speed, int health)
    {
        this.monsterName = name;
        this.grade = grade;
        this.speed = speed;
        this.maxHealth = health;
        this.currentHealth = health;

        // ü�� �� �ʱ�ȭ (�ٽ� ����)
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    // ���� Ŭ�� �� ���� �˾� ȣ��
    private void OnMouseDown()
    {
        MonsterInfoPopup popup = FindObjectOfType<MonsterInfoPopup>();
        if (popup != null)
        {
            popup.SetMonsterInfo(this);
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

    // ���Ͱ� �������� ���� �� ȣ��
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (healthBar != null)
        {
            Debug.Log("�ƾ�!");
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ���Ͱ� ���� �� ȣ��
    private void Die()
    {
        // �̵� ��ƾ �ߴ�
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        // ���� �ı�
        Destroy(gameObject);

        // ���� ���� ��ȯ
        GameManager.Instance.SpawnNextMonster();
    }
}
