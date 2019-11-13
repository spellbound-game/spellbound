using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicVol : MonoBehaviour
{
    private float ctrl;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        ctrl = GameObject.Find("MusicController").GetComponent<AudioSource>().volume;
        slider.value = ctrl;

    }
    public void OnSliderChange()
    {
        GameObject.Find("MusicController").GetComponent<AudioSource>().volume = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
