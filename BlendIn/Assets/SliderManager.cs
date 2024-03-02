using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public static SliderManager instance;
    public Slider invisibilitySlider;
    public Slider alertedSlider;
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
        alertedSlider.value = 0;
    }
    private void Update()
    {
        if (invisibilitySlider.value < 100)
        {
            invisibilitySlider.value += 15 * Time.deltaTime;
        }
        if (alertedSlider.value >= 100)
        {
            Debug.Log("End Game");
            EndGame.instance.PlayerDied();
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


