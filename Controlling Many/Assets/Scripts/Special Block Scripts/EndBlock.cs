using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Movement script = other.gameObject.GetComponent<Movement>();
        if(script)
        {
            script.SetLockedMovement(true);
        }
    }
}
