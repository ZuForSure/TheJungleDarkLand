using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    protected float inputHorizontal;
    protected float inputVertical;
    protected float inputDash;

    private void Awake()
    {
        InputManager.instance = this;
    }

    public virtual float GetInputHorizontal()
    {
        this.inputHorizontal = Input.GetAxisRaw("Horizontal");
        return this.inputHorizontal;
    }

    public virtual float GetInputVertical()
    {
        this.inputVertical = Input.GetAxisRaw("Vertical");
        return this.inputVertical;
    }

    public virtual float GetInputDash()
    {
        this.inputDash = Input.GetAxis("Jump");
        return this.inputDash;
    }
}
