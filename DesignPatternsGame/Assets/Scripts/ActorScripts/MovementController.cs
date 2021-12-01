using System;
using UnityEngine;
using WorldScripts;

namespace ActorScripts
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float allowedHeightDifference = 0.25f;

        private Actor _parent;
        private Transform _transform;
        
        private Func<int, int, Tile> _getTileAt;
        
        public void Initialize(World world, Actor parent)
        {
            _parent = parent;
            _transform = transform;
            _getTileAt = world.GetTileAt;
        }
        
        public void MoveDirection(Vector2Int direction)
        {
            Vector3 currentPosition = _transform.position;
            Tile tile = _getTileAt.Invoke((int)currentPosition.x + direction.x, (int)currentPosition.z + direction.y);
            
            if(tile == null || tile.SurfaceHeight - _parent.CurrentTile.SurfaceHeight > allowedHeightDifference)
                return;

            Vector3 tilePosition = tile.transform.position;
            _transform.position = new Vector3(tilePosition.x, tile.SurfaceHeight + 1, tilePosition.z);
            _parent.CurrentTile = tile;
        }
    }
}