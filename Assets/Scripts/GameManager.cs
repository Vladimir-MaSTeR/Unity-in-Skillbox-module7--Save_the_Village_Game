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

    [SerializeField] private Button _pauseButtonResursePanel;  // ������ �����
    [SerializeField] private Button _menuButtonResursePanel;   // ������ ���� (��� ������� ������ ���������� �����)
    [SerializeField] private Button _onOfMusicResursePanel;    // ������ ���\���� ������� ������

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
    [SerializeField] private float _wariorsPlusInRaid;           // ���������� �������� ������� �� ������� ����������� ���-�� ������ � ����. �����.
    [SerializeField] private Text _countWariorsRaidText;         // ��������� ���� ��� ����������� �������� ���-�� ������ � �����

    [SerializeField] private GameObject _plusInfoPanelRaidPanel; // ������������ ����� � ������������ ��� ���������� �� ���������� ����� ����������� ���
    [SerializeField] private Text _plusInfoPanelTextRaidPanel;   // ����� �� ������������ ������(����������� ���������� ������� ��� �������)
    [SerializeField] private float _plusInfoPanelTimerRaidPanel; // ���������� � ��� ������� ������� ������� ���������� ������ � ��� ����������(����� ������� ������ ��������� ������)

    [SerializeField] private AudioSource _audioSourseRaidPanel;  // ����� ���� ��� ������ �������
    [SerializeField] private AudioClip _audioClipRaidPanel;  // ����� ���� ��� ������ �������

    //������ ��� ����
    [SerializeField] private Button _hirePeasantButton;  // ������ ��� ����� ��������
    [SerializeField] private float _defaultTimeHiringPeasants;  // ����� ��� ����� ��������

    [SerializeField] private Button _hirewariorButton;   // ������ ��� ����� ������
    [SerializeField] private float _defaultTimeHiringWariors;  // ����� ��� ����� ������


    //��������� ��������� �������� ����
    [SerializeField] private float _defoultCountWheat;   // ��������� ���-�� �������
    [SerializeField] private float _defoultCountPeasunt; // ��������� ���-�� ��������
    [SerializeField] private float _defoultCountWariors; // ��������� ���-�� ������


    //���������� ��� ��������� ������ ����
    private float _wheatCount;   // ���������� ��� �������� ������.
    private float _peasuntCount; // ���������� ��� �������� ��������.
    private float _wariorsCount; // ���������� ��� �������� ������.

    //���������� ��� ������ ����� ������� ������
    private float _curentTimerRaid;                         // ���������� ��� �������� ������� ������� �������
    private float _countWariorsRaidWave;                    // ���������� ��� �������� ���-�� ������ � �����
    private float _countRaidWave;                           // ���������� ��� �������� ���-�� ����
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

    private Image _imageHirewariorButton;
    private float _countTimeHiringWariors;
    //-------------------------------------------------------------------------------------------------------------------------------------------------------


    private void timerImagePeasanButton()
    {
        if (_wheatCount > 0 && _imageHirePeasantButton.fillAmount == 1)
        {
            _hirePeasantButton.interactable = true;
            _countTimeHiringPeasants = _defaultTimeHiringPeasants;

            _hirePeasantButton.onClick.AddListener(actionOnclickPeasanButton);

        } else
        {
            _hirePeasantButton.interactable = false;
        }
    }

    private void actionOnclickPeasanButton()
    {
        _hirePeasantButton.interactable = false;

        if (_countTimeHiringPeasants > 0)
        {
            _countTimeHiringPeasants -= Time.deltaTime;
            _imageHirePeasantButton.fillAmount = 0;
            _imageHirePeasantButton.fillAmount += (_countTimeHiringPeasants / _defaultTimeHiringPeasants);
        } else
        {
            _hirePeasantButton.interactable = true;
            _imageHirePeasantButton.fillAmount = 1;
        }
    }

    //����� ��������� ���������� �������� � ������
    private void fromButtonGetCompanentInImage()
    {
        _imageHirePeasantButton = _hirePeasantButton.GetComponent<Image>();
        _imageHirewariorButton = _hirewariorButton.GetComponent<Image>();

        _countTimeHiringPeasants = _defaultTimeHiringPeasants;
        _countTimeHiringWariors = _defaultTimeHiringWariors;
    }



    void Start()
    {
        purposeDefoultCountInTextResursePanel();
        purposeDefaultCountinRaidPanel();
        purposeDefaultCountInFoodConsumptionPanel();
        purposeDefaultCountInHarvestPanel();
        fromButtonGetCompanentInImage();


    }

    void Update()
    {
        jobRaidPanel();
        jobFoodConsumptionPanel();
        jobHarvestPanel();
        timerImagePeasanButton();
    }


// ������ � ������� ��������------------------------------------------------------

    //����� ��������� ��������� ��������
    //� ���� ��� ����������� �� ������ ��������
    //� � ���������� ��� ��������� � ����� ����. 
    // �������� 1 ��� � ������ ����(�� ��� �� ����� :) )
    private void purposeDefoultCountInTextResursePanel()
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
    private void jobHarvestPanel()
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
    private void purposeDefaultCountInHarvestPanel()
    {
        _curentTimerHarvest = _timerHarvestCuclePanel;
        _timerTextHarvestCuclePanel.text = _curentTimerHarvest.ToString();

        _plusInfoPanelHarvestCuclePanel.SetActive(false);
        _curentTimeOfPlusInfoPanelTimerHarvestPanel = _plusInfoPanelTimerHarvestCuclePanel;

    }

// ������ � ������� ����������� ���-----------------------------------------------

    // ����� �������� �� ��� ������ ������ ������ ����������� ��� � ��������� ��� � ������ �������� ��� �������� ��� �������
    private void jobFoodConsumptionPanel()
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
    private void purposeDefaultCountInFoodConsumptionPanel()
    {
        _curentTimerFoodConsumption = _timerFoodConsumptionPanel;
        _timerTextFoodConsumptionPanel.text = _curentTimerFoodConsumption.ToString();

        _plusInfoPanelFoodConsumptionPanel.SetActive(false);
        _curentTimeOfPlusInfoPanelTimerFoodConsumptionPanel = _plusInfoPanelTimerFoodConsumptionPanel;

    }

// ������ � ������� �������--------------------------------------------------------

    // ����� �������� �� ��� ������ ������ ������ �������
    private void jobRaidPanel()
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

            _countWariorsRaidWave += _wariorsPlusInRaid;
            _countWariorsRaidText.text = _countWariorsRaidWave.ToString();

        }
    }

    //����� ��������� ��������� ��������
    //��� ������ ����� ������� ������
    //� � ���������� ��� �������� ������ ����
    //���������� 1 ��� ��� ������
    private void purposeDefaultCountinRaidPanel()
    {
        _curentTimerRaid = _timerRaidPanel;
        _timerTextRaidPanel.text = _curentTimerRaid.ToString();

        _countWariorsRaidWave = _countWariorsRaid;
        _countWariorsRaidText.text = _countWariorsRaidWave.ToString();

        _curentTimeOfPlusInfoPanelTimerRaidPanel = _plusInfoPanelTimerRaidPanel;
        _plusInfoPanelRaidPanel.SetActive(false);
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