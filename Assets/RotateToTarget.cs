using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    public float rotateSpeed = 7;
    public Transform target;
    bool allowToRotate = false;
    public Action RotateFinished;
    void Start()
    {
        allowToRotate = target != null;
    }
    void CalculateRotation()
    {
        var different = target.position - transform.position;
        var dirction = different.normalized;
        var degree = 90 - Mathf.Atan2(dirction.z, dirction.x) * Mathf.Rad2Deg;
        if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, degree)) > 0.05)
        {
            transform.eulerAngles = Vector3.up * Mathf.LerpAngle(transform.eulerAngles.y, degree, Time.deltaTime * rotateSpeed);
        }
        else
        {
            allowToRotate = false;
            RotateFinished.Invoke();
        }
    }
    void Update()
    {
        if (allowToRotate)
        {
            CalculateRotation();
        }
    }
    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
        allowToRotate = true;
    }
}
