using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody2D sphereRigibody;

    public void Awake()
    {
        sphereRigibody = GetComponent<Rigidbody2D>();
    }
    public void Jump(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
            Debug.Log("Player Jumps!");
            sphereRigibody.AddForce(Vector3.up * 2f, ForceMode2D.Impulse);
        }
    }
}
