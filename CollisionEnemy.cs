using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem enemyParticles;
    public float power;
    private PointScript pointScript;
    private Movement movement;
    private EnemySpawner eSpawner;

    private GameObject enemyEx;
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        pointScript = canvas.GetComponent<PointScript>();
        
        GameObject player = GameObject.Find("Player");
        movement = player.GetComponent<Movement>();
        
        enemyEx = GameObject.Find("EnemyExplosion");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyEx.GetComponent<AudioSource>().Play(0);
            
            pointScript.points += 500;  
            enemyParticles.transform.parent = null; // splits from parent
            // do particles
            enemyParticles.Emit(15);
            // destroy after 5 seconds
            var direction = Random.Range(1, 4);
            switch (direction)
            {
                // if lands on 1 go up
                case 1:
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * power, ForceMode2D.Impulse);
                    break;

                // go down
                case 2:
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * power, ForceMode2D.Impulse);
                    break;

                // left
                case 3:
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * power, ForceMode2D.Impulse);
                    break;

                case 4:
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * power, ForceMode2D.Impulse);
                    break;
            }
            
            Destroy(gameObject);
        }
    }
}
