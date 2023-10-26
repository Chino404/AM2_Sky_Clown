using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour, IObserverImpulse
{
    [SerializeField] ForceMode2D _impulseMode;
    [Range(0,30)]
    [SerializeField] int _force;

    public void Action(Rigidbody2D rb2d)
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            var rb2d = collision.GetComponent<Rigidbody2D>();

            rb2d.AddForce(Vector2.up * _force, _impulseMode);

        }
    }
}
