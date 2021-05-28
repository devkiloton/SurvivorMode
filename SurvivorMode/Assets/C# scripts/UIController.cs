using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private ControlaJogador scriptPlayer;
    public Slider mySlider;
    public GameObject GameOverText;
    public Text TimeAlive;
    public Text TimeAliveMax;
    private float savedTimeAliveMax;

    void Start()
    {
        scriptPlayer = GameObject.FindWithTag(Tags.Player).GetComponent<ControlaJogador>();
        mySlider.maxValue = scriptPlayer.myStatus.Life;
        Time.timeScale = 1;
        savedTimeAliveMax = PlayerPrefs.GetFloat("BestTime");
    }

    public void LifeBarClock()
    {
       mySlider.value = scriptPlayer.myStatus.Life;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverText.SetActive(true);
        int time = (int)(Time.timeSinceLevelLoad);
        TimeAlive.text = "You survived for: " + time + " seconds";
        adjustingMaxTimeAlive(time);
    }
    void adjustingMaxTimeAlive(int time)
    {
        if(Time.timeSinceLevelLoad > savedTimeAliveMax)
        {
            savedTimeAliveMax = Time.timeSinceLevelLoad;
            TimeAliveMax.text = string.Format("Your best time is: {0} seconds", (int)savedTimeAliveMax);
            PlayerPrefs.SetFloat("BestTime", savedTimeAliveMax);
        }
        if(TimeAliveMax.text == "")
        {
            TimeAliveMax.text = string.Format("Your best time is: {0} seconds", (int)savedTimeAliveMax);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("game");
    }
}
