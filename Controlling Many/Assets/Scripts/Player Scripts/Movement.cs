using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //variable to store the rigid body of the current component
    [SerializeField]
    private Rigidbody _selfRigidBody;

    //boolean to check whether the object is grounded
    private bool _isGrounded=true;

    //vector to store the direction of motion
    private Vector3 _movement=Vector3.zero;

    //Bools to check whether we can move in a direction or not
    private bool _leftClear = true;
    private bool _rightClear = true;
    private bool _forwardClear = true;
    private bool _backClear = true;


    // Update is called once per frame
    void Update()
    {
        _moveInput();
    }

    private void FixedUpdate()
    {
        if (_movement != Vector3.zero && _isGrounded)
        {
            _movePosition();
        }
        _checkGrounded();
        _checkSides();
    }

    //The _moveInput function is to get the input of the player. This is not directly called in fixed update as i dont want any input to be lost.
    private void _moveInput()
    {
        if(Input.GetKeyDown(KeyCode.W) && _forwardClear)
        {
            _movement = Vector3.forward;
        }
        if(Input.GetKeyDown(KeyCode.S) && _backClear)
        {
            _movement = Vector3.back;
        }
        if(Input.GetKeyDown(KeyCode.A) && _leftClear)
        {
            _movement = Vector3.left;
        }
        if(Input.GetKeyDown(KeyCode.D) && _rightClear)
        {
            _movement = Vector3.right;
        }
    }
    // The _movePosition function is used to move the player by the inputted distance.
    private void _movePosition()
    {
        _selfRigidBody.MovePosition(_movement + gameObject.transform.position);
        _movement= Vector3.zero;
    }

    //This function uses raycast to check whether the raycast can detect ground or not.
    private void _checkGrounded()
    {
        //RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,3.0f))
        {
            _isGrounded = true;
        }
        else
        {
            Debug.Log(_isGrounded);
            _isGrounded = false;
        }
    }

    //This function is used to check whether the sides of the cube are clear for motion.
    private void _checkSides()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, 1.0f))
        {
            _forwardClear = false;
        }
        else
        {
            _forwardClear= true;
        }
        if (Physics.Raycast(transform.position, Vector3.back, 1.0f))
        {
            _backClear = false;
        }
        else
        {
            _backClear = true;
        }
        if (Physics.Raycast(transform.position, Vector3.left, 1.0f))
        {
            _leftClear = false;
        }
        else
        {
            _leftClear = true;
        }
        if (Physics.Raycast(transform.position, Vector3.right, 1.0f))
        {
            _rightClear = false;
        }
        else
        {
            _rightClear = true;
        }
    }
}
