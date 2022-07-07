using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetings : MonoBehaviour
{

    private Image image;
    
    void Start()
    {
        image = GetComponent<Image>();
    }
    public void correctVolumeMinusMusic(GameObject gameObject) {
        if (image.fillAmount > 0)
        {
            image.fillAmount -= 0.1f;
            gameObject.GetComponent<AudioSource>().volume -= 0.1f;
        }
    } 
    public void correctVolumePlusMusic(GameObject gameObject) {
        if (image.fillAmount < 1)
        {
            image.fillAmount += 0.1f;
            gameObject.GetComponent<AudioSource>().volume += 0.1f;
        }
    }



}
