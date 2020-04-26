using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float interpVelocity;
    public float velocityModifier;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
        
    // for camera zoom changes
    private const float maxZoom = 7;
    private const float backToNormal = 5;

    // Use this for initialization
    void Start ()
    {
        targetPos = transform.position;
        
    }
	
    // Update is called once per frame
    void FixedUpdate ()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;
          

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * velocityModifier;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

            transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);

        }

        try
        {
            if (interpVelocity > 20 && Camera.current.orthographicSize <= maxZoom )
            {
                Camera.current.orthographicSize += 0.02f;

            }
            if (interpVelocity < 20 && Camera.current.orthographicSize >= backToNormal)
            {
                Camera.current.orthographicSize -= 0.02f;
            }
        }
        catch (NullReferenceException e)
        {
            // do nothing
        }
        
    }
}
