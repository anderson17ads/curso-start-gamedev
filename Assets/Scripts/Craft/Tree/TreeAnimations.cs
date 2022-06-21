using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimations : MonoBehaviour
{
    private Tree tree;

    private Animator treeAnimations;

    private void Start() {
        tree = GetComponent<Tree>();
        treeAnimations = GetComponent<Animator>();
    }

    private void Update() {
        onHit();
        onCut();
    }

    private void onHit()
    {
        if (tree.isHit) {
            treeAnimations.SetTrigger("isCutting");
            tree.isHit = false;
        }
    }

    private void onCut()
    {
        if (tree.isCut) {
            treeAnimations.SetTrigger("isCut");
        }
    }
}
