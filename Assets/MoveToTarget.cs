using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField]
    Transform targetObject;
    [SerializeField]
    float speed;
    bool allowedToMove;
    [SerializeField]
    float stopDestance;
    public Action TargetReached;
    void Start()
    {
        allowedToMove = targetObject != null;
    }
    private void Update()
    {
        UpdateMove();
    }
    void UpdateMove()
    {
        if (!allowedToMove)
        {
             return;
        }
        var difference = targetObject.position - transform.position;
        transform.position = MoveTowards(transform.position, targetObject.position, speed * Time.deltaTime);
        if (difference.magnitude <= stopDestance)
        {
            allowedToMove = false;
            TargetReached.Invoke();
        }
    }
    public Vector3 MoveTowards(Vector3 from,Vector3 to,float distancedelta)
    {
        Vector3 a = to - from;
        float magnitude = a.magnitude;
        if (magnitude <= distancedelta || Math.Abs(magnitude) < 0)
        {
            return to;
        }
        var dirction = a.normalized;
        var velocity = dirction * Time.deltaTime * speed;
        return from + velocity;
    }
    public void ChangeTarget(Transform nextTarget)
    {
        targetObject = nextTarget;
        allowedToMove = true;
    }
}
