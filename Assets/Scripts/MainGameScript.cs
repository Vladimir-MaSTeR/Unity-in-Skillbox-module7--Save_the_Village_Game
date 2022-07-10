using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameScript : MonoBehaviour
{

    [SerializeField] private float _harvestTimeCucle;
    [SerializeField] private Text _harvestText;
    [SerializeField] private Text _harvestTextInResursePanel;
    [SerializeField] private float _defoltHarvestInResursePanel;
    [SerializeField] private GameObject _plusInfoPanel;
    [SerializeField] private Text _plusInfoPanelText;
    private float _harvestTime = 0f;
    private float _harvestCountInResursePanel = 0f;
    private float _plusInfoCountPanelText = 0f;
    private float _plusInfoCountPanelTimerOf = 2f;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clickSound;

    private bool _puaseGame;

    void Start()
    {
        _puaseGame = false;
        _harvestTime = _harvestTimeCucle;
        _harvestCountInResursePanel = _defoltHarvestInResursePanel;
        _harvestTextInResursePanel.text = _harvestCountInResursePanel.ToString();
    }

    private void FixedUpdate()
    {
        if (_puaseGame == false)
        {
            if (_harvestTime > 0)
            {
                if (_plusInfoCountPanelTimerOf <= 0)
                {
                    _plusInfoPanel.SetActive(false);
                    _plusInfoCountPanelTimerOf = 3f;

                } else
                {
                    _plusInfoCountPanelTimerOf -= Time.deltaTime;

                }

                _harvestTime -= Time.deltaTime;
                UpdateTimeText(_harvestText, _harvestTextInResursePanel, _harvestTime);
            }
            else
            {
                _harvestTime = _harvestTimeCucle;
            }
        }
        else
        {

        }
    }

    private void UpdateTimeText(Text text, Text textInResousesPanel, float time)
    {
        if (time < 0)
        {
            time = 0;
            UpdateharvestCountInResursesPanel();
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        text.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        textInResousesPanel.text = _harvestCountInResursePanel.ToString();
    }
    
    private void UpdateharvestCountInResursesPanel()
    {
        _plusInfoCountPanelText += 1;
        _plusInfoPanelText.text = string.Format("+{0}", _plusInfoCountPanelText.ToString());
        _plusInfoPanel.SetActive(true);
        _audioSource.PlayOneShot(_clickSound);

        _harvestCountInResursePanel += 1;       
    }

}
