using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0, 5)] public float damageDealt = 1;
    public float initialVelocity = 10;
    public float lifetime = 2;

    private Transform _transform;
    private Rigidbody2D _body;

    private void Awake()
    {
        _transform = transform;
        _body = GetComponent<Rigidbody2D>();
    }

    public void Fire(Transform origin, Vector2 addedVelocity)
    {
        _transform.position = origin.position;
        _transform.rotation = origin.rotation;
        
        _body.velocity = addedVelocity + (Vector2)(_transform.up * initialVelocity);
        StartCoroutine(LifetimeCoroutine());
    }

    private IEnumerator LifetimeCoroutine()
    {
        yield return new WaitForSeconds(lifetime);
        
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damageable damageable;
        other.TryGetComponent(out damageable);
        
        damageable?.TakeDamage(damageDealt);
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
}