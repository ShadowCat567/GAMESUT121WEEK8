using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SpriteRenderer sr;
    Color triggerColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    protected Transform doorPosition;
   
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DoorLeft" || collision.gameObject.tag == "DoorRight" || collision.gameObject.tag == "DoorTop" || collision.gameObject.tag == "DoorBottom")
        {
            sr.color = triggerColor;
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
