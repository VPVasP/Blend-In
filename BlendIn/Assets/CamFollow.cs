using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float minZoom = 10f;
    public float maxZoom = 30f;
    public float zoomSpeed = 5f;
    private float currentZoom = 20f;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
        currentZoom = transform.position.y;
    }

    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        transform.position = target.position + offset;
        transform.position = new Vector3(transform.position.x, currentZoom, transform.position.z);
    }
}
