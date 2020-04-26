using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour
{
    public int points;
    public int highScore;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        points = 0; // reset points
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        if (points > highScore)
        {
            PlayerPrefs.SetInt("HighScore", points);
        }
        
        
        scoreText.text = points.ToString();
    }
}
