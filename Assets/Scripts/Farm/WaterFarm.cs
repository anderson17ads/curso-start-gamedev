using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFarm : MonoBehaviour
{
    private bool isCollision;
    
    void Update()
    {
        onWater();
    }

    private void onWater()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollision) {
            if ((PlayerInventory.instance.water + PlayerInventory.instance.waterAdd) <= PlayerInventory.instance.waterLimit) {
                PlayerInventory.instance.water += PlayerInventory.instance.waterAdd;
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
