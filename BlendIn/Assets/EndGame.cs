using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public static EndGame instance;
    [SerializeField] private AudioSource aud;
    [SerializeField] private GameObject endScreen;
    private bool playedEndGameSound;
    [SerializeField] private InfoGIver[] infoGivers;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        endScreen.SetActive(false);
        infoGivers = FindObjectsOfType<InfoGIver>();
    }
    public void PlayerDied()
    {
        if(!playedEndGameSound)
        {
            endScreen.SetActive(true);
            aud.Play();
            playedEndGameSound = true;
            foreach(var info in infoGivers)
            {
                info.aud.Stop();
            }
        }
   
    }
}
