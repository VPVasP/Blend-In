using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Components")]
    private CharacterController characterController;
    [Header("Values")]
    [SerializeField] private float walkSpeed;
    private Vector3 playerVelocity;
    private AudioSource aud;
    public Color[] colors;

    private void Start()
    {
      //  anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        gameObject.tag = "Player";
        aud = GetComponent<AudioSource>();
        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;
    }
    private void Update()
    {

        MovementFunction();
        ChangeMaterial();
    }
    private void MovementFunction()
    {
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(moveVector * Time.deltaTime * walkSpeed);
        if (moveVector != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref playerVelocity.y, 0.1f);
            angle = Mathf.Repeat(angle, 360f);

            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
      
      
    }
    private void ChangeMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            if (renderer != null)
            {
                renderer.material.color = Color.red;
            }
        }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
   
                if (renderer != null)
                {
                renderer.material.color = Color.green;
            }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
               
                if (renderer != null)
                {
                renderer.material.color = Color.blue;
                }
            }
        }
    }

