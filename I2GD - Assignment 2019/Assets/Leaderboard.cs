using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text nameText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Load();     //Loads save

        SaveData.current.highScores.Sort();     //arranges list lowest to highest

        scoreText = GameObject.Find("ScoresText").GetComponent<Text>();
        nameText = GameObject.Find("NamesText").GetComponent<Text>();

        List<string> nameSublist = SaveData.current.names.GetRange(SaveData.current.names.Count - 10, 10);      //gets last 10 items  (not right for names) SOMEHOW GROUP THIS TO SCORE
        List<int> scoreSublist = SaveData.current.highScores.GetRange(SaveData.current.highScores.Count - 10, 10);      //gets last 10 items   (highest)

        //scoreText.text = SaveData.current.names.ToString();
        //nameText.text = SaveData.current.highScores.ToString();
        scoreText.text = scoreSublist.ToString();
        nameText.text = nameSublist.ToString();

    }

    //highScoreText.text = "High Score: " + SaveData.current.highScores[SaveData.current.highScores.Count - 1].ToString("0.00");  //gets the highest item (next to end of array)
}
