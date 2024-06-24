using UnityEngine;

public class EagleAttack : EnemyAttack
{
    [Header("Eagle Attack")]
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 2.5f;

    protected override void Update()
    {
        base.Update();
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (!this.CanAttack()) return;

        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0f;

        Vector3 eaglePos = transform.parent.position;
        Quaternion eagleRot = transform.rotation;
        Transform newArrow = BulletSpawner.Instance.SpawnPrefab(BulletSpawner.arrow, eaglePos, eagleRot);
        if (newArrow == null) return;
        
        newArrow.gameObject.SetActive(true);
        BulletController bulletCtrl = newArrow.GetComponent<BulletController>();
        bulletCtrl.SetShooter(transform.parent);
    }

    protected override bool CanAttack()
    {
        this.isAttaking = enemyController.EnemyDetectCollision.isPlayerComeIn;
        if (GameController.Instance.isGameOver) this.isAttaking = false;

        return this.isAttaking;   
    }
}
