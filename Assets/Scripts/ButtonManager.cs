using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.control.gameState == GameManager.State.inMenu)
        {

        }
    }

    public void LaunchGame()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
