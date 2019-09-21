using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Vector3 startingPoint = transform.GetChild(0).position;
        Vector3 previousPoint = startingPoint;
        foreach (Transform point in transform)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(point.position, 0.3f);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(previousPoint, point.position);
            previousPoint = point.position;
        }
        Gizmos.DrawLine(startingPoint, previousPoint);
    }
}
