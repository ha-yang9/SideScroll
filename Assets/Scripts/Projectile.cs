using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5.0f; // 투사체 속도
    private Transform target;

    public void Launch(Transform target)
    {
        this.target = target; // 타겟 설정
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // 타겟이 없으면 투사체 제거
            return;
        }

        // 타겟으로 이동
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // 타겟에 도달했을 때
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            Destroy(gameObject); // 투사체 제거
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster")) // 몬스터인지 확인
        {
            // 몬스터에게 데미지 주기
            Monster monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(100); // 몬스터에게 100 데미지
            }
            Destroy(gameObject); // 투사체 제거
        }
    }
}
