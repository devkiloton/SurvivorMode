using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private ControlaJogador scriptPlayer;
    void Start()
    {
        scriptPlayer = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();
        GetComponent<Slider>().maxValue = scriptPlayer.LifeBar;
    }

    public void LifeBarClock()
    {
        GetComponent<Slider>().value = scriptPlayer.LifeBar;
    }
}
