using UnityEngine;
using UnityEngine.UI;

public class InfoGIver : MonoBehaviour
{
    CollectInfo info;
    private Slider infoSlider;
    private bool isInfoGiven;
    [SerializeField] private Slider generalInfoGiverSlider;
    [SerializeField] private Image sliderImage;
    [SerializeField] private bool playedCollectingInfoSound;
    private bool playedWarningSound, playedCollectSound = false;
    private MeshRenderer meshRendered;
    private AudioManager audioManager;
    private void Start()
    {
        info = transform.parent.GetComponent<CollectInfo>();
        infoSlider = gameObject.GetComponentInChildren<Slider>();
        infoSlider.gameObject.SetActive(false);
        generalInfoGiverSlider = GameObject.Find("CollectedInfoSlider").GetComponent<Slider>();
        sliderImage.gameObject.SetActive(false);
        meshRendered = GetComponent<MeshRenderer>();
        audioManager = GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (infoSlider.value==100&&!isInfoGiven)
        {
            generalInfoGiverSlider.value += 20;
            sliderImage.gameObject.SetActive(true);
            if (!playedCollectSound)
            {
                audioManager.PlaySoundEffect("informationGiven");
                playedCollectSound = true;
            }
            isInfoGiven = true;
            Debug.Log("Slider is now full");
            Destroy(this.gameObject, 2f);

        }
    }
   
    private void OnTriggerStay(Collider other)
    {
            
        if (other.CompareTag("Player")&&!isInfoGiven)
        {
            //if the colors match add 15 value each seacond and activate the slider
            if (info.colorsMatch)
            {
                infoSlider.value += 15 *Time.deltaTime;
                infoSlider.gameObject.SetActive(true);
                if (!playedCollectingInfoSound)
                {
                    audioManager.PlaySoundEffect("collectingInfo");
                    playedCollectingInfoSound = true;
                }
               
            }
            //if the colors dont match update the alerted slider value
            
            if (!info.colorsMatch)
            {
                
                Debug.Log("Colors dont match");
                SliderManager.instance.AlertedSliderValue();
                meshRendered.material.color = Color.red;
                if (!playedWarningSound)
                {
                    audioManager.PlaySoundEffect("alerted");
                    playedWarningSound = true;
                }
               
            }
        }
    }
    //when we exit the trigger
    private void OnTriggerExit(Collider other)
    {
        infoSlider.gameObject.SetActive(false);
        playedCollectingInfoSound = false;
        audioManager.GetComponent<AudioSource>().Stop();
        if (!info.colorsMatch)
        {
            Debug.Log("Colors dont match");
            playedWarningSound = false;
            playedCollectingInfoSound = false;
            audioManager.GetComponent<AudioSource>().Stop();
        }
    }
       
    }
