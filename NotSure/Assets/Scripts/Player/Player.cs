using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider healthSlider;

    public int playerLevel;

    public float maxHealth;
    public float currentHealth;

    public float currentXP;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    } 

    public void GiveXP()
    {
        currentXP += Random.Range(10, 25);
    }
}
