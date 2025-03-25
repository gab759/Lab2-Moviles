using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;
public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private ShapeManager shapeManager;
    [SerializeField] private TrailManager trailManager;

    private Vector2 startPos;
    private GameObject draggedObject;
    private bool isDragging;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(touch.position);
            worldPos.z = 0;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    draggedObject = shapeManager.GetShapeAtPosition(worldPos);
                    if (draggedObject == null)
                    {
                        trailManager.StartTrail(worldPos);
                    }
                    break;

                case TouchPhase.Moved:
                    if (draggedObject != null)
                    {
                        shapeManager.MoveShape(draggedObject, worldPos);
                    }
                    else
                    {
                        trailManager.UpdateTrail(worldPos);
                    }
                    isDragging = true;
                    break;

                case TouchPhase.Ended:
                    float swipeDistance = (touch.position - startPos).magnitude;

                    if (draggedObject == null && swipeDistance > settings.swipeThreshold)
                    {
                        shapeManager.DeleteAllShapes();
                    }
                    else if (touch.tapCount == 2)
                    {
                        shapeManager.DeleteShapeAtPosition(worldPos);
                    }
                    else if (swipeDistance < 10f && draggedObject == null)
                    {
                        shapeManager.CreateShape(worldPos);
                    }

                    trailManager.EndTrail();
                    draggedObject = null;
                    isDragging = false;
                    break;
            }
        }
    }
}