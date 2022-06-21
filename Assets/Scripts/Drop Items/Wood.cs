using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float timeMove;

    private float timeCount;

    private bool isCollision;
    
    void Update()
    {
        onCreate();
        onDrop();
    }

    private void onCreate()
    {
        timeCount += Time.deltaTime;

        if (timeCount < timeMove) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void onDrop()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollision) {
            PlayerInventory.instance.wood++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) {
            isCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) {
            isCollision = false;
        }
    }
}
