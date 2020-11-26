﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulse : MonoBehaviour
{
    private Image img;

    private float pulseTime = 10;

    private float changeInB = 160;

    private float scalar;
    
    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        scalar = changeInB/pulseTime;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((255 - scalar*(Mathf.Abs(Time.time%pulseTime - pulseTime/2))));
        img.color = new Color32(255, 255, (byte)(255 - scalar*(Mathf.Abs(Time.time%pulseTime - pulseTime/2))), 255);
    }
}