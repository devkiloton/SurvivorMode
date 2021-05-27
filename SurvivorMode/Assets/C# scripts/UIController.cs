using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private ControlaJogador scriptPlayer;
    public Slider mySlider;
    void Start()
    {
        scriptPlayer = GameObject.FindWithTag(Tags.Player).GetComponent<ControlaJogador>();
        //mySlider = GetComponent<Slider>();
        mySlider.maxValue = scriptPlayer.myStatus.Life;
    }

    public void LifeBarClock()
    {
       mySlider.value = scriptPlayer.myStatus.Life;
    }
}
