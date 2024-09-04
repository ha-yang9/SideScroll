using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float attackInterval = 1.0f;
    public int damage = 100;

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
            target.TakeDamage(damage);
        }
    }
}