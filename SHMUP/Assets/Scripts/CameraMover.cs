using System;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Range(0, 1)] public float smoothTime = 0.2f;
    public Transform target;

    private Vector2 _velocity;

    private Transform _transform;

    [NonSerialized] public Vector2 Offset;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _transform.position = Vector2.SmoothDamp(
            transform.position, 
            (Vector2)target.position + Offset, 
            ref _velocity, 
            smoothTime);
    }
}
