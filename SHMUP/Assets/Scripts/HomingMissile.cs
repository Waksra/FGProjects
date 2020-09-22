using System;
using Actor;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class HomingMissile : MonoBehaviour
{
    public float damageDealt;
    public float initialVelocity;

    private Transform _transform;
    private Rigidbody2D _body;
    private MovementController _movementController;
    
    private Transform _target;

    private void Awake()
    {
        _transform = transform;
        _body = GetComponent<Rigidbody2D>();
        _movementController = GetComponent<MovementController>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_target.position - _transform.position);
        direction.Normalize();
        
        _movementController.moveVector = direction;
        _transform.up = _body.velocity;
    }

    public void Fire(Transform origin, Transform target, Vector2 addedVelocity)
    {
        _transform.position = origin.position;
        _transform.rotation = origin.rotation;

        _target = target;

        _body.velocity = addedVelocity;
        
        _body.AddForce(_transform.up * initialVelocity, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Damageable damageable;
        other.collider.TryGetComponent(out damageable);
        
        damageable?.TakeDamage(damageDealt);
        gameObject.SetActive(false);
    }
}
