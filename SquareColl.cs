using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;


public class SquareColl : MonoBehaviour
{
    public float power;
    public string type;
    // random or lava
    public ParticleSystem scoreParticles;
    public ParticleSystem playerParticles;
    public Camera camera;

    private AudioSource playerEx;
    private GameObject scoreEx;

    private Movement movement;
    private RandomSpawnerScript spawner;
    private PointScript pointScript;
    private GameObject player;

    private Camera foundCam;
    private ParticleSystem foundParticleSystem;

    private PostProcessVolume shader;
    private ChromaticAberration chromAbe;
    private LensDistortion lens;


    private void Start(){
        
        player = GameObject.FindWithTag("Player");
        movement = player.GetComponent<Movement>();

        GameObject lava = GameObject.Find("Lava");
        spawner = lava.GetComponent<RandomSpawnerScript>();

        GameObject canvas = GameObject.Find("Canvas");
        pointScript = canvas.GetComponent<PointScript>();

        scoreEx = GameObject.Find("ScoreExplosion");
        playerEx = GameObject.Find("PlayerExplosion").GetComponent<AudioSource>();

        
        // find shader
        shader = GameObject.Find("Shader").GetComponent<PostProcessVolume>();
        shader.profile.TryGetSettings(out chromAbe);
        shader.profile.TryGetSettings(out lens);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (type == "random")
            {
                // increase chromatic aberration on collision
                chromAbe.intensity.value = 1f;
                lens.intensity.value = 50f;
                
                
                scoreParticles.transform.parent = null; // splits from parent
                // do particles
                scoreParticles.Emit(15);
                // destroy after 5 seconds

                var direction = Random.Range(1, 4);
                switch (direction)
                {
                    // if lands on 1 go up
                    case 1:
                        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*power, ForceMode2D.Impulse);
                        break;
                    
                    // go down
                    case 2:
                        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down*power, ForceMode2D.Impulse);
                        break;
                    
                    // left
                    case 3:
                        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left*power, ForceMode2D.Impulse);
                        break;
                    
                    case 4:
                        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right*power, ForceMode2D.Impulse);
                        break;
                }
                Destroy(gameObject);
            }

            movement.bounce = 2;
        }
        
        if (type == "lava" && other.CompareTag("Player"))
        {
            playerEx.Play(0);
            
            playerParticles.transform.parent = null;
            playerParticles.Emit(15);
            camera.transform.parent = null; // splits camera from parent
            Destroy(other.gameObject);
        }

        if (type == "bullet" && other.CompareTag("Player"))
        {
            chromAbe.intensity.value = 1f;
            lens.intensity.value = 0f;
            
            foundCam = player.GetComponentInChildren<Camera>();
            foundParticleSystem = player.GetComponentInChildren<ParticleSystem>();
            
            playerEx.Play(0);
            foundParticleSystem.Emit(15);
            
            foundParticleSystem.transform.parent = null;
            foundCam.transform.parent = null;
            
            player.transform.DetachChildren();

            Destroy(other.gameObject);
        }

        if (type == "random" && other.CompareTag("Player"))
        {
            scoreEx.GetComponent<AudioSource>().Play(0);
            pointScript.points += 100;    // added one point
        }
        
        if (type == "lava" && other.CompareTag("Spawned"))
        {
            
            Destroy(other.gameObject);
        }
        
        // deletes spawned collided objects so that they are not clustered
        if (other.CompareTag("Spawned"))
        {
            if (gameObject.CompareTag("Spawned"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
