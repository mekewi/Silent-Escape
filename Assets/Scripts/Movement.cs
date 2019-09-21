using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 10;
    void Update()
    {
        Vector3 inputData = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 dirction = inputData.normalized;
        Vector3 moveAmount = dirction * speed * Time.deltaTime;
        transform.Translate(moveAmount,Space.World);
    }
}
