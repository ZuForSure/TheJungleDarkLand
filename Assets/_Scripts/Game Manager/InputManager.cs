using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected Vector3 mouseWorldPos;
    [SerializeField] protected float inputHorizontal;
    [SerializeField] protected float inputVertical;
    [SerializeField] protected float inputDash;
    [SerializeField] protected float inputAttack;
    [SerializeField] protected float inputShoot;
    [SerializeField] protected bool inputInventory;
    public Vector3 MouseWorldPos => mouseWorldPos;
    public float InputHorizontal => inputHorizontal;
    public float InputVertical => inputVertical;
    public float InputDash=> inputDash;
    public float InputAttack => inputAttack;
    public float InputShoot => inputShoot;
    public bool InputInventory => inputInventory;

    private void Awake()
    {
        if (instance != null) Debug.LogError("Only one InputManager are allowed to exist");
        InputManager.instance = this;
    }

    private void Update()
    {
        this.GetMousePos();
        this.GetInputMove();
        this.GetInputDash();
        this.GetInputAttack();
        this.GetInputShoot();
        this.GetInputInventory();
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetInputMove()
    {
        this.inputHorizontal = Input.GetAxisRaw("Horizontal");
        this.inputVertical = Input.GetAxisRaw("Vertical");
    }

    protected virtual void GetInputDash()
    {
        this.inputDash = Input.GetAxis("Jump");
    }

    protected virtual void GetInputAttack()
    {
        this.inputAttack = Input.GetAxisRaw("Fire1");
    }

    protected virtual void GetInputShoot()
    {
        this.inputShoot = Input.GetAxisRaw("Fire2");
    }
    
    protected virtual void GetInputInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            this.inputInventory = !this.inputInventory;
        }
    }
}
