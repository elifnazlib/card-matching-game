using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip buttonClickSound;

    public void ButtonClicked()
    {
        // src.clip = buttonClickSound;
        // src.Play();

        src.PlayOneShot(buttonClickSound, 0.5f);
    }
}
