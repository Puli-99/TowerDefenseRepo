using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Atached in Text on tiles GO, displays the coordinates of the tiles, [ExecuteAlways] makes it execute it even out of play mode;
//I have to put it on the Editor folder when i build up the project;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class TileScript : MonoBehaviour   
{
    [SerializeField] Color defaultC = Color.red;
    [SerializeField] Color placedC = Color.black;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = true;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ToggleLabels();
    }

    void SetLabelColor()
    {
        if (waypoint.IsPlaceable)
        {
           label.color = defaultC;
        }
        else
        {
            label.color = placedC;
        }
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            label.enabled = !label.IsActive();
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
