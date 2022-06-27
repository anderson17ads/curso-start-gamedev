using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float _speed;
    
    [SerializeField] 
    private float runSpeed;
    
    private Rigidbody2D rig;

    private float _initialSpeed;
    
    private int _handlingObj;

    private Dictionary<KeyCode, int> handleKeys;
    
    private Vector2 _direction;

    private bool _isRunning;

    private bool _isRolling;

    private bool _isCutting;

    private bool _isDiging;

    private bool _isWatering;

    private bool _isCasting;

    private bool _isHammering;

    private bool _isPause;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public float speed
    {
        get { return speed; }
        set { _speed = value; }
    }

    public float initialSpeed
    {
        get { return _initialSpeed; }
        set { _initialSpeed = value; }
    }

    public int handlingObj
    {
        get { return _handlingObj; }
        set { _handlingObj = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isDiging
    {
        get { return _isDiging; }
        set { _isDiging = value; }
    }

    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }

    public bool isCasting
    {
        get { return _isCasting; }
        set { _isCasting = value; }
    }

    public bool isHammering
    {
        get { return _isHammering; }
        set { _isHammering = value; }
    }

    public bool isPause
    {
        get { return _isPause; }
        set { _isPause = value; }
    }

    private void Start() {
        rig = GetComponent<Rigidbody2D>();

        _initialSpeed = _speed;
        
        onHandleKeys();
    }

    private void Update() {
        if (isPause) {
            return;
        }

        onInput();
        onRun();
        onRoll();
        onCutting();
        onDiging();
        onWatering();
    }

    private void FixedUpdate() {
        if (isPause) {
            return;
        }
        
        onMove();
    }

    #region Movement

    private void onInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void onMove()
    {
        rig.MovePosition(rig.position + _direction * _speed * Time.fixedDeltaTime);
    }

    private void onRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            _speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            _speed = _initialSpeed;
            _isRunning = false;
        }
    }

    private void onRoll()
    {
        if (Input.GetMouseButtonDown(1)) {
            _speed = runSpeed;
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1)) {
            _speed = _initialSpeed;
            _isRolling = false;
        }
    }

    private void onCutting()
    {
        if (Input.GetKeyDown(KeyCode.F) && _handlingObj == 0) {
            _speed = 0f;
            _isCutting = true;
        }
    }

    private void onDiging()
    {
        if (Input.GetKeyDown(KeyCode.F) && _handlingObj == 1) {
            _speed = 0f;
            _isDiging = true;
        }
    }

    private void onWatering()
    {
        if (Input.GetKeyDown(KeyCode.F) && _handlingObj == 2) {
            if (PlayerInventory.instance.water <= 0) {
                return;
            }
            
            _speed = 0f;
            _isWatering = true;

            PlayerInventory.instance.water--;
        }
    }

    private void OnGUI() {
        onHandlingObj();
    }

    private void onHandleKeys()
    {
        handleKeys = new Dictionary<KeyCode, int>();
        
        handleKeys.Add(KeyCode.Alpha1, 0);
        handleKeys.Add(KeyCode.Alpha2, 1);
        handleKeys.Add(KeyCode.Alpha3, 2);
    }

    private void onHandlingObj()
    {
        if (!Input.anyKeyDown) {
            return;
        }

        Event e = Event.current;

        if (e.isKey && handleKeys.ContainsKey(e.keyCode)) {
            _handlingObj = handleKeys[e.keyCode];
        }
    }

    #endregion
}