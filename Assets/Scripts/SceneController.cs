    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // public static SceneController instance;
    private void Awake()
    {
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
       public void LoadLevel()
    {
        var audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManger>();
        audioManager.StopMusic();
        audioManager.PlaySFX(audioManager.introGame, 0.5f);
        StartCoroutine(WaitAndLoad("Level 1", loadDelay));
    }

    public void LoadGameEnd(){
        StartCoroutine(WaitAndLoad("GameEnd", loadDelay));
    }

    public void LoadMainMenu()
    {StartCoroutine(WaitAndLoad("Menu", loadDelay));
    }

    public void LoadMapSelect()
    {
        StartCoroutine(WaitAndLoad("Select level", loadDelay));
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", loadDelay));
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
