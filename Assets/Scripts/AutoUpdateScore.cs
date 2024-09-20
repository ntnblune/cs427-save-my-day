using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoUpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    private Text scoreText, tipText;
    private ScoreManager scoreManager;
    private Text[] levelManagerText = new Text[15];
    private Image[] levelManagerImage = new Image[15];
    int numberOfUnlockLevel = 5;
    void Start()
    {
        scoreText = GameObject.Find("Canvas/Star/Text").GetComponent<Text>();
        tipText = GameObject.Find("Canvas/ScoreBoard/Text").GetComponent<Text>();
        scoreManager = FindObjectOfType<ScoreManager>();
        numberOfUnlockLevel = scoreManager.numberOfLevels;
        // level for each level is level/Level (1)
        for (int i = 0; i < numberOfUnlockLevel; i++)
        {
            string path = "Canvas/Level/Level " + "(" + (i + 1).ToString() + ")";
            Debug.Log(path);
            levelManagerText[i] = GameObject.Find(path + "/Text").GetComponent<Text>(); // get text component in the object = name of level
            levelManagerImage[i] = GameObject.Find(path + "/star").GetComponent<Image>(); // get image component in the object = name of level
        }

        for (int i = 0; i < numberOfUnlockLevel; i++)
        {
         
            int numStart = scoreManager.scoreLevels[i + 1];
            levelManagerText[i].text = (i + 1).ToString(); // change text of level, name level = numStart
            levelManagerImage[i].sprite = Resources.Load<Sprite>(numStart.ToString() + "-3");
            // change sprite of star, name spire = numStart - 3
            //levelManager[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(numStart.ToString() + "-3");
        }

    }

    public void resetAll()
    {
        scoreManager.resetAll();
        for (int i = 0; i < numberOfUnlockLevel; i++)
        {
            levelManagerText[i].text = (i + 1).ToString();
            levelManagerImage[i].sprite = Resources.Load<Sprite>("0-3");
        }
    }

    // Update is called once per frame
    void Update()
    {   
        scoreText.text = scoreManager.GetScore().ToString() + " / " + scoreManager.GetMaxScore().ToString();
        tipText.text = scoreManager.GetTip().ToString();
    }
}
