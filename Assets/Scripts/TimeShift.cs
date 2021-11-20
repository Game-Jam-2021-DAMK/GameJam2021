using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShift : MonoBehaviour
{
    public GameObject JurassicParent;
    public GameObject SynthwaveParent;
    public bool isShifting;
    public bool timePeriod;
    // Start is called before the first frame update
    void Start()
    {
        isShifting = false;
    }

    // Update is called once per frame
    void Update() //checks if F is pressed, sets isShifting to true
    {
       if(Input.GetKeyDown(KeyCode.F))
       {
            Debug.Log("Beam me up!");
            isShifting = true;
       }

    }

    private void FixedUpdate()
    {
       if(isShifting == true) //Checks if is shifting is true
       {
            Debug.Log("Scottie!");
            if(timePeriod == false) //Toggles time period
            {
                timePeriod = true;
            }
            else if (timePeriod == true)
            {
                timePeriod = false;
            }

            switch(timePeriod) //Checks time period value
            {
              
                case true: //Synth Active, Jurassic Inactive
                    JurassicParent.SetActive(false);
                    SynthwaveParent.SetActive(true);
                    break;

                case false: //Synth Inactive, Jurassic Active
                    JurassicParent.SetActive(true);
                    SynthwaveParent.SetActive(false);
                    break;

            }

            isShifting = false;
       }
    }
}
