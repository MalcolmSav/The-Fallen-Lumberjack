using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    public Transform combatLookAt;

    public GameObject thirdPersonCam;
    public GameObject combatCam;
    public GameObject topDownCam;
    public bool invopen;
    public CameraStyle currentStyle;
    public enum CameraStyle
    
    {
        Basic,
        Combat,
        Topdown
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        invopen = false;
    }

    private void Update()
    {

        // rotate orientation

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
       
        // rotate player object
        if (currentStyle == CameraStyle.Basic || currentStyle == CameraStyle.Topdown)
        {
            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
                orientation.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.Tab) && invopen == false)
        {
            Invoke("FreeMouse", 1);
        }
        else if (Input.GetKey(KeyCode.Tab) && invopen == true)
        {
            Invoke("LockMouse", 1);
        }
    }

    private void FreeMouse()
    {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            invopen = true;
    }
    private void LockMouse()
    {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            invopen = false;     
    }

}
