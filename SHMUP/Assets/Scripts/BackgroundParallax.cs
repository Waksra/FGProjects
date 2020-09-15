using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class BackgroundParallax : MonoBehaviour
{
    [Range(0, 20)]
    public float parallaxAmount = 5;

    private Transform _transform;
    private MeshRenderer _meshRenderer;

    private int test;

    private void Awake()
    {
        _transform = transform;
        _meshRenderer = GetComponent<MeshRenderer>();
        test = Shader.PropertyToID("_MainOffset");
    }

    private void LateUpdate()
    {
        Vector2 position = _transform.position;
        Vector2 localScale = _transform.localScale;
        Vector2 textureOffset;

        textureOffset.x = position.x / localScale.x * parallaxAmount;
        textureOffset.y = position.y / localScale.y * parallaxAmount;

        _meshRenderer.material.SetVector(test, textureOffset);
    }
}