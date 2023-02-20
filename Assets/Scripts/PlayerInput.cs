using Unity.Mathematics;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : ComponentSystem
{
    private EntityQuery _inputQuery;
    private InputAction _moveAction;
    private InputAction _shootAction;
    private InputAction _jumpAction;

    private float2 _moveInput;
    private float _shootInput;
    private float _jumpInput;
    protected override void OnCreate()
    {
        _inputQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    protected override void OnStartRunning()
    {
        _moveAction = new InputAction("move", binding: "<Gamepad>/rightStick");
        _moveAction.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        _moveAction.performed += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.started += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.canceled += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.Enable();

        _shootAction = new InputAction("shoot", binding: "<Keyboard>/Space");
        _shootAction.performed += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.started += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.canceled += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.Enable();

        _jumpAction = new InputAction("jump", binding: "<Keyboard>/Tab");
        _jumpAction.performed += context => { _jumpInput = context.ReadValue<float>(); };
        _jumpAction.started += context => { _jumpInput = context.ReadValue<float>(); };
        _jumpAction.canceled += context => { _jumpInput = context.ReadValue<float>(); };
        _jumpAction.Enable();
    }

    protected override void OnStopRunning()
    {
        _moveAction.Disable();
        _shootAction.Disable();
        _jumpAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(_inputQuery).ForEach(
            (Entity entity, ref InputData inputData) =>
            {
                inputData.move = _moveInput;
                inputData.shoot = _shootInput;
                inputData.jump = _jumpInput;
            });
    }
}
