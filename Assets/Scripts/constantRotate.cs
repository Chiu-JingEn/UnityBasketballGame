﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constantRotate : MonoBehaviour
{
    private float rotateSpeed=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed);
    }
}
