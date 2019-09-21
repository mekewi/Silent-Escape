using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PathController : MonoBehaviour
{
    Transform[] Points;
    int currentPoint;
    private void Start()
    {
    }
    public void Awake()
    {
        currentPoint = 0;
        Points = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Points[i] = transform.GetChild(i);
        }
    }
    public Transform NextPoint()
    {
        currentPoint = (currentPoint + 1) % Points.Length;
        return GetCurrentPoint();
    }
    public Transform GetCurrentPoint()
    {
        return Points[currentPoint];
    }
}
