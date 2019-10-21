using System.Runtime.Serialization.Formatters.Binary;   //for binary formatting
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {

    enum GameState { START, IN_GAME, GAME_OVER, RULES, SCORE, LEADERBOARD };
    private GameState gameState;
    [SerializeField] private GameState startState = GameState.START; // Exists to enable individual level testing


    [SerializeField] private GameObject gameOverPrefab;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject rulesScreen;

    //ask user for name and use it as file name
    private static string playerName;                             //for player input  
    private static string path = "./savedgame.gd";       //hard coded path in current directory file


        //SaveData.current.highScores.Sort(); //arranges list lowest to highest
        //highScoreText.text = "High Score: " + SaveData.current.highScores[SaveData.current.highScores.Count - 1].ToString("0.00");  //gets the highest item (next to end of array)

    static private GameManager instance = null;

    // Lets other scripts find the instane of the game manager
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    // Ensure there is only one instance of this object in the game
    void Awake()
    {
        if (instance != null)      
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        gameState = startState;
    }

    //States ///////////////////////////////////////////////
    void OnChangeState(GameState newState)          
    {
        if (gameState != newState)
        {
            switch (newState)
            {
                case GameState.START:

                    rulesScreen.SetActive(false); //disables rule canvas
                    startScreen.SetActive(true);       //enables main menu canvas
                    
                    Cursor.lockState = CursorLockMode.None; // unlock the cursor for the menu
                    Cursor.visible = true;

                    Button startButton = GameObject.Find("StartButton").GetComponent<Button>(); //Play button go to main scene
                    startButton.onClick.AddListener(() => PlayGame());

                    Button quitButton = GameObject.Find("QuitButton").GetComponent<Button>();   //Quit button quit game
                    quitButton.onClick.AddListener(() => QuitGame());

                    Button rulesButton = GameObject.Find("RulesButton").GetComponent<Button>(); //Rules button go to Rules Scene
                    rulesButton.onClick.AddListener(() => Rules());

                    break;
                case GameState.IN_GAME:
                    Time.timeScale = 1; // Set timescale to be a normal rate 
                    SceneManager.LoadScene("Game"); // Load the 'Game' scene

                    Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the game screen
                    Cursor.visible = false;
                    EnableInput(true);      //happening before scene loads?

                    break;
                case GameState.RULES:
                    rulesScreen.SetActive(true);       //activates rule canvas

                    Button menuButton = GameObject.Find("MenuButton").GetComponent<Button>();       
                    menuButton.onClick.AddListener(() => MainMenu());       //Goes back to start function

                    break;
                case GameState.GAME_OVER:
                    //Set up input
                    Cursor.lockState = CursorLockMode.None; // unlock the cursor for the menu
                    Cursor.visible = true;
                    EnableInput(false); // disable character controls script        

                    RenderSettings.fog = false;     //turns off fog
                    Time.timeScale = 0; // Pause the game by setting timescale to 0 to stop AI behaviour
                    Transform instance = Instantiate(gameOverPrefab).transform; // Instantiate the GameOver menu prefab
                    //have the input field on gameroverprefab

                    Button restartButton = instance.Find("RestartButton").GetComponent<Button>();
                    restartButton.onClick.AddListener(() => PlayGame());

                    Button quitButton1 = instance.Find("QuitButton").GetComponent<Button>();        //USING QUITBUTTON 1 as quitbutton already defined
                    quitButton1.onClick.AddListener(() => QuitGame());

                    Button leaderButton = instance.Find("LeaderBoardButton").GetComponent<Button>();
                    leaderButton.onClick.AddListener(() => Leaderboard()); 

                    break;
                case GameState.LEADERBOARD:
                    Cursor.lockState = CursorLockMode.None; // unlock the cursor for the menu
                    Cursor.visible = true;

                    SaveData.current.highScores.Add(ScoreManager.score); //Adds current score to list of scores saved
                    //needs to store name earlier
                    Save(); //saves score

                    Button startButton1 = GameObject.Find("StartButton").GetComponent<Button>();        //USING QUITBUTTON 1 as quitbutton already defined
                    startButton1.onClick.AddListener(() => MainMenu());

                    SceneManager.LoadScene("Leaderboard");
                    break;
            }

            gameState = newState;
        }
    }

    private void EnableInput(bool input)
    {
        // Find the player object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<FirstPersonController>().enabled = input;
        player.GetComponentInChildren<Gun>().enabled = input;

    }

    public void MainMenu()
    {
        OnChangeState(GameState.START);             
    }

    public void PlayGame()
    {
        OnChangeState(GameState.IN_GAME);
    }

    public void GameOver()
    {
        OnChangeState(GameState.GAME_OVER);
    }

    public void Rules()     
    {
        OnChangeState(GameState.RULES);
    }

    public void Leaderboard()
    {
        OnChangeState(GameState.LEADERBOARD);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    //Other Functions   ////////////////////
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + path);
        bf.Serialize(file, SaveData.current);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGame.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.gd", FileMode.Open);
            SaveData.current = (SaveData)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            SaveData.current = new SaveData();
        }
    }

    //SaveData.current.highScore = Mathf.Max(SaveData.current.highScore, ScoreManager.score); //change to scoremanager.score
    //Save(); //saves score

}
