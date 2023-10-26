using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformCheckpoint : MonoBehaviour
{
    public Collider2D myCollider;
    public Transform checkPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            collision.GetComponent<Player>().lastCheckPoint = checkPoint.position;
            if(myCollider != null)
                myCollider.enabled = true;
        }
    }
}
