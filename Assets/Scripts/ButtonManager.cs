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
        GameManager.control.SwitchState(GameManager.State.inGamePlay);
        SceneManager.LoadScene(sceneName: "Scene 1"); //Chamge this to our main scene
        Debug.Log("Loaded Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
