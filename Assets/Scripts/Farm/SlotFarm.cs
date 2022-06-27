using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Audio")]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip holeSFX;

    [SerializeField]
    private AudioClip carrotSFX;

    [Header("Components")]
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite hole;

    [SerializeField]
    private GameObject carrotPrefab;

    [Header("Settings")]

    [SerializeField]
    private int digAmount;

    private int initialDigAmount;

    private bool isRole;

    private bool isWater;

    private bool isCarrot;

    [SerializeField]
    private int waterAmount;

    private int initialWaterAmount;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        initialDigAmount = digAmount;
        initialWaterAmount = waterAmount;
    }

    private void onRole()
    {
        if (isRole) {
            return;
        }

        digAmount--;

        if (digAmount <= 0) {
            spriteRenderer.sprite = hole;
            digAmount = initialDigAmount;
            isRole = true;

            audioSource.PlayOneShot(holeSFX);
        }
    }

    private void onCarrot()
    {
        if (!isRole || isCarrot) {
            return;
        }

        waterAmount--;

        if (waterAmount <= 0) {
            spriteRenderer.sprite = null;
            waterAmount = initialWaterAmount;
            isCarrot = true;

            audioSource.PlayOneShot(carrotSFX);

            Instantiate(carrotPrefab, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Dig")) {
            onRole();
        }

        if (collision.CompareTag("Water")) {
            onCarrot();
        }
    }
}
