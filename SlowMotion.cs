using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    private float slowMotionSpeed = 0.2f;
    private Movement movement;
    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        movement = player.GetComponent<Movement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && movement.bounce >= 1) 
        {
            Time.timeScale = slowMotionSpeed;


        }
        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1.0f;
        }
    }
}
