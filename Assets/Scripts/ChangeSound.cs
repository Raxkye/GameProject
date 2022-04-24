using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSound : MonoBehaviour
{
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool isOn = true;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public Image image;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        if(isOn)
        {
            image.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
            audioSource2.mute = true;
        }
        else
        {
            image.sprite = soundOnImage;
            isOn = true;
            audioSource.mute = false;
            audioSource2.mute = false;
        }
    }
}
