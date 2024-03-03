using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {

        transform.position = target.position + offset;
        transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z);
    }
}
