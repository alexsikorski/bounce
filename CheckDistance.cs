using UnityEngine;

public class CheckDistance : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawned;
    public Rigidbody2D rb_player;
    public int maxDistance;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawned = GameObject.FindGameObjectsWithTag("Spawned");
        foreach (var VARIABLE in spawned)
        {
            if (GetDistance(VARIABLE.GetComponent<Rigidbody2D>(), rb_player) > maxDistance)
            {
                Destroy(VARIABLE);
            }
        }
    }

    float GetDistance(Rigidbody2D rb1, Rigidbody2D rb2)
    {
        return Vector3.Distance(rb1.transform.position, rb2.transform.position);
    }
}
