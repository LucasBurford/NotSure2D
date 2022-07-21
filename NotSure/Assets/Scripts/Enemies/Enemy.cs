using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public Player player;
    public AIPath ai;
    public Animator animator;

    public float maxHealth;
    public float currentHealth;
    public float damage;
    public float aggroDistance;

    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        ai = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            CheckDistance();

            if (currentHealth <= 0)
            {
                isDead = true;
                Die();
            }
        }
    }

    private void CheckDistance()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= aggroDistance)
        {
            ai.canMove = true;
            ai.destination = player.transform.position;
        }
    }

    public void Die()
    {
        for (int i = 0; i <= Random.Range(0, 4); i++)
        {
            Instantiate(Resources.Load("XPOrb"), transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }
}
