using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    Camera mainCamera;
    BoxCollider2D boxCollider;
    SpriteRenderer sr;
    Color triggerColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    private void Awake()
    {
        mainCamera = Camera.main;
        sr = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            sr.color = triggerColor;
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ChangeCameraPos();
        }
    }

    void ChangeCameraPos()
    {
        //get the index of the gridCell the player moves into, set camera position to the new gridCell position
        Debug.Log("Camera Position will change");
    }
}
