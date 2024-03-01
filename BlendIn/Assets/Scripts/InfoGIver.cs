using UnityEngine;
using UnityEngine.UI;

public class InfoGIver : MonoBehaviour
{
    CollectInfo info;
    private Slider infoSlider;
    private bool isInfoGiven;
    [SerializeField] private Slider generalInfoGiverSlider;
    private void Start()
    {
        info = transform.parent.GetComponent<CollectInfo>();
        infoSlider = gameObject.GetComponentInChildren<Slider>();
        infoSlider.gameObject.SetActive(false);
        generalInfoGiverSlider = GameObject.Find("GeneralInfoSlider").GetComponent<Slider>();
    }
    private void Update()
    {
        if (infoSlider.value==100&&!isInfoGiven)
        {
            generalInfoGiverSlider.value += 20;
            Debug.Log("Slider is now full");
            isInfoGiven = true;
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
