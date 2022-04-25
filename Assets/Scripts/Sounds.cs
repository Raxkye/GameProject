using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds instance;

    public AudioSource _audio;

    void Awake() {
        instance = this;
    }


    public void b_playSound(){
        _audio.Play();
    }
    
    
}
