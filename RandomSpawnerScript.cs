using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawnerScript : MonoBehaviour
{
    public GameObject prefab1;
    public float maxRange;
    
    public int amountDesired;


    void Start()
    {
    }

    
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Spawned").Length < amountDesired)
        {
            if (pickOne() == 0) // spawn above player
            {
                Vector3 randomPos = new Vector3(Random.Range(-maxRange - 30, maxRange + 30), Random.Range(0 + 10, maxRange), 0  );
                Instantiate(prefab1,transform.position +  randomPos, Quaternion.identity); 
            }

            if (pickOne() == 1)
            {
                Vector3 randomPos = new Vector3(Random.Range(-maxRange - 30, maxRange + 30), Random.Range(-10, -maxRange), 0  );
                Instantiate(prefab1,transform.position +  randomPos, Quaternion.identity); 
            }
           
        }
    }

    private int pickOne()
    {
        return Random.Range(0, 2);
    }
}
