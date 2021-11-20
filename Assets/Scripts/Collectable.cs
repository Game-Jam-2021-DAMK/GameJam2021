using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool collected = false;
    public bool movingDown = false;
    public float timerMax = 4.0f;
    public AudioSource sound;
    public ParticleSystem explosion;

    public Vector3 collectableSize;

    public float bobUp;
    public float bobDown;
    public float bobSpeed;
    public float shrinkRate = -15f;
    public float growRate = 15f;

    void Start()
    {
        bobUp = transform.position.y + 1;
        bobDown = transform.position.y;

        explosion.transform.position = this.transform.position;
        collectableSize = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1.0f, 1.0f, 1.0f, Space.World);
        Bobbing();

        if (collected == false)
        {
            if (transform.localScale.y < collectableSize.y)
            {
                transform.localScale += new Vector3(0.1F, .1f, .1f) * growRate * Time.deltaTime;

            }
        }

        if (collected)
        {
          

            if (transform.localScale.y > 0)
            {
                transform.localScale += new Vector3(0.1F, .1f, .1f) * shrinkRate * Time.deltaTime;

                if (transform.localScale.y < 0)
                {

                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    
                    
                }
            }
            
        }
    }

    void Bobbing()
    {
        if (movingDown == false)
        {
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);

            if (transform.position.y > bobUp)
            {
                movingDown = true;
                
            }
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime, Space.World);

            if (transform.position.y < bobDown)
            {
                movingDown = false;

            }
        }

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sound.Play(0);
            explosion.Emit(30);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            collected = true;
        }
    }
}
