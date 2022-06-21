using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingFarm : MonoBehaviour
{
    private bool isCollision;

    [SerializeField]
    private int percentege;

    private Player player;

    [SerializeField]
    private GameObject fishPrefab;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    
    void Update()
    {
        onCasting();
    }

    private void onCasting()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollision) {
            if (player.isCasting) {
                return;
            }

            player.isCasting = true;
        }
    }

    public void addFish()
    {
        int percentegeRandom = Random.Range(1, 100);

        if (percentegeRandom <= percentege) {
            Instantiate(
                fishPrefab, 
                player.transform.position + new Vector3(Random.Range(-2f, -2f), Random.Range(2f, 0f), 0f), 
                player.transform.rotation
            );
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
