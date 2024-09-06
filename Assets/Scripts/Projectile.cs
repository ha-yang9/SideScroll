using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5.0f; // ����ü �ӵ�
    private Transform target;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D ��������
    }

    public void Launch(Transform target)
    {
        this.target = target; // Ÿ�� ����
        if (rb != null)
        {
            // Ÿ�� �������� ����ü �̵� ���� ����
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed; // �ӵ� ����
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Monster")) // �������� Ȯ��
        {
            Monster monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(100); // ���Ϳ��� 100 ������
            }
            else
            {
                Debug.Log("No Monster component found on this object.");
            }

            Destroy(gameObject); // ����ü ����
        }
        else
        {
            Debug.Log("Collision with a non-monster object");
        }
    }
}
