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
    public Slider healthBar; // 체력바 UI

    private void Start()
    {
        // 체력 초기 설정
        InitializeHealthBar();
        StartCoroutine(MoveRoutine());
    }

    // 몬스터 초기화 함수 (몬스터 정보 입력)
    public void Initialize(string name, string grade, float speed, int health)
    {
        monsterName = name;
        this.grade = grade;
        this.speed = speed;
        maxHealth = health;
        currentHealth = health;
        InitializeHealthBar(); // 체력바 초기화
    }

    // 체력바 초기화
    private void InitializeHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    // 몬스터 정보 팝업 띄우기 (마우스 클릭 시)
    private void OnMouseDown()
    {
        MonsterInfoPopup popup = FindObjectOfType<MonsterInfoPopup>();
        if (popup != null)
        {
            popup.SetMonsterInfo(this); // 현재 몬스터 정보 설정
        }
    }

    // 몬스터 이동 루틴
    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            // 왼쪽으로 이동
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }
    }

    // 대미지 받는 함수
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 체력바 업데이트
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }

    // 몬스터가 죽었을 때 호출
    private void Die()
    {
        Destroy(gameObject); // 현재 몬스터 제거
        GameManager.Instance.SpawnNextMonster(); // 다음 몬스터 스폰
    }
}
