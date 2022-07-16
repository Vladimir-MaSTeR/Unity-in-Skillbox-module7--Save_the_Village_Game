using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Панель ресурсов
    [SerializeField] private Text _wheatTextResursePanel;    // Текстовое поле для отображения кол-ва пшеницы
    [SerializeField] private Text _peasuntsTextResursePanel; // Текстовое поле для отображения кол-ва крестьян
    [SerializeField] private Text _wariorsTextResursePanel;  // Текстовое поле для отображения кол-ва войнов

    // Панель цикла сбора урожая
    [SerializeField] private float _timerHarvestCuclePanel;             // Время таймера сбора урожая в сек. 
    [SerializeField] private Text  _timerTextHarvestCuclePanel;         // текстовое поле в котором отображается время сбора урожая
   
    [SerializeField] private GameObject _plusInfoPanelHarvestCuclePanel; // Появляющеяся панел с отображением доп информации по завершении цикла сбора урожая
    [SerializeField] private Text _plusInfoPanelTextHarvestCuclePanel;   // Текст на появляющеяся панели(планируется показывать скалько урожая собрано)
    [SerializeField] private float _plusInfoPanelTimerHarvestCuclePanel; // Переменная в сек которая говорит сколько показывать панель с доп информацие(через сколько секунд отключить панель)

    [SerializeField] private AudioSource _audioSourseHarvestPanel;  // Аудио сурс для панели потребления еды
    [SerializeField] private AudioClip _audioClipHarvestPanel;      // Аудио клип для панели потребления еды

    // Панель цикла потребления еды
    [SerializeField] private float _timerFoodConsumptionPanel;              // Время таймера потребления еды в сек. 
    [SerializeField] private Text _timerTextFoodConsumptionPanel;           // текстовое поле в котором отображается время потребления еды
   
    [SerializeField] private GameObject _plusInfoPanelFoodConsumptionPanel; // Появляющеяся панел с отображением доп информации по завершении цикла потребления еды
    [SerializeField] private Text _plusInfoPanelTextFoodConsumptionPanel;   // Текст на появляющеяся панели(планируется показывать скалько еды съедено)
    [SerializeField] private float _plusInfoPanelTimerFoodConsumptionPanel; // Переменная в сек которая говорит сколько показывать панель с доп информацие(через сколько секунд отключить панель)

    [SerializeField] private AudioSource _audioSourseFoodConsumptionPanel;  // Аудио сурс для панели потребления еды
    [SerializeField] private AudioClip _audioClipFoodConsumptionPanel;      // Аудио клип для панели потребления еды

    //Панель цикла набега врагов
    [SerializeField] private float _timerRaidPanel;              // Время таймера обозначающее через сколько след. набег в сек 
    [SerializeField] private Text _timerTextRaidPanel;           // текстовое поле в котором отображается время до след набега
    [SerializeField] private float _countWariorsRaid;            // счетчик который показывает кол-во врагов в волне
    [SerializeField] private float _countWariorsNullRaid;        // счетчик который показывает кол-во нулевых волн врагов в начале игры
    [SerializeField] private float _wariorsPlusInRaid;           // переменная когторая говорит на сколько увеличивать кол-во врагов в след. волне.
    [SerializeField] private Text _countWariorsRaidText;         // текстовое поле для отображения счетчика кол-ва врагов в волне

    [SerializeField] private GameObject _plusInfoPanelRaidPanel; // Появляющеяся панел с отображением доп информации по завершении цикла потребления еды
    [SerializeField] private Text _plusInfoPanelTextRaidPanel;   // Текст на появляющеяся панели(планируется показывать скалько еды съедено)
    [SerializeField] private float _plusInfoPanelTimerRaidPanel; // Переменная в сек которая говорит сколько показывать панель с доп информацие(через сколько секунд отключить панель)

    [SerializeField] private AudioSource _audioSourseRaidPanel;  // Аудио сурс для панели набегов
    [SerializeField] private AudioClip _audioClipRaidPanel;      // Аудио клип для панели набегов

    //Кнопки для игры
    [SerializeField] private Button _hirePeasantButton;              // кнопка для найма крестьян
    [SerializeField] private float _defaultTimeHiringPeasants;       // время для найма крестьян
    [SerializeField] private AudioSource _audioSoursePeasantButton;  // Аудио сурс для кнопки создания крестьян
    [SerializeField] private AudioClip _audioClipPeasantButton;      // Аудио клип для кнопки создания крестьян

    [SerializeField] private Button _hirewariorButton;         // Кнопка для найма войнов
    [SerializeField] private float _defaultTimeHiringWariors;  // время для найма войнов
    [SerializeField] private AudioSource _audioSoursewariorButton;  // Аудио сурс для кнопки создания войнов
    [SerializeField] private AudioClip _audioClipwariorButton;      // Аудио клип для кнопки создания войнов

    //Канвасы
    [SerializeField] private GameObject _startMenuCanvs;      // Аудио клип для кнопки создания войнов
    [SerializeField] private GameObject _gameCanfas;      // Аудио клип для кнопки создания войнов


    //Настройки дефолтных значений игры
    [SerializeField] private float _defoultCountWheat;   // начальное кол-во пшеницы
    [SerializeField] private float _defoultCountPeasunt; // начальное кол-во крестьян
    [SerializeField] private float _defoultCountWariors; // начальное кол-во войнов
    [SerializeField] private float _defoultVictoryWheat; // начальное кол-во войнов

    //Настройки для условия поражения.
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private Text _gameOverOrFinishGameText;
    [SerializeField] private Text _RadeWaveFinalText;
    [SerializeField] private Text _deadVariorsText;


    //Переменные для подсчетов внутри игры
    private float _wheatCount;   // переменная для подсчета урожая.
    private float _peasuntCount; // переменная для подсчета крестьян.
    private float _wariorsCount; // переменная для подсчета войнов.

    //переменные для панели цикла набегов врагов
    private float _curentTimerRaid;                         // переменная для подсчета времени таймера набегов
    private float _countWariorsRaidNull;                    // переменная для подсчета нулевых волн врагов в начале игры
    private float _countWariorsRaidWave;                    // переменная для счетчика кол-во врагов в волне
    private float _countRaidWave;                           // переменная для подсчета кол-ва волн
    private float _deadVariors;                             // переменная для подсчета кол-ва убитых врагов
    private float _curentTimeOfPlusInfoPanelTimerRaidPanel; // переменная для подсчета времени для показа панели с дополнительной информации об атаке

    // переменные для панели цикла потребления еды
    private float _curentTimerFoodConsumption;                         // переменная для подсчета времени таймера поедания еды
    private float _curentTimeOfPlusInfoPanelTimerFoodConsumptionPanel; // переменная для подсчета времени для показа панели с информацией о съеденной еде
    
    // переменные для панели цикла сбора урожая
    private float _curentTimerHarvest;                         // переменная для подсчета времени таймера сбора урожая
    private float _curentTimeOfPlusInfoPanelTimerHarvestPanel; // переменная для подсчета времени для показа панели с информацией о сборе урожая

    // переменные для работы с кнопками найма
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


// Условия победы
    private void VictoryGame()
    {
        if(_wheatCount >= _defoultVictoryWheat)
        {
            Time.timeScale = 0;
            _finishPanel.SetActive(true);
            _gameOverOrFinishGameText.text = "Победа";
            _RadeWaveFinalText.text = _countRaidWave.ToString();
            _deadVariorsText.text = _deadVariors.ToString();
        }
    }    

// Условия поражения
    private void GameOver()
    {
        if (_wariorsCount < 0 || _wheatCount < 0) 
        {
            Time.timeScale = 0;
            _finishPanel.SetActive(true);
            _gameOverOrFinishGameText.text = "Поражение";
            _RadeWaveFinalText.text = _countRaidWave.ToString();
            _deadVariorsText.text = _deadVariors.ToString();
        }
    }

// перезапуск игры
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

// Завершить игру и вернуться в меню
    public void EndGame()
    {
        _finishPanel.SetActive(false);
        _gameCanfas.SetActive(false);
        _startMenuCanvs.SetActive(true);
        Time.timeScale = 1;
    }

// Начать игру
    public void StartGame()
    {
        _finishPanel.SetActive(false);
        _startMenuCanvs.SetActive(false);

        RestartGame();

        _gameCanfas.SetActive(true);
    }


// работа с панелью ресурсов------------------------------------------------------

    //Метод назначает дефолтные значения
    //в поля для отображения на панели ресурсов
    //и в переменный для подсчыета в нутри игры. 
    // вызываем 1 раз в начале игры(но это не точно :) )
    private void PurposeDefoultCountInTextResursePanel()
    {
        _wheatTextResursePanel.text = _defoultCountWheat.ToString();
        _peasuntsTextResursePanel.text = _defoultCountPeasunt.ToString();
        _wariorsTextResursePanel.text = _defoultCountWariors.ToString();

        _wheatCount = _defoultCountWheat;
        _peasuntCount = _defoultCountPeasunt;
        _wariorsCount = _defoultCountWariors;
    }

// работа с панелью сбора урожая--------------------------------------------------

    // метод отвечает за всю логику работы панели сбора урожая и обновляет пшеницу в панеле ресурсов при учете кол-ва крестьян
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

    //метод назначает дефолтные значения
    //для панели цикла сбора урожая
    //и в переменные для подсчета внутри игры
    //вызывается 1 раз при старте
    private void PurposeDefaultCountInHarvestPanel()
    {
        _curentTimerHarvest = _timerHarvestCuclePanel;
        _timerTextHarvestCuclePanel.text = _curentTimerHarvest.ToString();

        _plusInfoPanelHarvestCuclePanel.SetActive(false);
        _curentTimeOfPlusInfoPanelTimerHarvestPanel = _plusInfoPanelTimerHarvestCuclePanel;

    }

// работа с понелью потребления еды-----------------------------------------------

    // метод отвечает за всю логику работы панели потребления еды и обновляет еду в панеле ресурсов при поедании еды войнами
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

    //метод назначает дефолтные значения
    //для панели цикла потребления еды
    //и в переменные для подсчета внутри игры
    //вызывается 1 раз при старте
    private void PurposeDefaultCountInFoodConsumptionPanel()
    {
        _curentTimerFoodConsumption = _timerFoodConsumptionPanel;
        _timerTextFoodConsumptionPanel.text = _curentTimerFoodConsumption.ToString();

        _plusInfoPanelFoodConsumptionPanel.SetActive(false);
        _curentTimeOfPlusInfoPanelTimerFoodConsumptionPanel = _plusInfoPanelTimerFoodConsumptionPanel;

    }

// работа с панелью набегов--------------------------------------------------------

    // метод отвечает за всю логику работы панели набегов
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

    //метод назначает дефолтные значения
    //для панели цикла набегов врагов
    //и в переменные для подсчета внутри игры
    //вызывается 1 раз при старте
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

// работа с кнопками покупки--------------------------------------------------------

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


// общие методы---------------------------------------------------------------------

    // общий метод для вывода времени в текствые поля всех панелей
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
