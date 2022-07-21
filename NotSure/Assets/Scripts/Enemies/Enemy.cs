using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject xpOrb;

    public float maxHealth;
    public float currentHealth;

    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (currentHealth <= 0)
            {
                isDead = true;
                Die();
            }
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
