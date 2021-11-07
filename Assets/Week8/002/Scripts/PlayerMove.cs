using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float moveX;
    [SerializeField] float moveY;

    MyPathSystem mps;
    int cellSize = 22;
    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void PlayerControls()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DoorLeft")
        {
            //get the index of the gridCell the player moves into, set camera position to the new gridCell position
            Debug.Log("Camera Position will change");
            Debug.Log(gameObject.GetInstanceID().ToString());

            mainCamera.transform.position = new Vector3(collision.gameObject.transform.position.x + cellSize / 2, collision.gameObject.transform.position.y, -10);
        }

        else if(collision.gameObject.tag == "DoorRight")
        {
            mainCamera.transform.position = new Vector3(collision.gameObject.transform.position.x - cellSize / 2, collision.gameObject.transform.position.y, -10);
        }

        else if(collision.gameObject.tag == "DoorTop")
        {
            mainCamera.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y - cellSize / 2, -10);
        }

        else if(collision.gameObject.tag == "DoorBottom")
        {
            mainCamera.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + cellSize / 2, -10);
        }
    }
}
