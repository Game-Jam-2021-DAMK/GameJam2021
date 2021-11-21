using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager control;

    public enum State
    {
        inMenu,
        inGamePlay,
        inPause,
    }

    public State gameState;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        SwitchState(State.inMenu);
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case State.inMenu:
                Debug.Log("State: " + gameState);
                break;

            case State.inGamePlay:
                Debug.Log("State: " + gameState);
                break;

            case State.inPause:
                Debug.Log("State: " + gameState);
                break;
        }
    }

    public void SwitchState(State newState)
    {
        gameState = newState;
    }
}
