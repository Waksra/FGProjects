using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float initialVelocity;
    public float lifetime;

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
}