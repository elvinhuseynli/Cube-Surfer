using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Variables are declared here
    public Transform targetObject;
    public Vector3 cameraOffset;

    //In this part we are creating a constant that will help us to follow the main target object with camera
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }
    
    //Here we assign new position for camera relative to target object's position
    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = newPosition;
    }
}
