using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectInfo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject colorCheck;
    public bool colorsMatch;
    public bool isRed, isBlue, isGreen;
    [SerializeField] Renderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponentInChildren<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (isRed)
        {
            meshRenderer.material.color = Color.red;
        }
      if(isBlue)
        {
            meshRenderer.material.color = Color.blue;
        }
      if(isGreen)
        {
            meshRenderer.material.color = Color.green;
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
