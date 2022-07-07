using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOfBackMusic : MonoBehaviour
{
    [SerializeField] private Sprite spriteNoneMusic;
    [SerializeField] private Sprite spritePlayMusic;

    private Image image;
    private AudioSource audio;

    void Start()
    {
        image = GetComponent<Image>();
        audio = GetComponent<AudioSource>();

        audio.Play();
        audio.loop = true;
    }


    public void StartAndPausefonMusic()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();

        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            image.sprite = spriteNoneMusic;
        }
        else
        {
            audioSource.Play();
            image.sprite = spritePlayMusic;
        }
    }
}
