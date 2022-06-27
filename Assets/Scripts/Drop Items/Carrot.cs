using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [Header("Audio")]
    private AudioSource audioSource;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private AudioClip dropSFX;

    private bool isCollision;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        onDrop();
    }

    private void onDrop()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollision) {
            if (PlayerInventory.instance.carrot < PlayerInventory.instance.carrotLimit) {
                PlayerInventory.instance.carrot++;
                
                audioSource.PlayOneShot(dropSFX);

                spriteRenderer.enabled = false;
                
                Destroy(gameObject, dropSFX.length);
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
