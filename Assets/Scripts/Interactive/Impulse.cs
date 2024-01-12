using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Impulse : MonoBehaviour, IObserverBoost
{
    [SerializeField] ForceMode2D _impulseMode = ForceMode2D.Impulse;
    [SerializeField] Renderer _renderer;
    [Range(100, 1000)]
    [SerializeField] private int _force;
    [SerializeField] private float _boostTime;
    [SerializeField] private float _boostCooldown;
    public bool _impulseEnabled;

    private TrailRenderer _trailRenderer;
    private Rigidbody2D _rb;
    private Transform _transform;

    private void Start()
    {
        _impulseEnabled = true;
        _renderer = GetComponent<Renderer>();
    }

    public void Boost(Rigidbody2D rb2d, Transform transform, TrailRenderer trailRenderer)
    {
        _rb = rb2d;
        _transform = transform;
        _trailRenderer = trailRenderer;

        if (_impulseEnabled)
        {
            StartCoroutine(Boost());
            Debug.Log("Impulso");
        }
    }

    private IEnumerator Boost()
    {
        _impulseEnabled = false;
        //float originalGravity = _rb.gravityScale;
        //_rb.gravityScale = 0f;
        _rb.velocity = new Vector2(0f, _transform.localScale.y * _force);
        _trailRenderer.emitting = true;
        yield return new WaitForSeconds(_boostTime);
        _trailRenderer.emitting = false;
        //_rb.gravityScale = originalGravity;
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(_boostCooldown);
        _impulseEnabled = true;
        _renderer.material.color = Color.yellow;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IObservableImpulse>() != null)
            collision.gameObject.GetComponent<IObservableImpulse>().Subscribe(this);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IObservableImpulse>() != null)
            collision.gameObject.GetComponent<IObservableImpulse>().Unsubscribe(this);

    }

}
