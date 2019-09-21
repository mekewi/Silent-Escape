using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public Transform pathToMove;
    public float speed = 7;
    public float waitSeconds = 0;
    public Vector3[] pointsToMove;
    // Start is called before the first frame update
    void Start()
    {
        pointsToMove = new Vector3[pathToMove.childCount];
        for (int i = 0; i < pathToMove.childCount; i++)
        {
            pointsToMove[i] = pathToMove.GetChild(i).position;
        }
        StartCoroutine(move());
    }
    IEnumerator move() 
    {
        transform.position = pointsToMove[0];
        int targetPointIndex = 1;
        Vector3 targetPoint = pointsToMove[targetPointIndex];
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
            if (transform.position == targetPoint)
            {
                targetPointIndex = (targetPointIndex + 1) % pointsToMove.Length;
                targetPoint = pointsToMove[targetPointIndex];
                yield return new WaitForSeconds(waitSeconds);
            }
            yield return null;
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
