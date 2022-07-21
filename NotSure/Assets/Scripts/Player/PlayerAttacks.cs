using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public Transform attackPoint;

    public float attackRange;
    public float attackDamage;
    public float defaultAttackDamage;

    public void Attack(int combo)
    {
        if (combo == 3)
        {
            attackDamage *= 2;
        }
        else
        {
            attackDamage = defaultAttackDamage;
        }

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        if (hitObjects.Length > 0)
        {
            foreach (Collider2D col in hitObjects)
            {
                if (col.GetComponent<Enemy>())
                {
                    col.SendMessageUpwards("TakeDamage", attackDamage);
                }
            }
        }
    }
}
