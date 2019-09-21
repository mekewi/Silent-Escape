using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PathController pathController;
    public MoveToTarget moveToTarget;
    public RotateToTarget rotateToTarget;
    void Start()
    {
        moveToTarget.TargetReached += EnemyTargetReached;
        rotateToTarget.RotateFinished += RotateFinished;
        transform.position = pathController.GetCurrentPoint().position;
        pathController.NextPoint();
        rotateToTarget.ChangeTarget(pathController.GetCurrentPoint());

    }
    private void OnDisable()
    {
        moveToTarget.TargetReached -= EnemyTargetReached;
        rotateToTarget.RotateFinished -= RotateFinished;
    }
    void RotateFinished()
    {
        moveToTarget.ChangeTarget(pathController.GetCurrentPoint());
    }
    void EnemyTargetReached()
    {
        pathController.NextPoint();
        rotateToTarget.ChangeTarget(pathController.GetCurrentPoint());
    }
    void Update()
    {
    }

}
