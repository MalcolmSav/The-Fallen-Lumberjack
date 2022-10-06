using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private float speed = 2f;
    //public float moveSpeed = 5f;
    public Animator anim;
    public Rigidbody rb;

    Vector3 movement;

    //public Animator anim;

    void Start()
    {
        //Fetches animator
        anim = gameObject.GetComponent<Animator>();
        Debug.Log(anim);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("key clicked -- chop = true");
            anim.SetBool("jump", true);
        }
        else
            anim.SetBool("jump", false);

        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));

    }


}
