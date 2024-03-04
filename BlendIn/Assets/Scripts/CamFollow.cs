using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //our target variable
    public Transform target;
    //offset variable
    [SerializeField] private Vector3 offset;

    void Start()
    {
        //find the object with tag player and assign it to the target
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //calculate the offset
        offset = transform.position - target.position;
    }

    void Update()
    {
        //update the object's position on all 3 axis 
        transform.position = target.position + offset;
        transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z);
    }
}
