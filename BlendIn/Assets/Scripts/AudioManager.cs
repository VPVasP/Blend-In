using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip collectingInfoSoundEffect;
    [SerializeField] private AudioClip informationGivenSoundEffect;
    [SerializeField] private AudioClip alertedSoundEffect;
    private AudioSource aud;
    private bool playedWarningSound;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    //play sound effect based on a string
    public void PlaySoundEffect(string soundType)
    {
        switch (soundType)
        {
            case "collectingInfo":
                aud.clip = collectingInfoSoundEffect;
                aud.loop = true;
                break;
            case "informationGiven":
                aud.clip = informationGivenSoundEffect;
                aud.loop = false;
                break;
            case "alerted":
                aud.clip = alertedSoundEffect;
                aud.loop = true;
                break;
            default:
                Debug.LogWarning("No sound attached");
                return;
        }

        aud.Play();
    }


}
