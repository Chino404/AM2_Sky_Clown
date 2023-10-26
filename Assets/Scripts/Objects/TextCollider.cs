using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCollider : MonoBehaviour
{
    public GameObject on;
    public GameObject off;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            if(on != null)  on.SetActive(true);
            if(off != null) off.SetActive(false);
        }
    }
}
