using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector2 screenHalfWidthAndHeight;
    public float speed;
    public float secondsBetweenSpawns;
    public Vector2 secondsBetweenSpawnsMinMax;
    public float rotationMax;
    public Vector2 scaleMaxMin;
    float nextTimeToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfWidthAndHeight = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTimeToSpawn)
        {
            secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Defecult.GetDifficultyPercent());
            nextTimeToSpawn = Time.time + secondsBetweenSpawns;
            float scaleRandom = Random.Range(scaleMaxMin.x, scaleMaxMin.y);
            Vector2 spawnedPosition = new Vector2(Random.Range(screenHalfWidthAndHeight.x, -screenHalfWidthAndHeight.x), screenHalfWidthAndHeight.y + scaleRandom);
            GameObject newObject = (GameObject) Instantiate(objectToSpawn, spawnedPosition, Quaternion.Euler(0,0,Random.Range(-rotationMax,rotationMax)));
            newObject.transform.parent = transform;
            newObject.transform.localScale = Vector3.one * scaleRandom;
        }
    }
}
