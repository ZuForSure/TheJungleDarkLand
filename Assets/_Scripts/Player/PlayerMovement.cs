using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]

public class PlayerMovement : ZuMonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] protected TrailRenderer trilRenderer;

    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float dashSpeed = 5f;
    [SerializeField] protected float dashTime = 0.25f;
    [SerializeField] protected float dashCounter = 0f;
    [SerializeField] protected float dashCooldown = 0.75f;
    [SerializeField] protected float dashCooldownCounter = 0f;
    public bool isDashing = false;

    private float horizontal;
    private float vertical;
    private float dash;

    protected override void LoadComponent()
    {
        this.LoadTrailRenderer();
    }

    protected virtual void LoadTrailRenderer()
    {
        if (this.trilRenderer != null) return;
        this.trilRenderer = GetComponent<TrailRenderer>();
        Debug.Log(transform.name + ": LoadTrailRenderer", gameObject);
    }

    protected override void Update()
    { 
        this.GetInput();
        this.Moving();
    }

    protected virtual void GetInput()
    {
        this.horizontal = InputManager.Instance.InputHorizontal;
        this.vertical = InputManager.Instance.InputVertical;
        this.dash = InputManager.Instance.InputDash;
    }

    protected virtual void Moving()
    {
        Vector3 direction = new(this.horizontal, this.vertical, 0);
        direction.Normalize();
        transform.parent.position += direction * this.ActiveSpeed() * Time.deltaTime;
    }

    protected virtual float ActiveSpeed()
    {
        if (this.CanDashing()) this.StartDashing();
        if (this.dashCounter < 0 && this.isDashing) this.StopDashing();
        this.DashTimerDown();

        return this.speed;
    }

    protected virtual bool CanDashing()
    {
        if (this.dash > 0.1f && this.dashCooldownCounter <= 0f) return true;
        return false;
    }

    protected virtual void StartDashing()
    {
        this.isDashing = true;
        this.speed += this.dashSpeed;
        this.dashCounter = this.dashTime;
        this.dashCooldownCounter = this.dashCooldown;
        this.trilRenderer.emitting = true;
    }

    protected virtual void StopDashing()
    {
        this.isDashing = false;
        this.speed -= this.dashSpeed;
        this.trilRenderer.emitting = false;
    }

    protected virtual void DashTimerDown()
    {
        if (this.dashCounter < 0f && this.dashCooldownCounter < 0f) return;
        this.dashCounter -= Time.deltaTime;
        this.dashCooldownCounter -= Time.deltaTime;
    }
}