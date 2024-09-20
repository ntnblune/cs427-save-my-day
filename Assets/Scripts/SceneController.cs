    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // public static SceneController instance;
    private ScoreManager scoreManager;
    private void Awake()
    {
        Debug.Log("SceneController Awake");
        scoreManager = FindObjectOfType<ScoreManager>();
        // if (instance == null)
        // {
        //     instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
    }
    [SerializeField] float loadDelay = 0.0f;
    //    public void LoadLevel()
    // {
    //     var audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManger>();
    //     audioManager.StopMusic();
    //     audioManager.PlaySFX(audioManager.introGame, 0.5f);
    //     StartCoroutine(WaitAndLoad("Level 1", loadDelay));
    // }

    public void LoadMainMenu()
    {StartCoroutine(WaitAndLoad("GameStart", loadDelay));
    }

    public void LoadMapSelect()
    {
        StartCoroutine(WaitAndLoad("Select level", loadDelay));
    }

    public void LoadLevel(string name)
    {

        int level = int.Parse(name);
        scoreManager.updateCurrentLevel(level);
        var audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManger>();
        audioManager.StopMusic();
        audioManager.PlaySFX(audioManager.introGame, 0.5f);
        StartCoroutine(WaitAndLoad("Level " + name, loadDelay));
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        //SceneManager.LoadScene(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
