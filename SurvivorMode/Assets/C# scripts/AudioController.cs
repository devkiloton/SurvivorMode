using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource myAudio;
    public static AudioSource Instance;
    void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        Instance = myAudio;
    }
}
