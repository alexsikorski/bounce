using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    //Public Vars
    public Camera camera;
    public float speed;
    public Rigidbody2D rigidbody;
     
    //Private Vars
    private Vector3 mousePosition;
    private Vector3 direction;
    private float distanceFromObject;
     
    void FixedUpdate() {
         
        if (Input.GetButton("Fire2")){
 
            //Grab the current mouse position on the screen
            mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Input.mousePosition.z - camera.transform.position.z));
             
            //Rotates toward the mouse
            rigidbody.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x))*Mathf.Rad2Deg - 90);
        }
             
    }
}
