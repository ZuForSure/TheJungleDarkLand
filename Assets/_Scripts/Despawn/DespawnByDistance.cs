using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float distanceLimit = 20f;
    [SerializeField] protected Transform mainCamera;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = FindObjectOfType<Camera>().transform;
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.parent.position, this.mainCamera.transform.parent.position);
        if (this.distance > this.distanceLimit) return true;
        return false;
    }
}
