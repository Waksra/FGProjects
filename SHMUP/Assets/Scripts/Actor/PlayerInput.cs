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
        private CameraController _cameraController;
        private PlayerAbilityManager _abilityManager;

        private void Awake()
        {
            _controls = new GameControls();
            _movementController = GetComponent<MovementController>();
            _rotationController = GetComponent<RotationController>();
            _cameraController = Camera.main.GetComponent<CameraController>();
            _abilityManager = GetComponent<PlayerAbilityManager>();
        }

        private void OnEnable()
        {
            _controls.Play.Move.performed += OnMovePerformed;

            _controls.Play.Rotate.performed += OnRotatePerformed;

            _controls.Play.Brake.performed += OnBrakePerformed;
            _controls.Play.Brake.canceled += OnBrakeCanceled;

            _controls.Play.Aim.performed += OnAimPerformed;

            _controls.Play.Fire.performed += OnFirePerformed;
            _controls.Play.Fire.canceled += OnFireCanceled;

            _controls.Play.SwapWeapon.performed += OnSwapWeaponPerformed;

            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Play.Move.performed -= OnMovePerformed;

            _controls.Play.Rotate.performed -= OnRotatePerformed;

            _controls.Play.Brake.performed -= OnBrakePerformed;
            _controls.Play.Brake.canceled -= OnBrakeCanceled;

            _controls.Play.Aim.performed -= OnAimPerformed;

            _controls.Play.Fire.performed -= OnFirePerformed;
            _controls.Play.Fire.canceled -= OnFireCanceled;

            _controls.Play.SwapWeapon.performed -= OnSwapWeaponPerformed;

            _controls.Disable();
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            _movementController.MoveVector = new Vector2(0, context.ReadValue<float>());
        }

        private void OnRotatePerformed(InputAction.CallbackContext context)
        {
            _rotationController.RotateAmount = context.ReadValue<float>();
        }

        private void OnBrakePerformed(InputAction.CallbackContext context)
        {
            _movementController.IsBrake = true;
        }

        private void OnBrakeCanceled(InputAction.CallbackContext context)
        {
            _movementController.IsBrake = false;
        }

        private void OnAimPerformed(InputAction.CallbackContext context)
        {
            _cameraController.CursorScreenPosition = context.ReadValue<Vector2>();
        }

        private void OnFirePerformed(InputAction.CallbackContext context)
        {
            _abilityManager.StartFireWeapon();
        }

        private void OnFireCanceled(InputAction.CallbackContext context)
        {
            _abilityManager.StopFireWeapon();
        }

        private void OnSwapWeaponPerformed(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValue<float>());
            if(context.ReadValue<float>() > 0)
                _abilityManager.NextWeapon();
            else
                _abilityManager.PreviousWeapon();
            
        }
    }
}
