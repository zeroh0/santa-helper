﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellDestory : MonoBehaviour
{
    float makeTime;
    // Start is called before the first frame update
    void Start()
    {
        makeTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - makeTime > 7.0f)
        {
            Destroy(gameObject);
        }
    }
}
