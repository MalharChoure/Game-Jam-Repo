using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string level1;

    public void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(getLevelStatus("level1")==levelStatus.Locked)
        {
            setLevelStatus("level1", levelStatus.Unlocked);
        }
    }

    public levelStatus getLevelStatus(string level)
    {
        levelStatus LevelStatus = (levelStatus)PlayerPrefs.GetInt(level,0);
        return LevelStatus;
    }

    public void setLevelStatus(string level,levelStatus LevelStatus)
    {
        PlayerPrefs.SetInt(level, (int)LevelStatus);
    }

    public void ToNextLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("level", 0);
        setLevelStatus(levels.level[currentLevel], levelStatus.Completed);
        currentLevel = currentLevel + 1 > levels.level.Length ? currentLevel : currentLevel + 1;
        setLevelStatus(levels.level[currentLevel], levelStatus.Unlocked);
        SceneManager.LoadScene(levels.level[currentLevel]);
    }

    public void ReplayLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("level", 0);
        int levelToPlay = currentLevel;
        setLevelStatus(levels.level[currentLevel], levelStatus.Completed);
        currentLevel = currentLevel + 1 > levels.level.Length ? currentLevel : currentLevel + 1;
        setLevelStatus(levels.level[currentLevel], levelStatus.Unlocked);
        SceneManager.LoadScene(levels.level[levelToPlay]);
    }
}
