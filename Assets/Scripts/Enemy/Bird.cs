using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour/*, IObserverBoost*/
{
    [SerializeField] ForceMode2D _impulseMode;
    [Range(100, 1000)]
    [SerializeField] private int _force;
    //[SerializeField] private float _impulseTime;
    //[SerializeField] private float _impulseCooldown;
    //public bool _impulseEnabled;

    //private TrailRenderer _trailRenderer;
    //private Rigidbody2D _rb;
    //private Transform _transform;

    //public void Boost(Rigidbody2D rb2d, Transform transform, TrailRenderer trailRenderer)
    //{
    //    _rb = rb2d;
    //    _transform = transform;
    //    _trailRenderer = trailRenderer;

    //    if (_impulseEnabled)
    //    {
    //        StartCoroutine(Boost());
    //        Debug.Log("Impulso Pajaro");
    //    }
    //}

    //private IEnumerator Boost()
    //{
    //    _impulseEnabled = false;
    //    float originalGravity = _rb.gravityScale;
    //    _rb.gravityScale = 0f;
    //    _rb.velocity = new Vector2(0f, _transform.localScale.y * _force);
    //    _trailRenderer.emitting = true;
    //    yield return new WaitForSeconds(_impulseTime);
    //    _trailRenderer.emitting = false;
    //    _rb.gravityScale = originalGravity;
    //    yield return new WaitForSeconds(_impulseCooldown);
    //    _impulseEnabled = true;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            var rb2d = collision.GetComponent<Rigidbody2D>();
            var tr = collision.GetComponent <Transform>();

            rb2d.velocity = new Vector2(0f, tr.localScale.y * _force);

        }
    }
}
