using UnityEngine;
using UnityEngine.UI;

public class InfoGIver : MonoBehaviour
{
    CollectInfo info;
    private Slider infoSlider;
    private bool isInfoGiven;
    [SerializeField] private Slider generalInfoGiverSlider;
    [SerializeField] private Image sliderImage;
    public AudioSource aud;
    [SerializeField] private AudioClip checkSoundEffect;
    [SerializeField] private AudioClip alertedSoundEffect;
    private bool playedWarningSound;
    [SerializeField] MeshRenderer meshRendered;
    [SerializeField] private AudioSource informationGivenSoundEffect;
    private void Start()
    {
        info = transform.parent.GetComponent<CollectInfo>();
        infoSlider = gameObject.GetComponentInChildren<Slider>();
        infoSlider.gameObject.SetActive(false);
        generalInfoGiverSlider = GameObject.Find("GeneralInfoSlider").GetComponent<Slider>();
        sliderImage.gameObject.SetActive(false);
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
        meshRendered = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if (infoSlider.value==100&&!isInfoGiven)
        {
            informationGivenSoundEffect.Play();
            generalInfoGiverSlider.value += 20;
            sliderImage.gameObject.SetActive(true);
            isInfoGiven = true;
            aud.loop = false;
            Debug.Log("Slider is now full");
            Destroy(this.gameObject, 2f);

        }
    }
   
    private void OnTriggerStay(Collider other)
    {
      
        if (other.CompareTag("Player")&&!isInfoGiven)
        {
            if (info.colorsMatch)
            {
                infoSlider.value += 15 *Time.deltaTime;
                infoSlider.gameObject.SetActive(true);
                aud.Stop();
            }
            
            if (!info.colorsMatch)
            {
                Debug.Log("Colors dont match");
                SliderManager.instance.AlertedSliderValue();
                meshRendered.material.color = Color.red;
                if (!playedWarningSound)
                {
                    aud.clip = alertedSoundEffect;
                    aud.Play();
                    aud.loop = true;
                    playedWarningSound = true;
                }
               
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        infoSlider.gameObject.SetActive(false);
       
        if (!info.colorsMatch)
        {
            Debug.Log("Colors dont match");
            playedWarningSound = false;
            aud.Stop();
        }
    }
}
