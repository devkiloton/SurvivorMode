using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject QuitGameButton;
    private void Start()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        QuitGameButton.SetActive(true);
#endif
    }
    public void GameStart()
    {
        SceneManager.LoadScene("game");
    }
    public void QuitGame()
    {
        StartCoroutine(QuitGameWithDelay());
    }

    IEnumerator QuitGameWithDelay()
    {
        yield return new WaitForSeconds(0.358f);
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
