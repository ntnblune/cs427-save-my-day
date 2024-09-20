using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoUpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    private Text scoreText, tipText;
    private ScoreManager scoreManager;
    void Start()
    {
        scoreText = GameObject.Find("Canvas/Star/Text").GetComponent<Text>();
        tipText = GameObject.Find("Canvas/ScoreBoard/Text").GetComponent<Text>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        scoreText.text = scoreManager.GetScore().ToString() + " / " + scoreManager.GetMaxScore().ToString();
        tipText.text = scoreManager.GetTip().ToString();
    }
}
