using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform target;
    
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        // for angling towards player
        try
        {
            Vector2 dir = target.position -  transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 45;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            if (Vector2.Distance(transform.position, target.position) > 5)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, 5 * Time.deltaTime);
            }
        
            if (Vector2.Distance(transform.position, target.position) > 10)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, 15 * Time.deltaTime);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Player object Destroyed, cant follow player.");
        }
    }
}
