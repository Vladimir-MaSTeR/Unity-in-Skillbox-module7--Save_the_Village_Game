using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clickSound;

    public void Awake()
    {
        GetComponent<Button>().onClick.AddListener(PlayClickSound);
    }


    private void PlayClickSound()
    {
        _audioSource.PlayOneShot(_clickSound);
    }
}
