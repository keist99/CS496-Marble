﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public float ShakeAmount;

    float ShakeTime;
    Vector3 initialPosition;

    public void VibrateForTime(float time)
    {
        ShakeTime = time;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(960.0f, 540.0f, -935.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0.0f;
            transform.position = initialPosition;
        }
    }
}
