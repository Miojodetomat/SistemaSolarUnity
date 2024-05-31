using System;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeAudioSource : MonoBehaviour
{
    public string sound;

    void OnMouseDown()
    {
        if(sound == "")
        {
            Debug.LogWarning("Sound not specified");
            return;
        }

        var audioManager = FindObjectOfType<AudioManager>();
        audioManager.Focus(sound);
    }
}
