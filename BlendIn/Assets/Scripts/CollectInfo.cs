using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectInfo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject colorCheck;
    public bool colorsMatch;
    public bool isWhite,isRed, isBlue, isYellow;
    [SerializeField] Renderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponentInChildren<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (isWhite)
        {
            meshRenderer.material.color = Color.white;
        }
        if (isRed)
        {
            meshRenderer.material.color = Color.red;
        }
      if(isBlue)
        {
            meshRenderer.material.color = Color.blue;
        }
      if(isYellow)
        {
            meshRenderer.material.color = Color.yellow;
        }
    }
    
    private void Update()
    {
        CheckIfColorsMatch();
    }
    void CheckIfColorsMatch()
    {
        
        if (meshRenderer.material.color== player.GetComponentInChildren<Renderer>().material.color)
        {
            colorCheck.GetComponent<Renderer>().material.color = Color.green;
            colorsMatch = true;
        }
        else if (player.GetComponent<Movement>().isInvisible)
        {
            colorCheck.GetComponent<Renderer>().material.color = Color.green;
            colorsMatch = true;
        }
        else
        {
            colorCheck.GetComponent<Renderer>().material.color = Color.red;
            colorsMatch = false;
        }
    }
}
