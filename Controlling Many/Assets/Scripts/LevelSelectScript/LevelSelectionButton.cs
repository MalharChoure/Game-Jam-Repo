using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelectionButton : MonoBehaviour
{
    private Button button;
    [SerializeField]
    private int _level;
    private string _levelName;

    private void Awake()
    {
        _levelName = levels.level[_level];
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    public void onClick()
    {
        levelStatus LevelS = LevelManager.Instance.getLevelStatus(_levelName);
        Debug.Log(LevelS);
        switch (LevelS)
        {
            case levelStatus.Locked:
                Debug.Log("Cannot play the level until you unlock it");
                break;

            case levelStatus.Unlocked:
                SceneManager.LoadScene(_levelName);
                break;

            case levelStatus.Completed:
                SceneManager.LoadScene(_levelName);
                break;
        }
    }
}
