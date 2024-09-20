using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter");
            Resume();
        }
    }
}
