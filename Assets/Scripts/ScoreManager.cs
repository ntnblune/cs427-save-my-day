using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;
    int yourSecretID = 221003;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            score = 0;
            tip = 0;
            for (int i = 0; i < scoreLevels.Length; i++)
            {
                scoreLevels[i] = 0;
            }

            for (int i = 0; i < maxScore.Length; i++)
            {
                maxScore[i] = 3;
            }

            // automated load from local if there is any
            yourSecretID = PlayerPrefs.GetInt("yourSecretID");
            if (yourSecretID == 221003)
            {
                loadFromLocal();
            }
            PlayerPrefs.SetInt("yourSecretID", 221003);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void resetAll()
    {
        score = 0;
        tip = 0;
        for (int i = 0; i < scoreLevels.Length; i++)
        {
            scoreLevels[i] = 0;
        }

        for (int i = 0; i < maxScore.Length; i++)
        {
            maxScore[i] = 3;
        }
        saveToLocal();
    }
    public int currentLevelPlayed = 0;

    public void updateCurrentLevel(int level)
    {
        currentLevelPlayed = level;
    }

    int score;
    int tip;
    [SerializeField] public
    int numberOfLevels = 2;
    // storage score of all level but dont know how many level
    public int[] scoreLevels = new int[100];
    public int [] maxScore = new int[100];

    public bool isDoneLevel(int level)
    {
        return scoreLevels[level] == maxScore[level];
    }

    public int GetMaxScore()
    {
        int sum = 0;
        for (int i = 0; i < numberOfLevels; i++)
        {
            sum += maxScore[i];
        }
        return sum;
    }
    public int GetScore()
    {
        return score;
    }

    public int GetTip()
    {
        return tip;
    }

    public void AddScore(int level, int scoreToAdd)
    {
        if (scoreToAdd > scoreLevels[level])
        {
            score += scoreToAdd - scoreLevels[level];
            scoreLevels[level] = scoreToAdd;
            saveToLocal();
        }
    }

    public void AddTip(int tipToAdd)
    {
        tip += tipToAdd;
        saveToLocal();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void saveToLocal()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("tip", tip);
        Debug.Log("Save score " + score);   
        PlayerPrefs.SetInt("currentLevelPlayed", currentLevelPlayed);
        for (int i = 0; i < scoreLevels.Length; i++)
        {
            PlayerPrefs.SetInt("scoreLevels" + i, scoreLevels[i]);
        }

        for (int i = 0; i < maxScore.Length; i++)
        {
            PlayerPrefs.SetInt("maxScore" + i, maxScore[i]);
        }

        PlayerPrefs.Save();
    }

    void loadFromLocal()
    {
        score = PlayerPrefs.GetInt("score");
        tip = PlayerPrefs.GetInt("tip");
        currentLevelPlayed = PlayerPrefs.GetInt("currentLevelPlayed");
        for (int i = 0; i < scoreLevels.Length; i++)
        {
            scoreLevels[i] = PlayerPrefs.GetInt("scoreLevels" + i);
        }

        for (int i = 0; i < maxScore.Length; i++)
        {
            maxScore[i] = PlayerPrefs.GetInt("maxScore" + i);
        }
    }
    void OnApplicationQuit()
    {
        saveToLocal();
    }
}
