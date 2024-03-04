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
    [SerializeField] private Image warningIcon;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        //assign all the components
        invisibilitySlider = GameObject.Find("InvisibilitySlider").GetComponent<Slider>();
        invisibilitySlider.value = 100;
        alertedSlider = GameObject.Find("AlertedSlider").GetComponent<Slider>();
        collectInfoSlider = GameObject.Find("CollectedInfoSlider").GetComponent<Slider>();
        warningIcon = GameObject.Find("WarningIcon").GetComponent<Image>();
        alertedSlider.value = 0;
        collectInfoSlider.maxValue = 160;
    }
    private void Update()
    {
        //if the invisible slider is not full add 10 each second
        if (invisibilitySlider.value < 100)
        {
            invisibilitySlider.value += 10 * Time.deltaTime;
        }
        //if the alerted slider is full then end game
        if (alertedSlider.value >= 100)
        {
            EndGame.instance.PlayerDied();
        }
        //if the alerted slider is equal or above 50 activate the warning icon animation 
        if (alertedSlider.value >=50)
        {
            warningIcon.GetComponent<Animator>().SetBool("isWarningActivated", true);
        }
        //if collected all the info win the game
        if (collectInfoSlider.value == 160)
        {
            EndGame.instance.WonGame();
        }
    }
    //update the alerted slider
    public void AlertedSliderValue()
    {
        alertedSlider.value += 15 * Time.deltaTime;
    }
    //reset the invisibility slider
    public void ResetSliderValue()
    {
        invisibilitySlider.value = 0;
    }
}


