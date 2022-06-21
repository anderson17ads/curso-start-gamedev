using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;

    private float initialSpeed;

    private int index;

    public List<Transform> paths = new List<Transform>();

    private void Start() {
        initialSpeed = speed;   
    }

    void Update()
    {
        onMove();
    }

    private void onMove()
    {
        speed = (DialogueControl.instance.isShowing) ? 0f : initialSpeed;

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, paths[index].position) < 0.1f) {
            if (index < paths.Count) {
                index = Random.Range(0, paths.Count);
                return;
            }

            index = 0;
        }

        transform.eulerAngles = (paths[index].position - transform.position).x < 0
            ? new Vector2(0, 180)
            : new Vector2(0, 0);
    }
}
