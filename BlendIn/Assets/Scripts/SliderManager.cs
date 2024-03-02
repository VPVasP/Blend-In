using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public static SliderManager instance;
    public Slider invisibilitySlider;
    public Slider alertedSlider;
    public Slider collectInfoSlider;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        invisibilitySlider = GameObject.Find("InvisibilitySlider").GetComponent<Slider>();
        invisibilitySlider.value = 100;
        alertedSlider = GameObject.Find("AlertedSlider").GetComponent<Slider>();
        collectInfoSlider = GameObject.Find("CollectedInfoSlider").GetComponent<Slider>();
        alertedSlider.value = 0;
    }
    private void Update()
    {
        if (invisibilitySlider.value < 100)
        {
            invisibilitySlider.value += 5 * Time.deltaTime;
        }
        if (alertedSlider.value >= 100)
        {
            EndGame.instance.PlayerDied();
        }
        if (collectInfoSlider.value == 100)
        {
            EndGame.instance.WonGame();
        }
    }
    public void AlertedSliderValue()
    {
        alertedSlider.value += 15 * Time.deltaTime;
    }
    public void ResetSliderValue()
    {
        invisibilitySlider.value = 0;
    }
}


