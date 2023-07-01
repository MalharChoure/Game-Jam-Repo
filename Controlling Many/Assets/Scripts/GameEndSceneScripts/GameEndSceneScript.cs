using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndSceneScript : MonoBehaviour
{
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToNextLevel()
    {
        //LevelManager.Instance.setLevelStatus(PlayerPrefs.GetString("level","level1"),levelStatus.Completed);
        LevelManager.Instance.ToNextLevel();
    }

    public void ReplayLevel()
    {
        LevelManager.Instance.ReplayLevel();
    }
}
