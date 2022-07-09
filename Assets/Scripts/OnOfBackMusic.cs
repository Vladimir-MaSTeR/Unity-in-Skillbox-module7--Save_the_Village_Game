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
        //AudioSource audioSource = gameObject.GetComponent<AudioSource>();

        if (audio.isPlaying)
        {
            audio.Pause();
            image.sprite = spriteNoneMusic;
        }
        else
        {
            audio.Play();
            image.sprite = spritePlayMusic;
        }
    }
}
