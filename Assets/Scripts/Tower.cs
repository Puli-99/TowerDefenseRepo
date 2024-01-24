using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manage the towers instantiation and its cost;
public class Tower : MonoBehaviour
{
    [SerializeField] int cost;

    public bool CreateTower(Tower tower, Vector3 position)    
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
}
