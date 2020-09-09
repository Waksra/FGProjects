using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0, 5)] public float maxOffset = 2;
    [Range(0, 1)] public float maxOffsetDistance = 0.3f;
    public Texture2D cursor;

    private Camera _camera;
    private CameraMover _mover;

    private Vector2 _cursorScreenPosition;
    private Vector2 _cursorViewportPosition;

    public Vector2 CursorScreenPosition
    {
        set
        {
            _cursorScreenPosition = value;
            _cursorViewportPosition = _camera.ScreenToViewportPoint(value);
        }
        get => _cursorScreenPosition;
    }

private void Awake()
    {
        _camera = GetComponent<Camera>();
        _mover = GetComponentInParent<CameraMover>();
        
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.SetCursor(
            cursor, 
            new Vector2(Mathf.RoundToInt(cursor.width / 2f), Mathf.RoundToInt(cursor.height / 2f)), 
            CursorMode.Auto);
    }

    private void Update()
    {
        Vector2 center = _camera.rect.center;

        SetCameraOffsetByDistance(
            _cursorViewportPosition - center, 
            Vector2.Distance(center, _cursorViewportPosition));
    }

    public Vector2 ScreenToWorldSpace(Vector2 position)
    {
        return _camera.ScreenToWorldPoint(position);
    }

    private void SetCameraOffsetByDistance(Vector2 direction, float distance)
    {
        direction.Normalize();
        _mover.Offset = Vector2.Lerp(Vector2.zero, direction * maxOffset, distance / maxOffsetDistance);
    }
}
