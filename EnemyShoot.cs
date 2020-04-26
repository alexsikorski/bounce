using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    public float nextFire;
    private AudioSource shootSound;
    void Start()
    {
        fireRate = 2f;
        nextFire = Time.time;
        shootSound = GameObject.Find("Shoot").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            if (GameObject.FindWithTag("Player")) // checks if game object is active
            {
                shootSound.Play(0);
                Instantiate(bullet, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
        }
    }
}
