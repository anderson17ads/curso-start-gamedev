using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    private bool isCollision;
    
    void Update()
    {
        onDrop();
    }

    private void onDrop()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollision) {
            if (PlayerInventory.instance.carrot < PlayerInventory.instance.carrotLimit) {
                PlayerInventory.instance.carrot++;
                Destroy(gameObject);
            }
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
