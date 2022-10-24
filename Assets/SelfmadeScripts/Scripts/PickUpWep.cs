using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWep : MonoBehaviour
{

    public ProjectileGun gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, gunBackpack, fpscam;
    //public Item Item;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped, oneWep, twoWep;


    void Start()
    {
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            oneWep = false;
            twoWep = false;
        }
        if(equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            //slotFull = 1;
        }
        Debug.Log(oneWep + " " +twoWep);
    }
    private void Update()
    {
        //Check if player is in range and "F" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        //Equips wep to main hand whene there is no current wep
        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.F) && oneWep == false && gunContainer.childCount <= 2)
        {
            PickUp();
            Debug.Log(oneWep + " " + twoWep);
            oneWep = true;
            Debug.Log("1");
            Debug.Log(oneWep + " " + twoWep);
            
        }
        //Equips next wep to the main hand
        else if (Input.GetKeyDown(KeyCode.Q) && oneWep == true && equipped == true)
        {
            StoreWep();
            gunScript.enabled = false;

            Debug.Log("2");
        }
        else if (Input.GetKeyDown(KeyCode.Q) && equipped == false && oneWep == true)
        {
            StoreWep();
            gunScript.enabled = true;
            Debug.Log("23");
        }
        //Drops the wep in main hand when backpack and main hand is holding gun
        else if (Input.GetKeyDown(KeyCode.E) && twoWep == false)
        {
            Drop();
            oneWep = false;
            Debug.Log("3");
        }

        else if (Input.GetKeyDown(KeyCode.E) && twoWep == true)
        {
            Drop();
            twoWep = false;
            Debug.Log("4");
        }

    
    }

    private void StoreWep()
    {

        //InventoryManager.Instance.Add(Item);
        //Make new wep a child of the camera and moves it to the player
        //transform.SetParent(gunBackpack);

        if (transform.parent == gunBackpack)
        {
            transform.SetParent(gunContainer);
            equipped = true;
        }
        else if (transform.parent == gunContainer) 
        {
            transform.SetParent(gunBackpack);
            equipped = false;
        }

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //makes the wep a trigger and so it does not move
        rb.isKinematic = true;
        coll.isTrigger = true;

        //enable script
        //gunScript.enabled = false;

        Debug.Log("store");


    }

    private void PickUp()
    {
        equipped = true;
        //InventoryManager.Instance.Add(Item);
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
        //set parent to null
        if (transform.parent == gunContainer)
        {
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
            equipped = false;
            
        }

    }
}
