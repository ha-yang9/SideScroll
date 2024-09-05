using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float attackInterval = 1.0f;
    public int damage = 100;
    public GameObject attackPrefab; // 투사체 프리팹

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);
            Attack();
        }
    }

    private void Attack()
    {
        Monster target = FindObjectOfType<Monster>();

        if (target != null)
        {
            // 투사체 생성 후 타겟 지정
            GameObject attackEffect = Instantiate(attackPrefab, transform.position, Quaternion.identity);
            Projectile projectile = attackEffect.GetComponent<Projectile>();
            projectile.Launch(target.transform); // 몬스터를 타겟으로 설정
        }
    }
}