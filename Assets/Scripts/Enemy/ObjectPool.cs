using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Makes enemies appear;
public class ObjectPool : MonoBehaviour   
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0f, 50f)] int poolSize = 5; 
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();    
    }   

    void Start()
    {
        StartCoroutine(EnemiesI());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return; 
            }            
        }       
    }

  /*  void EnablePoolEnemies() // It does the same thing that EnableObjectInPool using foreach instead of for, whoever it gets the same result.
                               // I've made this one, the other one is from the course :);
    {
        foreach (GameObject obj in pool)
        {
            if (obj.activeInHierarchy == false)
            {
                obj.SetActive(true);
                return;
            }
        }
    }
  */
    IEnumerator EnemiesI()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }       
    }
}