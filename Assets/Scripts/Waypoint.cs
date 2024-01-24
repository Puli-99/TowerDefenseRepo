using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Scipt to locate tiles and determinates wether or not a tower is placeable if there's other tower;
public class Waypoint : MonoBehaviour   
{
    [SerializeField] Tower tower;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }


    void OnMouseDown()
    {        
        if (isPlaceable)
        {     
            bool isPlaced = tower.CreateTower(tower, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
