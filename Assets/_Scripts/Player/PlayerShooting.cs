using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : ZuMonoBehaviour
{
    [SerializeField] protected float shootCooldown = 1f;
    [SerializeField] protected float shootCooldownCount = 0f;
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected int maxManaShoot = 4;
    public int MaxManaShoot => maxManaShoot;
    public int manaShoot = 0;

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (this.manaShoot <= 0) return;

        if (this.IsShooting() && this.shootCooldownCount < 0f)
        {
            this.shootCooldownCount = this.shootCooldown;
            this.manaShoot--;

            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            Transform newBullet = BulletSpawner.Instance.SpawnPrefab(BulletSpawner.bulletOne, pos, rot);
            if (newBullet == null) return;
            newBullet.gameObject.SetActive(true);

            BulletController bulletCtrl = newBullet.GetComponent<BulletController>();
            bulletCtrl.SetShooter(transform.parent);
            AudioManager.Instance.PlayShootSound();
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
