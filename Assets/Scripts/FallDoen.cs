using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDoen : MonoBehaviour
{
    public float speed;
    public Vector2 speedMinMax;
    float visiblHightThreshold;
    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Defecult.GetDifficultyPercent());
        visiblHightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < visiblHightThreshold)
        {
            Destroy(gameObject);
        }
    }
}
