using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SpriteRenderer sr;
    Color triggerColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    Color solidColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DoorCollider>())
        {
            collision.GetComponent<BoxCollider2D>().isTrigger = false;
            sr.color = solidColor;
        }
    }
}
