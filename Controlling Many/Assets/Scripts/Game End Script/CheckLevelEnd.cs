using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckLevelEnd : MonoBehaviour
{
    //handles for the player dice
    [SerializeField]
    private GameObject _playerDice1;
    [SerializeField]
    private GameObject _playerDice2;
    [SerializeField]
    private GameObject _playerDice3;
    [SerializeField]
    private GameObject _playerDice4;

    [SerializeField]
    private GameObject _canvas;
    private movement _script;

    //handles for the scripts
    private Movement _playerMove1;
    private Movement _playerMove2;
    private Movement _playerMove3;
    private Movement _playerMove4;

    private void Start()
    {
        _playerMove1=_playerDice1.GetComponent<Movement>();
        _playerMove2=_playerDice2.GetComponent<Movement>();
        _playerMove3=_playerDice3.GetComponent<Movement>();
        _playerMove4=_playerDice4.GetComponent<Movement>();
        _script = _canvas.GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerMove1.GetLockedMovement() && _playerMove2.GetLockedMovement() && _playerMove3.GetLockedMovement() && _playerMove4.GetLockedMovement())
        {
            //LevelManager.Instance.setLevelStatus(PlayerPrefs.GetString("level", "level1"), levelStatus.Completed);
            int maxMove=_script.GetMaxMovement();
            string levelCurrent = ""+PlayerPrefs.GetInt("level");
            PlayerPrefs.SetInt(levelCurrent, maxMove);
            SceneManager.LoadScene("EndScene");
        }
    }
}
