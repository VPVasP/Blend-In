using UnityEngine;
using UnityEngine.UI;

public class InvisibilitySlider : MonoBehaviour
{
    public static InvisibilitySlider instance;
    public Slider invisibilitySlider;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        invisibilitySlider = GameObject.Find("InvisibilitySlider").GetComponent<Slider>();
        invisibilitySlider.value = 100;

    }
    private void Update()
    {
        if (invisibilitySlider.value < 100)
        {
            invisibilitySlider.value += 15 * Time.deltaTime;
        }
      
    }
    public void ResetSliderValue()
    {
        invisibilitySlider.value = 0;
    }
}
