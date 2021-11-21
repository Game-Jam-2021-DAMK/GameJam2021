using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public System.Random rd = new System.Random();
    public int carSpeed;
    public Rigidbody rb;
    public float velocity;
    public float timerMax = 10f;
    public AudioSource CarSound;

    // Start is called before the first frame update
    void Start()
    {
        carSpeed = rd.Next(10, 20);
        CarSound.Play();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(carSpeed, 0, 0);
        velocity = rb.velocity.x;
        
    }

    // Destroys car on contact with any object tagged as "CarBoundary"
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CarBoundary"))
        {
            Destroy(this.gameObject);
        }
    }
}
