using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds instance;

    public AudioClip _botonSource;

    public AudioSource _audio;

    void Awake() {
        instance = this;
    }

    void Start() {
        _audio.clip = _botonSource;
    }

    public void b_playSound(){
        _audio.Play();
    }
    
    
}
