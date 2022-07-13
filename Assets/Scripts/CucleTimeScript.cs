using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CucleTimeScript : MonoBehaviour
{
    [SerializeField] private float defoultTimeCucle;
    [SerializeField] private Text timerText;

    [SerializeField] private GameObject plusInfoPanel;
    [SerializeField] private Text plusInfoPanelText;
    [SerializeField] private float plusInfoPanelTimer;


    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private float curentTime;
    private float plusInfoCountPanelText;
    private float plusInfoCountPanelTimerOf;


    void Start()
    {
        curentTime = defoultTimeCucle;
        plusInfoCountPanelText = 0f;
        plusInfoCountPanelTimerOf = plusInfoPanelTimer;

        timerText.text = curentTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (curentTime > 0)
        {
            if (plusInfoCountPanelTimerOf <= 0)
            {
                plusInfoPanel.SetActive(false);
            }

            plusInfoCountPanelTimerOf -= Time.deltaTime;
            curentTime -= Time.deltaTime;
            UpdateTimerText(curentTime);
        } else
        {
            UpdateharvestCountInResursesPanel();
            curentTime = defoultTimeCucle;
        }
    }

    private void UpdateTimerText(float time)
    {
        if (time < 0)
        {
            time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }

    private void UpdateharvestCountInResursesPanel()
    {
        plusInfoCountPanelText += 1;
        plusInfoPanelText.text = string.Format("+{0}", plusInfoCountPanelText.ToString());
        plusInfoPanel.SetActive(true);
        plusInfoCountPanelTimerOf = plusInfoPanelTimer;
        audioSource.PlayOneShot(audioClip);
    }

}
