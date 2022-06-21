using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimations : MonoBehaviour
{
    private NPC npc;

    private Animator npcAnimations;
    
    void Start()
    {
        npc = GetComponent<NPC>();
        npcAnimations = GetComponent<Animator>();
    }

    void Update()
    {
        onMove();
    }

    private void onMove()
    {
        int transition = 0;

        if (!DialogueControl.instance.isShowing) {
            transition = 1;
        }

        npcAnimations.SetInteger("transition", transition);
    }
}
