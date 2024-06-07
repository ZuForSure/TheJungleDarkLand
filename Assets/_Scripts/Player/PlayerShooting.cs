using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] protected float shootCooldown = 0.2f;
    [SerializeField] protected float shootCooldownCount = 0f;
    [SerializeField] protected bool isShooting = false;

    private void Update()
    {
        this.IsShooting();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (this.isShooting && this.shootCooldownCount < 0f)
        {
            this.shootCooldownCount = this.shootCooldown;

            Vector3 pos = transform.parent.position;
            Quaternion rot = transform.rotation;
            Transform newBullet = BulletSpawner.Instance.SpawnPrefab(BulletSpawner.bulletOne, pos, rot);
            if (newBullet == null) return;
            newBullet.gameObject.SetActive(true);

            BulletController bulletCtrl = newBullet.GetComponent<BulletController>();
            bulletCtrl.SetShooter(transform.parent);
        }
           
        if (this.shootCooldownCount < 0 && this.isShooting) this.isShooting = false;

        if (this.shootCooldownCount < 0f) return;
        this.shootCooldownCount -= Time.fixedDeltaTime;
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.InputShoot == 1;
        return this.isShooting;
    }
}
