using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider DinoTrigger;
    public SphereCollider DangerZone;
    public bool rushPlayer;
    public AudioSource DinoSound;
 
    void FixedUpdate()
    {
      if (rushPlayer == true)
        {
            
            rb.velocity = new Vector3(0, 0, 20);
            PlayDinoSound();
            rushPlayer = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        Destroy(DinoTrigger);
        rushPlayer = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CarBoundary"))
        {
            Destroy(this.gameObject);
        }
    }

    void PlayDinoSound()
    {
        Debug.Log("Dino Roar");
        DinoSound.Play();
    }
}
