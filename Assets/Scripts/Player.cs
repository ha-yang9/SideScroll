using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float attackInterval = 1.0f;
    public int damage = 100;
    public GameObject attackPrefab; // ����ü ������

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
            // ����ü ���� �� Ÿ�� ����
            GameObject attackEffect = Instantiate(attackPrefab, transform.position, Quaternion.identity);
            Projectile projectile = attackEffect.GetComponent<Projectile>();
            projectile.Launch(target.transform); // ���͸� Ÿ������ ����
        }
    }
}