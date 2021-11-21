using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    public Transform spawnPoint;
    public float timerMax = 4f;
    public System.Random rd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        StartTimer();
    }

    //creates a new car at the set spawnpoint
    void SpawnCar()
    {

        GameObject newCar = Instantiate(car);
        newCar.transform.position = spawnPoint.transform.position;

    }

    //timer to determine when cars are created
    void StartTimer()
    {
        timerMax -= Time.deltaTime;

        if (timerMax <= 0.0f)
        {
            TimerEnded();
        }
    }

    //calls for a new car to be made and resets timer
    void TimerEnded()
    {
        SpawnCar();
        timerMax = rd.Next(4, 10);
    }
}
