using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Impulse : MonoBehaviour, IObserverImpulse
{
    [SerializeField] ForceMode2D _impulseMode = ForceMode2D.Impulse;
    [SerializeField] Renderer _renderer;
    [Range(0,20)]
    [SerializeField] int _force;
    [Tooltip("Activacion")]
    [SerializeField] bool _active = true;
    [Range(0, 3), Tooltip("Temporizador de activasion")]
    [SerializeField] float _timmer = 2f;


    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Action (Rigidbody2D rb2d/*, Vector2 dir*/)
    {
        if (_active)
        {
            Debug.Log("Impulso");
            _force = Mathf.Clamp(_force,0,20);
            rb2d.AddForce(Vector2.up * _force, _impulseMode);
        }

        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {

        _active = false;
        _renderer.material.color = Color.red;

        yield return new WaitForSeconds(_timmer);

        _active = true;
        _renderer.material.color = Color.yellow;

        yield return null;
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
