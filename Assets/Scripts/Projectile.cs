using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5.0f; // ����ü �ӵ�
    private Transform target;

    public void Launch(Transform target)
    {
        this.target = target; // Ÿ�� ����
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Ÿ���� ������ ����ü ����
            return;
        }

        // Ÿ������ �̵�
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Ÿ�ٿ� �������� ��
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            Destroy(gameObject); // ����ü ����
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster")) // �������� Ȯ��
        {
            // ���Ϳ��� ������ �ֱ�
            Monster monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(100); // ���Ϳ��� 100 ������
            }
            Destroy(gameObject); // ����ü ����
        }
    }
}
