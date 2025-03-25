using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;

    public GameObject GetShapeAtPosition(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapPoint(position);
        return (hit != null && hit.CompareTag("Shape")) ? hit.gameObject : null;
    }

    public void CreateShape(Vector3 position)
    {
        GameObject spawned = Instantiate(settings.shapePrefabs[settings.currentShapeIndex], position, Quaternion.identity);
        spawned.tag = "Shape";
        spawned.GetComponent<SpriteRenderer>().color = settings.currentColor;
    }

    public void MoveShape(GameObject shape, Vector3 newPosition)
    {
        shape.transform.position = newPosition;
    }

    public void DeleteShapeAtPosition(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapPoint(position);
        if (hit != null && hit.CompareTag("Shape"))
        {
            Destroy(hit.gameObject);
        }
    }

    public void DeleteAllShapes()
    {
        GameObject[] shapes = GameObject.FindGameObjectsWithTag("Shape");
        foreach (var shape in shapes)
        {
            Destroy(shape);
        }
    }
}