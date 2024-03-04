using UnityEngine;

public class CollectInfo : MonoBehaviour
{
    //player variable
    [SerializeField] private GameObject player;
    //color check variable
    [SerializeField] private GameObject colorCheck;
    //bool that checks if the colors match
    public bool colorsMatch;
    //bool that checks what color it is 
    public bool isWhite,isRed, isBlue, isYellow;
    //refrence to the rendered component
    [SerializeField] Renderer meshRenderer;
    //refrence to the main camera component
    private Transform mainCamera;
    //refrence to the canvas
    private Canvas canvas;
    private void Start()
    {
        //rendered of the child object
        meshRenderer = GetComponentInChildren<Renderer>();
        //refrence to the canvas object
        canvas = GetComponentInChildren<Canvas>();
        //refrence to the main camera object
        mainCamera = Camera.main.transform;
        //find the gameobject with tag player
        player = GameObject.FindGameObjectWithTag("Player");

        //set the colors based on these conditions
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
        //make the canvas face the camera
        CanvasFaceCamera();
        //check if the colors match
        if (meshRenderer.material.color== player.GetComponentInChildren<Renderer>().material.color)
        {
            colorCheck.GetComponent<Renderer>().material.color = Color.green;
            colorsMatch = true;
        }
        //if the player is invisible all the colors match
        else if (player.GetComponent<Movement>().isInvisible)
        {
            colorCheck.GetComponent<Renderer>().material.color = Color.green;
            colorsMatch = true;
        }
        ///if the colors dont match we set the object to red
        else
        {
            colorCheck.GetComponent<Renderer>().material.color = Color.red;
            colorsMatch = false;
        }
    }
    //method that makes the canvas face the camera 
    private void CanvasFaceCamera()
    {
        canvas.transform.LookAt(canvas.transform.position + mainCamera.rotation * Vector3.forward,
                         mainCamera.rotation * Vector3.up);
    }
}
