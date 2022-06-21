using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Wood")]
    [SerializeField]
    private int _wood;

    [SerializeField]
    private int _woodLimit;

    [SerializeField]
    private int _woodAdd;

    [Header("Water")]
    [SerializeField]
    private int _water;

    [SerializeField]
    private int _waterLimit;

    [SerializeField]
    private int _waterAdd;

    [Header("Carrot")]
    [SerializeField]
    private int _carrot;

    [SerializeField]
    private int _carrotLimit;

    [Header("Fish")]
    [SerializeField]
    private int _fish;

    [SerializeField]
    private int _fishLimit;
    
    // Wood
    public int wood
    {
        get { return _wood; }
        set { _wood = value; }
    }

    public int woodLimit
    {
        get { return _woodLimit; }
        set { _woodLimit = value; }
    }

    public int woodAdd
    {
        get { return _woodAdd; }
        set { _woodAdd = value; }
    }

    // Water
    public int water
    {
        get { return _water; }
        set { _water = value; }
    }

    public int waterLimit
    {
        get { return _waterLimit; }
        set { _waterLimit = value; }
    }

    public int waterAdd
    {
        get { return _waterAdd; }
        set { _waterAdd = value; }
    }

    // Carrot
    public int carrot
    {
        get { return _carrot; }
        set { _carrot = value; }
    }

    public int carrotLimit
    {
        get { return _carrotLimit; }
        set { _carrotLimit = value; }
    }

    // Fish
    public int fish
    {
        get { return _fish; }
        set { _fish = value; }
    }

    public int fishLimit
    {
        get { return _fishLimit; }
        set { _fishLimit = value; }
    }

    public static PlayerInventory instance;

    private void Awake() {
        instance = this;
    }
}
