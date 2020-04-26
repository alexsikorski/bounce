using System;
using UnityEngine;

public class MoveLava : MonoBehaviour
{
    public GameObject lava_1;
    public GameObject lava_2;
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos1 = lava_1.transform.position;
        Vector3 newPos2 = lava_2.transform.position;
        try
        {
            var position = player.transform.position;
            newPos1.x = position.x;
            newPos2.x = position.x;
            lava_1.transform.position = newPos1;
            lava_2.transform.position = newPos2;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
