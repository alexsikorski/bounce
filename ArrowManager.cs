using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowManager : MonoBehaviour
{
    public Image firstArrow;
    public Image secondArrow;
    
    private Movement movement;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        movement = player.GetComponent<Movement>();
    }

    void Update()
    {
        // need to get bounce value...
        int currentBounce = movement.bounce;
        
        if (currentBounce == 2)
        {
            firstArrow.enabled = true;
            secondArrow.enabled = true;

        }
        if (currentBounce == 1)
        {
            secondArrow.enabled = false;
        }
        if (currentBounce == 0)
        {

            firstArrow.enabled = false;
            secondArrow.enabled = false;
        }
    }
}
