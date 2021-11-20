using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZones : MonoBehaviour
{
    
    public Transform checkpointTarget;
    //this can be assigned to nearest checkpoint, the player will be teleported there on death.

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           other.gameObject.transform.position = checkpointTarget.transform.position;
            //sets position of "player" tagged objects to the position of the checkpoint target
           
           other.attachedRigidbody.velocity = new Vector3(0, 0, 0);
           //sets the velocity of the object to zero (this may need tweaking)
        }
    }
}
