using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D playerRb;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float dashSpeed = 10f;
    [SerializeField] protected float dashCooldown = 0f;
    [SerializeField] protected float dashCoolCounter = 0.75f;

    private float horizontal;
    private float vertical;
    private float dash;

    private void Awake()
    {
        this.playerRb = transform.parent.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody2D", gameObject);
    }

    private void FixedUpdate()
    {
        this.GetInput();
        this.Moving();
    }

    protected virtual void GetInput()
    {
        this.horizontal = InputManager.Instance.GetInputHorizontal();
        this.vertical = InputManager.Instance.GetInputVertical();
        this.dash = InputManager.Instance.GetInputDash();
    }

    protected virtual void Moving()
    {
        Vector3 direction = new (this.horizontal, this.vertical, 0);
        this.playerRb.velocity = direction * this.ActiveSpeed();

        //transform.parent.position += direction * this.ActiveSpeed() * Time.fixedDeltaTime;
    }

    protected virtual float ActiveSpeed()
    {
        float activeSpeed = this.speed;
        if (this.CanDashing())
        {
            activeSpeed *= this.dashSpeed;
            this.dashCooldown = this.dashCoolCounter;
        }
        this.TimerDash();

        return activeSpeed;
    }

    protected virtual void TimerDash()
    {
        if (this.dashCooldown <= 0) return;
        this.dashCooldown -= Time.fixedDeltaTime;
    }

    protected virtual bool CanDashing()
    {
        if (this.dash == 1 && this.dashCooldown <= 0f) return true;
        return false;
    }

}
