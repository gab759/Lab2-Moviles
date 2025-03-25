using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    private GameObject currentTrail;

    public void StartTrail(Vector3 position)
    {
        currentTrail = new GameObject("Trail");
        currentTrail.transform.position = position;
        TrailRenderer trail = currentTrail.AddComponent<TrailRenderer>();
        trail.material = settings.trailMaterial;
        trail.startColor = settings.currentColor;
        trail.endColor = settings.currentColor;
        trail.time = 0.5f;
    }

    public void UpdateTrail(Vector3 position)
    {
        if (currentTrail != null)
        {
            currentTrail.transform.position = position;
        }
    }

    public void EndTrail()
    {
        if (currentTrail != null)
        {
            Destroy(currentTrail, currentTrail.GetComponent<TrailRenderer>().time);
            currentTrail = null;
        }
    }
}