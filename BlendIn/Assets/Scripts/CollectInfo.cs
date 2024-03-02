using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectInfo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject colorCheck;
    public bool colorsMatch;
    public bool isRed, isBlue, isGreen;
    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (isRed)
        {
            renderer.material.color = Color.red;
        }
      if(isBlue)
        {
            renderer.material.color = Color.blue;
        }
      if(isGreen)
        {
            renderer.material.color = Color.green;
        }
    }
    
    private void Update()
    {
        CheckIfColorsMatch();
    }
    void CheckIfColorsMatch()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer.material.color== player.GetComponent<Renderer>().material.color)
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
