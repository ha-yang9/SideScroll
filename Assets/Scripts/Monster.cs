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
    public Slider healthBar; // 체력바

    private Coroutine moveCoroutine;

    private void Start()
    {
        if (healthBar != null)
        {
            // 체력 바 초기화
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        // 이동 루틴 시작
        moveCoroutine = StartCoroutine(MoveRoutine());
    }

    // 몬스터 데이터 초기화 메서드
    public void Initialize(string name, string grade, float speed, int health)
    {
        this.monsterName = name;
        this.grade = grade;
        this.speed = speed;
        this.maxHealth = health;
        this.currentHealth = health;

        // 체력 바 초기화 (다시 세팅)
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    // 몬스터 클릭 시 정보 팝업 호출
    private void OnMouseDown()
    {
        MonsterInfoPopup popup = FindObjectOfType<MonsterInfoPopup>();
        if (popup != null)
        {
            popup.SetMonsterInfo(this);
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

    // 몬스터가 데미지를 입을 때 호출
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (healthBar != null)
        {
            Debug.Log("아야!");
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 몬스터가 죽을 때 호출
    private void Die()
    {
        // 이동 루틴 중단
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        // 몬스터 파괴
        Destroy(gameObject);

        // 다음 몬스터 소환
        GameManager.Instance.SpawnNextMonster();
    }
}
