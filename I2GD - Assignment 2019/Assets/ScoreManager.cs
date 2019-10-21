using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    static public int score;
    [SerializeField] TextMeshProUGUI scoreText;

    static private ScoreManager instance = null;
    // Lets other scripts find the instane of the score manager
    public static ScoreManager Instance
    {
        get
        {
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null) {        //Get score if not plugged in
            scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        }
        score = 0;
        scoreText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //only needs to happen first frame of the main game or will repeat itself every frame and build up errors
        if (scoreText == null)
        {        //Get score if not plugged in
            scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        }
        scoreText.text = "Score: " + score.ToString();

    }

    public static void IncreaseScore()      //take in an int score from enemy?
    {
        score += 1;
    }
}
