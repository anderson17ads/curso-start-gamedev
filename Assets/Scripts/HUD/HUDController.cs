using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField]
    private Image waterUIBar;
    
    [SerializeField]
    private Image woodUIBar;

    [SerializeField]
    private Image carrotUIBar;

    [SerializeField]
    private Image fishUIBar;

    [Header("Tools")]
    [SerializeField]
    private List<Image> toolsUI;

    [SerializeField]
    private Color selectedColor;

    [SerializeField]
    private Color alphaColor;

    private Player player;
    
    void Start()
    {
        player = FindObjectOfType<Player>();

        reset();
    }

    void Update()
    {
        items();
        tools();
    }

    private void reset()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
    }

    private void items()
    {
        waterUIBar.fillAmount = (float) PlayerInventory.instance.water / PlayerInventory.instance.waterLimit;
        woodUIBar.fillAmount = (float) PlayerInventory.instance.wood / PlayerInventory.instance.woodLimit;
        carrotUIBar.fillAmount = (float) PlayerInventory.instance.carrot / PlayerInventory.instance.carrotLimit;
        fishUIBar.fillAmount = (float) PlayerInventory.instance.fish / PlayerInventory.instance.fishLimit;
    }

    private void tools()
    {
        for (int i = 0; i < toolsUI.Count; i++) {
            toolsUI[i].color = (player.handlingObj == i) ? selectedColor : alphaColor;
        }
    }
}
