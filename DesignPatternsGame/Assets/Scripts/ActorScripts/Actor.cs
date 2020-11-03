using UnityEngine;
using WorldScripts;

namespace ActorScripts
{
	[RequireComponent(typeof(Collider))]
	public class Actor : MonoBehaviour
	{
		private Collider _collider;
		private MovementController _movementController;

		private World _world;
		private Tile _currentTile;

		private bool _hasMovementController;

		public float Height => _collider.bounds.size.y;

		public Tile CurrentTile
		{
			get => _currentTile;
			set => _currentTile = value;
		}

		public void Initialize(World world, Tile currentTile)
		{
			_world = world;
			_currentTile = currentTile;
			_collider = GetComponent<Collider>();

			_hasMovementController = TryGetComponent(out _movementController);
			if (_hasMovementController)
				_movementController.Initialize(world, this);
		}

		public void MoveInDirection(Vector2Int direction)
		{
			if(!_hasMovementController)
				return;
			_movementController.MoveDirection(direction);
		}
	}
}
