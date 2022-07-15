using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Sprite _spriteStopGame;
    [SerializeField] private Sprite _spritePlayGame;
    [SerializeField] private GameObject _pausedPanel;

    private Image image;
    private bool _paused;


    private void Start()
    {
        image = GetComponent<Image>();
        _pausedPanel.SetActive(false);

    }

    public void PausedGame()
    {
        if (_paused)
        {
            Time.timeScale = 1;
            _audioSource.Play();
            image.sprite = _spriteStopGame;
            _pausedPanel.SetActive(false);

        } else
        {
            Time.timeScale = 0;
            _audioSource.Pause();
            image.sprite = _spritePlayGame;
            _pausedPanel.SetActive(true);


        }


        _paused = !_paused;
    }

}
