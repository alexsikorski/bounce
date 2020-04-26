using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    public float power;
    public Rigidbody2D rb;
    public int bounce; // 1 means 1 bounce

    public float maxSpeed = 10f;

    public Vector2 minPower; // minimum power
    public Vector2 maxPower; // max power
    public LineRenderer line;
    private Camera camera;
    private Vector2 ballForce;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 temp;

    public AudioSource pressDown;
    public AudioSource release; 
    
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    
    void Start()
    {
        bounce = 2;
        camera = Camera.main;
    }
    

    void Update()
    {
        // check velocity
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
        
        if (Input.GetMouseButtonDown(0) && bounce >= 1)
        {
           pressDown.Play(0);
           pressDown.pitch = 0.3f;
           startPoint = camera.ScreenToWorldPoint(Input.mousePosition);
           startPoint.z = 15;
            
       }
       if (Input.GetMouseButton(0) && bounce >= 1)
       {
           Vector3 currentPoint = camera.ScreenToWorldPoint(Input.mousePosition);
           currentPoint.z = 15;
           DrawLine(startPoint, currentPoint);
       }

       if (Input.GetMouseButtonUp(0) && bounce >= 1)
       {
           pressDown.pitch = 0.6f;
           release.Play(0);
           
           bounce -= 1;
           endLine();

           endPoint = camera.ScreenToWorldPoint(Input.mousePosition);
           endPoint.z = 15;
            
           ballForce = new Vector2(
               Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), 
               Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y  ));
           rb.AddForce(ballForce * power, ForceMode2D.Impulse);
       }
    }

    public void DrawLine(Vector3 startPoint, Vector3 endPoint)
    {
        line.positionCount = 2;
        Vector3[] AllPoint = new Vector3[2];
        AllPoint[0] = startPoint;
        AllPoint[1] = endPoint;
        line.SetPositions(AllPoint);
    }

    public void endLine()
    {
        line.positionCount = 0;
    }
}
