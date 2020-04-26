using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFloor : MonoBehaviour
{
    public GameObject floor;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime + 2f)
        {
            Vector3 newPos = floor.transform.position;
            newPos.y -= 1 * Time.deltaTime;
            floor.transform.position = newPos;
        }
    }
}
