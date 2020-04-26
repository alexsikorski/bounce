using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Camera mainCam;

    public GameObject enemy;

    public AudioSource spawnEnemy;
    
    // Start is called before the first frame update
    private PointScript pointScript;
    private int score;
    private Vector2 pos;


    void Start()
    {
        // reference points
        GameObject canvas = GameObject.Find("Canvas");
        pointScript = canvas.GetComponent<PointScript>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = mainCam.ViewportToWorldPoint(new Vector2(generateRandomFloat(), generateRandomFloat()));
        
        score = pointScript.points;
       
        // need to get score value constantly

        // if score value is if(i % 1000 == 0)
        if (score != 0 && score % 1000 == 0)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 1)
            {
                spawnEnemy.Play(0);
                // spawn enemy
                // need to spawn outside player visibility region.
                Instantiate(enemy,pos, Quaternion.identity);
            }
        }
    }

    float generateRandomFloat()
    {
        return Random.Range(1.1f, 1.5f);
    }
}
