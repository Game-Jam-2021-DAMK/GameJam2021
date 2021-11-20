using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rb;

    public bool jumping = false;
    public bool jumpCompleted = false;
    public bool isDead = false;
    public float speed = 10f;
    public float jumpHeight;

    public Vector3 jumpLocation;
    void Start()
    {
        jumpHeight = 3;
        speed = 5f;
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed, ForceMode.Force); // * Time.deltaTime);
            //gameObject.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * speed, ForceMode.Force); // * Time.deltaTime);
            //gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed, ForceMode.Force); // * Time.deltaTime);
            //gameObject.transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
        rb.AddForce(transform.right * speed, ForceMode.Force); // * Time.deltaTime);
            //gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (jumping == false)
        {

            if (Input.GetKey("space"))
            {
                //jumping = true;

                if (jumpLocation == Vector3.zero) { jumpLocation = gameObject.transform.position; }

                rb.AddForce(Vector3.up * speed);
                if (gameObject.transform.position.y >= jumpHeight)
                {
                    jumping = true;
                }

            }
        }
        else if (jumping == true)
        {
            if (gameObject.transform.position.y <= jumpLocation.y + 0.1) 
            {
                jumpLocation = Vector3.zero;
                jumping = false;
            }
        }

    }
}
