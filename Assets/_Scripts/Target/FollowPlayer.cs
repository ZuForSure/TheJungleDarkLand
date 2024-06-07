using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowPlayer : ZuMonoBehaviour
{
    [Header("Follow Player")]
    public Transform player;
    [SerializeField] protected float speed = 0f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }

    protected abstract void Following();
}