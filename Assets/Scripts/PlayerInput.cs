using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string JumpButtonName = "Jump";
    private const string AttackButtonName = "Attack";

    public event Action JumpPressed;
    public event Action AttackPressed;

    private void Update()
    {
        if (Input.GetButtonDown(JumpButtonName))
        {
            JumpPressed?.Invoke();
        }

        if (Input.GetButtonDown(AttackButtonName))
        {
            AttackPressed?.Invoke();
        }
    }
}