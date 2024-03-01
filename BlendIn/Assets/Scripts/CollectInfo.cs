using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectInfo : MonoBehaviour
{
    public Color color;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject colorCheck;
    public bool colorsMatch;
    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        renderer.material.color = Color.red;
       
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
