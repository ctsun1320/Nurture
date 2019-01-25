﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringController : MonoBehaviour
{
    public GameObject water_meter;

    private Transform tr;

    private Transform meter_tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform> ();

        meter_tr = water_meter.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //Update the Text on the screen depending on current position of the touch each frame
            print("Touch Position : " + touch.position);

            meter_tr.localScale += new Vector3(0, 0.003f, 0);
            tr.position += new Vector3(0, 0.001f, 0);
        } 
        else if (Input.GetMouseButton(0))
        {
            print("Pressed left click.");

            meter_tr.localScale += new Vector3(0, 0.003f, 0);
            tr.position += new Vector3(0, 0.001f, 0);
        } else {
            if (meter_tr.localScale.y > 0f)
            {
                meter_tr.localScale -= new Vector3(0, 0.0005f, 0);
                tr.position += new Vector3(0, 0.001f, 0);
            }
        }

        
    }
}