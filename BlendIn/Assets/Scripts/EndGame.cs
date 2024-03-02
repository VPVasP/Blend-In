using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public static EndGame instance;
    [SerializeField] private AudioSource aud;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject infoTexts;
    private bool playedEndGameSound;
    private IEnumerator coroutine;
    private GameObject player;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        endScreen.SetActive(false);
        infoTexts.SetActive(true);
        Time.timeScale = 1;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void PlayerDied()
    {
        endScreen.SetActive(true);
        infoTexts.SetActive(false);
        endScreen.GetComponentInChildren<TextMeshProUGUI>().text = "End Game! ";
        playedEndGameSound = true;
        player.GetComponent<Movement>().enabled = false;
        Invoke("RestartScene", 3f);
    }
    public void WonGame()
    {

        endScreen.SetActive(true);
        infoTexts.SetActive(false);
        endScreen.GetComponentInChildren<TextMeshProUGUI>().text = "You aquired all the intel! ";
        playedEndGameSound = true;
        player.GetComponent<Movement>().enabled = false;
        Invoke("RestartScene", 3f);
    }
  void  RestartScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}