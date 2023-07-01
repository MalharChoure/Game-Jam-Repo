using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;
    private int _movementScore=0;
    private bool _movementInput = false;
    private void Start()
    {
        _text.text = "Movement: 0";
    }

    private void Update()
    {
        _moveInput();
    }

    private void FixedUpdate()
    {
        if (_movementInput)
        {
            _movementInput = false;
            UpdateMovement();
        }
    }

    private void _moveInput()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))&& !_movementInput)
        {
            _movementInput = true;
        }
    }
    public void UpdateMovement()
    {
        _movementScore += 1;
        _text.text = "Movement: " + _movementScore;
    }

    public int GetMaxMovement()
    {
        return _movementScore;
    }
}
