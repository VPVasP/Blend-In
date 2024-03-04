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
    [SerializeField] private AudioClip alertedSoundEffect;
    [SerializeField]   private bool playedCollectingInfoSound;
    private bool playedWarningSound;
    [SerializeField] MeshRenderer meshRendered;
    [SerializeField] private AudioClip collectingInfoSoundEffect;
    [SerializeField] private AudioClip informationGivenSoundEffect;
    private void Start()
    {
        info = transform.parent.GetComponent<CollectInfo>();
        infoSlider = gameObject.GetComponentInChildren<Slider>();
        infoSlider.gameObject.SetActive(false);
        generalInfoGiverSlider = GameObject.Find("CollectedInfoSlider").GetComponent<Slider>();
        sliderImage.gameObject.SetActive(false);
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
        meshRendered = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if (infoSlider.value==100&&!isInfoGiven)
        {
            aud.clip = informationGivenSoundEffect;
            aud.Play();
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
            //if the colors match add 15 value each seacond and activate the slider
            if (info.colorsMatch)
            {
                infoSlider.value += 15 *Time.deltaTime;
                infoSlider.gameObject.SetActive(true);
                if (!playedCollectingInfoSound)
                {
                    aud.clip = collectingInfoSoundEffect;
                    aud.Play();
                    aud.loop = true;
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
                    aud.clip = alertedSoundEffect;
                    aud.Play();
                    aud.loop = true;
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
        aud.Stop();
        if (!info.colorsMatch)
        {
            Debug.Log("Colors dont match");
            playedWarningSound = false;
            playedCollectingInfoSound = false;
            aud.Stop();
        }
    }
       
    }
