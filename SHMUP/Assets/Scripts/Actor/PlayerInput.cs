using System;
using UnityEngine;
using Input;
using UnityEngine.InputSystem;

namespace Actor
{
    public class PlayerInput : MonoBehaviour
    {
        private GameControls _controls;
        private MovementController _movementController;
        private RotationController _rotationController;

        private void Awake()
        {
            _controls = new GameControls();
            _movementController = GetComponent<MovementController>();
            _rotationController = GetComponent<RotationController>();
        }

        private void OnEnable()
        {
            _controls.Play.Move.performed += OnMovePerformed;
            _controls.Play.Move.canceled += OnMoveCanceled;
            _controls.Play.Rotate.performed += OnRotatePerformed;
            _controls.Play.Rotate.canceled += OnRotateCanceled;
            _controls.Play.Brake.performed += OnBrakePerformed;
            _controls.Play.Brake.canceled += OnBrakeCanceled;
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Play.Move.performed -= OnMovePerformed;
            _controls.Play.Move.canceled -= OnMoveCanceled;
            _controls.Play.Rotate.performed -= OnRotatePerformed;
            _controls.Play.Rotate.canceled -= OnRotateCanceled;
            _controls.Play.Brake.performed -= OnBrakePerformed;
            _controls.Play.Brake.canceled -= OnBrakeCanceled;
            _controls.Disable();
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            _movementController.MoveVector = new Vector2(0, context.ReadValue<float>());
        }

        private void OnMoveCanceled(InputAction.CallbackContext context)
        {
            _movementController.MoveVector = Vector2.zero;
        }

        private void OnRotatePerformed(InputAction.CallbackContext context)
        {
            _rotationController.RotateAmount = context.ReadValue<float>();
        }

        private void OnRotateCanceled(InputAction.CallbackContext context)
        {
            _rotationController.RotateAmount = 0;
        }
        private void OnBrakePerformed(InputAction.CallbackContext context)
        {
            _movementController.IsBrake = true;
        }
        
        private void OnBrakeCanceled(InputAction.CallbackContext context)
        {
            _movementController.IsBrake = false;
        }
    }
}
