using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private SpriteRenderer houseSprite;

    [SerializeField]
    private Color startColor;

    [SerializeField]
    private Color endColor;

    [SerializeField]
    private Transform playerPoint;

    [SerializeField]
    private GameObject houseCollider;

    private Player player;

    [Header("Settings")]
    [SerializeField]
    private float timeAmount;

    private float timeCount;

    private bool isBegining;
    
    private bool isCollision;

    [SerializeField]
    private int woodAmount;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        onBuild();
    }

    private void onBuild()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollision && !isBegining && isWood()) {
            isBegining = true;
            houseSprite.color = startColor;
            
            player.isHammering = true;
            player.transform.position = playerPoint.position;
            
            PlayerInventory.instance.wood -= woodAmount;
        }

        if (isBegining) {
            timeCount += Time.deltaTime;

            if (timeCount >= timeAmount) {
                player.isHammering = false;
                houseSprite.color = endColor;
                houseCollider.SetActive(true);
            }
        }
    }

    private bool isWood()
    {
        return PlayerInventory.instance.wood >= woodAmount;
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
