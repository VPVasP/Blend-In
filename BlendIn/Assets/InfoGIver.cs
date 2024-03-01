using UnityEngine;
using UnityEngine.UI;

public class InfoGIver : MonoBehaviour
{
   [SerializeField] CollectInfo info;
    private Slider infoSlider;
    private void Start()
    {
        info = transform.parent.GetComponent<CollectInfo>();
        infoSlider = gameObject.GetComponentInChildren<Slider>();
        infoSlider.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (infoSlider.value==100)
        {
            Debug.Log("Slider is now full");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        infoSlider.gameObject.SetActive(true);
        if (other.CompareTag("Player"))
        {
            if (info.colorsMatch)
            {
              infoSlider.value += 5 *Time.deltaTime;
            }
            if (!info.colorsMatch)
            {
                Debug.Log("Colors dont match");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        infoSlider.gameObject.SetActive(false);
        if (!info.colorsMatch)
        {
            Debug.Log("Colors dont match");
        }
    }
}
