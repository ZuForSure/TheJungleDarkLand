using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float dashSpeed = 5f;
    [SerializeField] protected float dashCooldown = 0f;
    [SerializeField] protected float dashCoolCounter = 0.5f;
    public bool isDashing = false;

    private float horizontal;
    private float vertical;

    protected void Update()
    { 
        this.GetInput();
        this.Moving();
    }

    protected virtual void GetInput()
    {
        this.horizontal = InputManager.Instance.GetInputHorizontal();
        this.vertical = InputManager.Instance.GetInputVertical();
    }

    protected virtual void Moving()
    {
        Vector3 direction = new(this.horizontal, this.vertical, 0);
        direction.Normalize();

        transform.parent.position += direction * this.ActiveSpeed() * Time.deltaTime;
    }

    protected virtual float ActiveSpeed()
    {
        if (this.CanDashing())
        {
            this.speed += this.dashSpeed;
            this.dashCooldown = this.dashCoolCounter;
            this.isDashing = true;
        }

        if(this.dashCooldown < 0 && this.isDashing)
        {
            this.speed -= this.dashSpeed;
            this.isDashing = false;
        }
        else this.dashCooldown -= Time.deltaTime;

        return this.speed;
    }

    protected virtual bool CanDashing()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.dashCooldown <= 0f) return true;
        return false;
    }
}
