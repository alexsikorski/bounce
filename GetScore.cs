using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    private PointScript pointScript;
    public Text scoreText;
    public Text highScore;
    private int highScoreInt;
    
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        pointScript = canvas.GetComponent<PointScript>();
    }
    
    void Update()
    {
        highScoreInt = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = pointScript.points.ToString();
        highScore.text = highScoreInt.ToString();
    }
}
