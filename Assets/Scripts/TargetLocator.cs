using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

//Find, fire and rotate the defense towards the enemy and additionaly manages the catapult animation to fire when it should, this may be in other script;
public class TargetLocator : MonoBehaviour 
{
    [SerializeField] Transform weapon;

    Transform target;

    [SerializeField] ParticleSystem ballPS;
    [SerializeField] ParticleSystem firingPS;

    [SerializeField] float range = 15f;
        
    void Update()
    {
        FindClosestTarget();
        AimWeapon();          
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTartget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                closestTartget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTartget;
    }    

    void AimWeapon()
    {       
        if (target == null)
        {
            Attack(false);
            Debug.Log("No targets");
            return;
        }

        float targetDistance = Vector3.Distance(transform.position, target.position);
        
        if (targetDistance < range)
        {
            weapon.LookAt(target);
            Attack(true);
            Debug.Log("I should shoot");
        }
        else
        {
            Attack(false);
            Debug.Log("Can't reach them!");
        }
      
    }
    
    void Attack(bool IsActive)
    {
        var emissionModule = firingPS.emission;
        emissionModule.enabled = IsActive;
       
    }
    void firing()
    {       
        ballPS.Play();
    }
}