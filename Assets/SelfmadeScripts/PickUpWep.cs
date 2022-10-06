using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWep : MonoBehaviour
{

    public ProjectileGun gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpscam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;


    void Start()
    {
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if(equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }
    private void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) 
            PickUp();

        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make new wep a child of the camera and moves it to the player
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //makes the wep a trigger and so it does not move
        rb.isKinematic = true;
        coll.isTrigger = true;

        //enable script
        gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //set parent to null
        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        //gun follows player movementspeed
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //add force
        rb.AddForce(fpscam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpscam.up * dropUpwardForce, ForceMode.Impulse);

        //random rotation when dropped
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        //disable script
        gunScript.enabled = false;
    }
    // Start is called before the first frame update


    // Update is called once per frame
}
