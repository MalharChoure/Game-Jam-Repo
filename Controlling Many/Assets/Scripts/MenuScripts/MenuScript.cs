using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ToFirstLevel()
    {
        LevelManager.Instance.ReplayLevel();
    }

    public void ToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
