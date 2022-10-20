using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobaCam : MonoBehaviour
{
    public float scrollSpeed;

    public float topBarrier;
    public float botBarrier;
    public float leftBarrier;
    public float rightBarrier;
    // Movement based Scroll Wheel Zoom.
    public Transform parentObject;
    public float zoomLevel;
    public float zoomLevel2;
    public float sensitivity = 1;
    public float speed = 30;
    public float maxZoom = 30;
    float zoomPosition, zoomPosition2;

    private void Update()
    {
        //zoom in
        zoomLevel += Input.mouseScrollDelta.y * sensitivity;
        zoomLevel = Mathf.Clamp(zoomLevel, 0, maxZoom);
        zoomPosition = Mathf.MoveTowards(zoomPosition, zoomLevel, speed * Time.deltaTime);
        transform.position = parentObject.position + (transform.forward * zoomPosition);
       
        //zoom ut 
        zoomLevel2 -= Input.mouseScrollDelta.y * sensitivity;
        zoomLevel2 = Mathf.Clamp(zoomLevel2, 0, maxZoom);
        zoomPosition2 = Mathf.MoveTowards(zoomPosition2, zoomLevel2, speed * Time.deltaTime);
        transform.position = parentObject.position - (transform.forward * zoomPosition2);

        //To stop the camera
        zoomLevel = 0;
        zoomLevel2 = 0;

        //Move camera in all directions
        if (Input.mousePosition.y >= Screen.height*topBarrier)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
        }
        if (Input.mousePosition.y <= Screen.height * botBarrier)
        {
            transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed, Space.World);
        }
        if (Input.mousePosition.x >= Screen.width * rightBarrier)
        {
            transform.Translate(Vector3.right * Time.deltaTime * scrollSpeed, Space.World);
        }
        if (Input.mousePosition.x <= Screen.width * leftBarrier)
        {
            transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed, Space.World);
        }

    }
}
