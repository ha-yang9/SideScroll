using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5.0f; // 투사체 속도
    private Transform target;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 가져오기
    }

    public void Launch(Transform target)
    {
        this.target = target; // 타겟 설정
        if (rb != null)
        {
            // 타겟 방향으로 투사체 이동 방향 설정
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed; // 속도 설정
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Monster")) // 몬스터인지 확인
        {
            Monster monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(100); // 몬스터에게 100 데미지
            }
            else
            {
                Debug.Log("No Monster component found on this object.");
            }

            Destroy(gameObject); // 투사체 제거
        }
        else
        {
            Debug.Log("Collision with a non-monster object");
        }
    }
}
