using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private int health;

    private bool _isHit;

    private bool _isCut;

    [SerializeField]
    private int totalWood;

    [SerializeField]
    private GameObject woodPrefab;

    [SerializeField]
    private ParticleSystem leafs;

    public bool isCut
    {
        get { return _isCut; }
        set { _isCut = value; }
    }

    public bool isHit
    {
        get { return _isHit; }
        set { _isHit = value; }
    }

    public void onHit()
    {
        health--;

        _isHit = true;

        leafs.Play();

        if (health <= 0) {
            _isCut = true;

            addWood();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Axe") && !_isCut) {
            onHit();
        }
    }

    private void addWood()
    {
        for (int i = 0; i < totalWood; i++) {
            Instantiate(
                woodPrefab, 
                transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), 
                transform.rotation
            );
        }
    }
}
