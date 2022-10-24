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

        //if (inputDir != Vector3.zero)
            //orientation.forward = player.position - transform.position;
       
        // rotate player object
        if (currentStyle == CameraStyle.Basic || currentStyle == CameraStyle.Topdown)
        {
            //float horizontalInput = Input.GetAxis("Horizontal");
            //float verticalInput = Input.GetAxis("Vertical");
            //Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
                orientation.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

        else if (currentStyle == CameraStyle.Combat)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
        }

        if (Input.GetKey(KeyCode.Tab) && invopen == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            invopen = true;
        }
        else if (Input.GetKey(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            invopen = false;
        }

    }

}
