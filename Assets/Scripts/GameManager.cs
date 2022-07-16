using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ������ ��������
    [SerializeField] private Text _wheatTextResursePanel;    // ��������� ���� ��� ����������� ���-�� �������
    [SerializeField] private Text _peasuntsTextResursePanel; // ��������� ���� ��� ����������� ���-�� ��������
    [SerializeField] private Text _wariorsTextResursePanel;  // ��������� ���� ��� ����������� ���-�� ������

    // ������ ����� ����� ������
    [SerializeField] private float _timerHarvestCuclePanel;             // ����� ������� ����� ������ � ���. 
    [SerializeField] private Text  _timerTextHarvestCuclePanel;         // ��������� ���� � ������� ������������ ����� ����� ������
   
    [SerializeField] private GameObject _plusInfoPanelHarvestCuclePanel; // ������������ ����� � ������������ ��� ���������� �� ���������� ����� ����� ������
    [SerializeField] private Text _plusInfoPanelTextHarvestCuclePanel;   // ����� �� ������������ ������(����������� ���������� ������� ������ �������)
    [SerializeField] private float _plusInfoPanelTimerHarvestCuclePanel; // ���������� � ��� ������� ������� ������� ���������� ������ � ��� ����������(����� ������� ������ ��������� ������)

    [SerializeField] private AudioSource _audioSourseHarvestPanel;  // ����� ���� ��� ������ ����������� ���
    [SerializeField] private AudioClip _audioClipHarvestPanel;      // ����� ���� ��� ������ ����������� ���

    // ������ ����� ����������� ���
    [SerializeField] private float _timerFoodConsumptionPanel;              // ����� ������� ����������� ��� � ���. 
    [SerializeField] private Text _timerTextFoodConsumptionPanel;           // ��������� ���� � ������� ������������ ����� ����������� ���
   
    [SerializeField] private GameObject _plusInfoPanelFoodConsumptionPanel; // ������������ ����� � ������������ ��� ���������� �� ���������� ����� ����������� ���
    [SerializeField] private Text _plusInfoPanelTextFoodConsumptionPanel;   // ����� �� ������������ ������(����������� ���������� ������� ��� �������)
    [SerializeField] private float _plusInfoPanelTimerFoodConsumptionPanel; // ���������� � ��� ������� ������� ������� ���������� ������ � ��� ����������(����� ������� ������ ��������� ������)

    [SerializeField] private AudioSource _audioSourseFoodConsumptionPanel;  // ����� ���� ��� ������ ����������� ���
    [SerializeField] private AudioClip _audioClipFoodConsumptionPanel;      // ����� ���� ��� ������ ����������� ���

    //������ ����� ������ ������
    [SerializeField] private float _timerRaidPanel;              // ����� ������� ������������ ����� ������� ����. ����� � ��� 
    [SerializeField] private Text _timerTextRaidPanel;           // ��������� ���� � ������� ������������ ����� �� ���� ������
    [SerializeField] private float _countWariorsRaid;            // ������� ������� ���������� ���-�� ������ � �����
    [SerializeField] private float _countWariorsNullRaid;        // ������� ������� ���������� ���-�� ������� ���� ������ � ������ ����
    [SerializeField] private float _wariorsPlusInRaid;           // ���������� �������� ������� �� ������� ����������� ���-�� ������ � ����. �����.
    [SerializeField] private Text _countWariorsRaidText;         // ��������� ���� ��� ����������� �������� ���-�� ������ � �����

    [SerializeField] private GameObject _plusInfoPanelRaidPanel; // ������������ ����� � ������������ ��� ���������� �� ���������� ����� ����������� ���
    [SerializeField] private Text _plusInfoPanelTextRaidPanel;   // ����� �� ������������ ������(����������� ���������� ������� ��� �������)
    [SerializeField] private float _plusInfoPanelTimerRaidPanel; // ���������� � ��� ������� ������� ������� ���������� ������ � ��� ����������(����� ������� ������ ��������� ������)

    [SerializeField] private AudioSource _audioSourseRaidPanel;  // ����� ���� ��� ������ �������
    [SerializeField] private AudioClip _audioClipRaidPanel;      // ����� ���� ��� ������ �������

    //������ ��� ����
    [SerializeField] private Button _hirePeasantButton;              // ������ ��� ����� ��������
    [SerializeField] private float _defaultTimeHiringPeasants;       // ����� ��� ����� ��������
    [SerializeField] private AudioSource _audioSoursePeasantButton;  // ����� ���� ��� ������ �������� ��������
    [SerializeField] private AudioClip _audioClipPeasantButton;      // ����� ���� ��� ������ �������� ��������

    [SerializeField] private Button _hirewariorButton;         // ������ ��� ����� ������
    [SerializeField] private float _defaultTimeHiringWariors;  // ����� ��� ����� ������
    [SerializeField] private AudioSource _audioSoursewariorButton;  // ����� ���� ��� ������ �������� ������
    [SerializeField] private AudioClip _audioClipwariorButton;      // ����� ���� ��� ������ �������� ������

    //�������
    [SerializeField] private GameObject _startMenuCanvs;      // ����� ���� ��� ������ �������� ������
    [SerializeField] private GameObject _gameCanfas;      // ����� ���� ��� ������ �������� ������


    //��������� ��������� �������� ����
    [SerializeField] private float _defoultCountWheat;   // ��������� ���-�� �������
    [SerializeField] private float _defoultCountPeasunt; // ��������� ���-�� ��������
    [SerializeField] private float _defoultCountWariors; // ��������� ���-�� ������
    [SerializeField] private float _defoultVictoryWheat; // ��������� ���-�� ������

    //��������� ��� ������� ���������.
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private Text _gameOverOrFinishGameText;
    [SerializeField] private Text _RadeWaveFinalText;
    [SerializeField] private Text _deadVariorsText;


    //���������� ��� ��������� ������ ����
    private float _wheatCount;   // ���������� ��� �������� ������.
    private float _peasuntCount; // ���������� ��� �������� ��������.
    private float _wariorsCount; // ���������� ��� �������� ������.

    //���������� ��� ������ ����� ������� ������
    private float _curentTimerRaid;                         // ���������� ��� �������� ������� ������� �������
    private float _countWariorsRaidNull;                    // ���������� ��� �������� ������� ���� ������ � ������ ����
    private float _countWariorsRaidWave;                    // ���������� ��� �������� ���-�� ������ � �����
    private float _countRaidWave;                           // ���������� ��� �������� ���-�� ����
    private float _deadVariors;                             // ���������� ��� �������� ���-�� ������ ������
    private float _curentTimeOfPlusInfoPanelTimerRaidPanel; // ���������� ��� �������� ������� ��� ������ ������ � �������������� ���������� �� �����

    // ���������� ��� ������ ����� ����������� ���
    private float _curentTimerFoodConsumption;                         // ���������� ��� �������� ������� ������� �������� ���
    private float _curentTimeOfPlusInfoPanelTimerFoodConsumptionPanel; // ���������� ��� �������� ������� ��� ������ ������ � ����������� � ��������� ���
    
    // ���������� ��� ������ ����� ����� ������
    private float _curentTimerHarvest;                         // ���������� ��� �������� ������� ������� ����� ������
    private float _curentTimeOfPlusInfoPanelTimerHarvestPanel; // ���������� ��� �������� ������� ��� ������ ������ � ����������� � ����� ������

    // ���������� ��� ������ � �������� �����
    private Image _imageHirePeasantButton;
    private float _countTimeHiringPeasants;
    private bool _isClickPeasantButton;

    private Image _imageHireWariorButton;
    private float _countTimeHiringWariors;
    private bool _isClickWariorButton;

    //-------------------------------------------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        PurposeDefoultCountInTextResursePanel();
        PurposeDefaultCountinRaidPanel();
        PurposeDefaultCountInFoodConsumptionPanel();
        PurposeDefaultCountInHarvestPanel();
        FromButtonGetCompanentInImage();


    }

    void Update()
    {
        if (_startMenuCanvs.active == false)
        {
            JobRaidPanel();
            JobFoodConsumptionPanel();
            JobHarvestPanel();
            TimerImagePeasanButton();
            TimerImageWariorButton();
            GameOver();
            VictoryGame();
        }
    }


// ������� ������
    private void VictoryGame()
    {
        if(_wheatCount >= _defoultVictoryWheat)
        {
            Time.timeScale = 0;
            _finishPanel.SetActive(true);
            _gameOverOrFinishGameText.text = "������";
            _RadeWaveFinalText.text = _countRaidWave.ToString();
            _deadVariorsText.text = _deadVariors.ToString();
        }
    }    

// ������� ���������
    private void GameOver()
    {
        if (_wariorsCount < 0 || _wheatCount < 0) 
        {
            Time.timeScale = 0;
            _finishPanel.SetActive(true);
            _gameOverOrFinishGameText.text = "���������";
            _RadeWaveFinalText.text = _countRaidWave.ToString();
            _deadVariorsText.text = _deadVariors.ToString();
        }
    }

// ���������� ����
    public void RestartGame()
    {

        PurposeDefoultCountInTextResursePanel();
        PurposeDefaultCountinRaidPanel();
        PurposeDefaultCountInFoodConsumptionPanel();
        PurposeDefaultCountInHarvestPanel();
        FromButtonGetCompanentInImage();

        _finishPanel.SetActive(false);
        Time.timeScale = 1;
    }

// ��������� ���� � ��������� � ����
    public void EndGame()
    {
        _finishPanel.SetActive(false);
        _gameCanfas.SetActive(false);
        _startMenuCanvs.SetActive(true);
        Time.timeScale = 1;
    }

// ������ ����
    public void StartGame()
    {
        _finishPanel.SetActive(false);
        _startMenuCanvs.SetActive(false);

        RestartGame();

        _gameCanfas.SetActive(true);
    }


// ������ � ������� ��������------------------------------------------------------

    //����� ��������� ��������� ��������
    //� ���� ��� ����������� �� ������ ��������
    //� � ���������� ��� ��������� � ����� ����. 
    // �������� 1 ��� � ������ ����(�� ��� �� ����� :) )
    private void PurposeDefoultCountInTextResursePanel()
    {
        _wheatTextResursePanel.text = _defoultCountWheat.ToString();
        _peasuntsTextResursePanel.text = _defoultCountPeasunt.ToString();
        _wariorsTextResursePanel.text = _defoultCountWariors.ToString();

        _wheatCount = _defoultCountWheat;
        _peasuntCount = _defoultCountPeasunt;
        _wariorsCount = _defoultCountWariors;
    }

// ������ � ������� ����� ������--------------------------------------------------

    // ����� �������� �� ��� ������ ������ ������ ����� ������ � ��������� ������� � ������ �������� ��� ����� ���-�� ��������
    private void JobHarvestPanel()
    {
        if (_curentTimerHarvest > 0)
        {
            if (_curentTimeOfPlusInfoPanelTimerHarvestPanel <= 0)
            {
                _plusInfoPanelHarvestCuclePanel.SetActive(false);
            }

            _curentTimeOfPlusInfoPanelTimerHarvestPanel -= Time.deltaTime;
            _curentTimerHarvest -= Time.deltaTime;
            UpdateTimerText(_curentTimerHarvest, _timerTextHarvestCuclePanel);

        }
        else
        {
            _audioSourseHarvestPanel.PlayOneShot(_audioClipHarvestPanel);

            _plusInfoPanelHarvestCuclePanel.SetActive(true);
            float peasuntInWheat = _peasuntCount * 2;
            _plusInfoPanelTextHarvestCuclePanel.text = string.Format("+{0}", peasuntInWheat.ToString());
            _wheatCount += peasuntInWheat;
            _wheatTextResursePanel.text = _wheatCount.ToString();

            _curentTimerHarvest = _timerHarvestCuclePanel;
            _curentTimeOfPlusInfoPanelTimerHarvestPanel = _plusInfoPanelTimerHarvestCuclePanel;

        }
    }

    //����� ��������� ��������� ��������
    //��� ������ ����� ����� ������
    //� � ���������� ��� �������� ������ ����
    //���������� 1 ��� ��� ������
    private void PurposeDefaultCountInHarvestPanel()
    {
        _curentTimerHarvest = _timerHarvestCuclePanel;
        _timerTextHarvestCuclePanel.text = _curentTimerHarvest.ToString();

        _plusInfoPanelHarvestCuclePanel.SetActive(false);
        _curentTimeOfPlusInfoPanelTimerHarvestPanel = _plusInfoPanelTimerHarvestCuclePanel;

    }

// ������ � ������� ����������� ���-----------------------------------------------

    // ����� �������� �� ��� ������ ������ ������ ����������� ��� � ��������� ��� � ������ �������� ��� �������� ��� �������
    private void JobFoodConsumptionPanel()
    {
        if (_curentTimerFoodConsumption > 0)
        {
            if (_curentTimeOfPlusInfoPanelTimerFoodConsumptionPanel <= 0)
            {
                _plusInfoPanelFoodConsumptionPanel.SetActive(false);
            }

            _curentTimeOfPlusInfoPanelTimerFoodConsumptionPanel -= Time.deltaTime;
            _curentTimerFoodConsumption -= Time.deltaTime;
            UpdateTimerText(_curentTimerFoodConsumption, _timerTextFoodConsumptionPanel);

        }
        else
        {
            _audioSourseFoodConsumptionPanel.PlayOneShot(_audioClipFoodConsumptionPanel);

            _plusInfoPanelFoodConsumptionPanel.SetActive(true);
            _plusInfoPanelTextFoodConsumptionPanel.text = string.Format("-{0}", _wariorsCount.ToString());
            _wheatCount -= _wariorsCount;
            _wheatTextResursePanel.text = _wheatCount.ToString();

            _curentTimerFoodConsumption = _timerFoodConsumptionPanel;
            _curentTimeOfPlusInfoPanelTimerFoodConsumptionPanel = _plusInfoPanelTimerFoodConsumptionPanel;

        }
    }

    //����� ��������� ��������� ��������
    //��� ������ ����� ����������� ���
    //� � ���������� ��� �������� ������ ����
    //���������� 1 ��� ��� ������
    private void PurposeDefaultCountInFoodConsumptionPanel()
    {
        _curentTimerFoodConsumption = _timerFoodConsumptionPanel;
        _timerTextFoodConsumptionPanel.text = _curentTimerFoodConsumption.ToString();

        _plusInfoPanelFoodConsumptionPanel.SetActive(false);
        _curentTimeOfPlusInfoPanelTimerFoodConsumptionPanel = _plusInfoPanelTimerFoodConsumptionPanel;

    }

// ������ � ������� �������--------------------------------------------------------

    // ����� �������� �� ��� ������ ������ ������ �������
    private void JobRaidPanel()
    {
        if (_curentTimerRaid > 0)
        {
            if (_curentTimeOfPlusInfoPanelTimerRaidPanel <= 0)
            {
                _plusInfoPanelRaidPanel.SetActive(false);
            }

            _curentTimeOfPlusInfoPanelTimerRaidPanel -= Time.deltaTime;
            _curentTimerRaid -= Time.deltaTime;
            UpdateTimerText(_curentTimerRaid, _timerTextRaidPanel);

        }
        else
        {
            _audioSourseRaidPanel.PlayOneShot(_audioClipRaidPanel);
            _plusInfoPanelRaidPanel.SetActive(true);
            _curentTimerRaid = _timerRaidPanel;
            _curentTimeOfPlusInfoPanelTimerRaidPanel = _plusInfoPanelTimerRaidPanel;


            _wariorsCount -= _countWariorsRaidWave;
            _wariorsTextResursePanel.text = _wariorsCount.ToString();
            if (_wariorsCount >= 0)
            {
                _countRaidWave++;
                _deadVariors += _countWariorsRaidWave;
            }

            _countWariorsRaidNull--;

            if (_countWariorsRaidNull < 0)
            {
                _countWariorsRaidWave += _wariorsPlusInRaid;
                _countWariorsRaidText.text = _countWariorsRaidWave.ToString();
            }
        }
    }

    //����� ��������� ��������� ��������
    //��� ������ ����� ������� ������
    //� � ���������� ��� �������� ������ ����
    //���������� 1 ��� ��� ������
    private void PurposeDefaultCountinRaidPanel()
    {
        _curentTimerRaid = _timerRaidPanel;
        _timerTextRaidPanel.text = _curentTimerRaid.ToString();

        _countWariorsRaidWave = _countWariorsRaid;
        _countWariorsRaidText.text = _countWariorsRaidWave.ToString();

        _curentTimeOfPlusInfoPanelTimerRaidPanel = _plusInfoPanelTimerRaidPanel;
        _plusInfoPanelRaidPanel.SetActive(false);

        _countWariorsRaidNull = _countWariorsNullRaid;
        _countRaidWave = 0;
        _deadVariors = 0;
    }

// ������ � �������� �������--------------------------------------------------------

    public void OnClickPeasantButton()
    {
        if (_hirePeasantButton.interactable == true)
        {
            _isClickPeasantButton = true;

            _wheatCount -= 1;
            _wheatTextResursePanel.text = _wheatCount.ToString();
        }

    }

    private void TimerImagePeasanButton()
    {
        if (_wheatCount > 0 && _imageHirePeasantButton.fillAmount == 1)
        {
            _hirePeasantButton.interactable = true;

        }
        else
        {
            _hirePeasantButton.interactable = false;

        }

        if (_isClickPeasantButton && _wheatCount > 0)
        {
            _hirePeasantButton.interactable = false;

            _imageHirePeasantButton.fillAmount = 0;
            _countTimeHiringPeasants += Time.deltaTime;
            _imageHirePeasantButton.fillAmount += _countTimeHiringPeasants / _defaultTimeHiringPeasants;

            if (_countTimeHiringPeasants >= _defaultTimeHiringPeasants)
            {

                _peasuntCount += 1;
                _audioSoursePeasantButton.PlayOneShot(_audioClipPeasantButton);
                _peasuntsTextResursePanel.text = _peasuntCount.ToString();

                _isClickPeasantButton = false;
                _countTimeHiringPeasants = 0;
            }

        }
        else
        {
            _hirePeasantButton.interactable = true;
            _imageHirePeasantButton.fillAmount = 1;

        }
    }

    public void OnClickWariorButton()
    {
        if (_hirewariorButton.interactable == true)
        {
        _isClickWariorButton = true;

        _wheatCount -= 2;
        _wheatTextResursePanel.text = _wheatCount.ToString();
        }

    }

    private void TimerImageWariorButton()
    {
        if (_wheatCount > 0 && _imageHireWariorButton.fillAmount == 1)
        {
            _hirewariorButton.interactable = true;

        }
        else
        {
            _hirewariorButton.interactable = false;

        }

        if (_isClickWariorButton && _wheatCount > 0)
        {
            _hirewariorButton.interactable = false;

            _imageHireWariorButton.fillAmount = 0;
            _countTimeHiringWariors += Time.deltaTime;
            _imageHireWariorButton.fillAmount += _countTimeHiringWariors / _defaultTimeHiringWariors;

            if (_countTimeHiringWariors >= _defaultTimeHiringWariors)
            {

                _wariorsCount += 1;
                _audioSoursewariorButton.PlayOneShot(_audioClipwariorButton);
                _wariorsTextResursePanel.text = _wariorsCount.ToString();

                _isClickWariorButton = false;
                _countTimeHiringWariors = 0;
            }

        }
        else
        {
            _hirewariorButton.interactable = true;
            _imageHireWariorButton.fillAmount = 1;

        }
    }

    private void FromButtonGetCompanentInImage()
    {
        _imageHirePeasantButton = _hirePeasantButton.GetComponent<Image>();
        _countTimeHiringPeasants = 0;
        _isClickPeasantButton = false;

        _imageHireWariorButton = _hirewariorButton.GetComponent<Image>();
        _countTimeHiringWariors = 0;
        _isClickWariorButton = false;
    }


// ����� ������---------------------------------------------------------------------

    // ����� ����� ��� ������ ������� � �������� ���� ���� �������
    private void UpdateTimerText(float time, Text timerText)
    {
        if (time < 0)
        {
            time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }

}
