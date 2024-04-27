using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Having a sound Manager will help ensure audio is played even when objects are destroyed... A centralized Sound player
    public AudioClip soundClip;
    private AudioSource audioS;
 
    void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void playSound(AudioClip sound)
    {
        audioS.PlayOneShot(sound);
    }
}
