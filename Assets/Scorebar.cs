using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorebar : MonoBehaviour
{
    public int currentPoint = 0;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        currentPoint = 0;
        text = GetComponent<Text>();
    }

    public void UpdateScore(int point)
    {
        currentPoint += point;
        // transform score to format 0000
        text.text = currentPoint.ToString("0000");
    }
}
