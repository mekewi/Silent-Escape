﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 180 * Time.deltaTime);
    }
}
