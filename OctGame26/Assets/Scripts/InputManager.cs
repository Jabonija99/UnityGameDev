using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMovement movement;
    private PlayerThrow playerThrow;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        movement = GetComponent<PlayerMovement>();
        playerThrow = GetComponent<PlayerThrow>();
        onFoot.Jump.performed += ctx => movement.ProcessJump();
        onFoot.Throw.performed += ctx => playerThrow.ProcessThrow();
        onFoot.Aim.started += ctx => playerThrow.StartAim();
        onFoot.Aim.canceled += ctx => playerThrow.StopAim();

    }

    private void FixedUpdate()
    {
        movement.ProcessMovement(onFoot.Move.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
