    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.0f;
       public void LoadLevel()
    {
        StartCoroutine(WaitAndLoad("Level 0", loadDelay));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadMapSelect()
    {
        SceneManager.LoadScene("Select Level");
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
