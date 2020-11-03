using UnityEngine;
using UnityEngine.InputSystem;
using ActorScripts;

namespace UserScripts
{
	[RequireComponent(typeof(Camera))]
	public class Input : MonoBehaviour
	{
		private GameControls _controls;
		private Camera _camera;
		private ActorCommander _actorCommander;
		private Actor _selectedActor;

		private Vector2 _mousePosition;

		private void Awake()
		{
			_controls = new GameControls();
			_camera = GetComponent<Camera>();
			_actorCommander = GetComponent<ActorCommander>();
		}

		private void OnEnable()
		{
			_controls.Default.MousePosition.performed += OnMouseMove;
			_controls.Default.MouseLeft.performed += OnMouseLeft;
			_controls.Default.Up.performed += OnUp;
			_controls.Default.Down.performed += OnDown;
			_controls.Default.Left.performed += OnLeft;
			_controls.Default.Right.performed += OnRight;
			_controls.Enable();
		}

		private void OnDisable()
		{
			_controls.Disable();
			_controls.Default.MousePosition.performed -= OnMouseMove;
			_controls.Default.MouseLeft.performed -= OnMouseLeft;
			_controls.Default.Up.performed -= OnUp;
			_controls.Default.Down.performed -= OnDown;
			_controls.Default.Left.performed -= OnLeft;
			_controls.Default.Right.performed -= OnRight;
		}

		private void OnMouseMove(InputAction.CallbackContext context)
		{
			_mousePosition = context.ReadValue<Vector2>();
		}

		private void OnMouseLeft(InputAction.CallbackContext context)
		{
			if (Physics.Raycast(_camera.ScreenPointToRay(_mousePosition), out RaycastHit hitInfo)
			    && hitInfo.collider.TryGetComponent(out _selectedActor))
				return;

			_selectedActor = null;
		}

		private void OnUp(InputAction.CallbackContext context)
		{
			_selectedActor?.MoveInDirection(Vector2Int.up);
		}
		
		private void OnDown(InputAction.CallbackContext context)
		{
			_selectedActor?.MoveInDirection(Vector2Int.down);
		}
		
		private void OnLeft(InputAction.CallbackContext context)
		{
			_selectedActor?.MoveInDirection(Vector2Int.left);
		}
		
		private void OnRight(InputAction.CallbackContext context)
		{
			_selectedActor?.MoveInDirection(Vector2Int.right);
		}

		private void OnDrawGizmos()
		{
			if(_selectedActor != null)
				Gizmos.DrawWireSphere(_selectedActor.transform.position, 1);
		}
	}
}
