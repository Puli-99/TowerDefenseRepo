using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Gives health to the enemy and kills the enemy if his health is over, additionally gives to the GO the Enemy component and increase heal over kills;
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    int health = 0;
    [SerializeField] int maxHealth = 5;
    [Tooltip("Adds amount to maxHealth when enemy dies")]
    [SerializeField] int increaseHealth = 1;

    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {        
        health = maxHealth;
    }
    void OnParticleCollision (GameObject other)
    {
        ProcessHit();
        if (health <= 0)
        {
            gameObject.SetActive(false);
            maxHealth += increaseHealth;
            enemy.RewardGold();
        }
    }

    void ProcessHit()
    {
        health --;
    }
}