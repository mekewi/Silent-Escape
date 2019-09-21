using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform objectToFollow;
    public int speed = 7;
    void Update()
    {
        Vector3 displacementFromTarget =  objectToFollow.position - transform.position;
        Vector3 direction = displacementFromTarget.normalized;
        Vector3 movementAmount = direction * Time.deltaTime * speed;
        float distance = displacementFromTarget.magnitude;
        if (distance > 1.5)
        {
            transform.Translate(movementAmount,Space.World);
        }
    }
}
