using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public event System.Action OnPlayerDeath;
    public float speed = 7;
    float screenHalfWidthInWorldUnits = 0;
    void Start()
    {
        float playerHalfWidth = transform.localScale.x / 2;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize+playerHalfWidth;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Vector3 velocity = input.normalized * speed;
        transform.Translate(velocity * Time.deltaTime);
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector3(screenHalfWidthInWorldUnits, transform.position.y, transform.position.z);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector3(-screenHalfWidthInWorldUnits, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("BoxFall"))
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath.Invoke();
            }
            Destroy(gameObject);
        }
    }

}
