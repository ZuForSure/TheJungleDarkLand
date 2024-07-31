using UnityEngine;

public class PlayerDamageSender : DamageSender
{
    [Header("Player Damage Sender")]
    [SerializeField] protected PlayerAttack playerAttack;
    [SerializeField] protected int playerDamage = 2;
    [SerializeField] protected int manaToRecovery = 1;
    //[SerializeField] protected float repel = 5f;
    //[SerializeField] protected float repelCount = 0.5f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerAttack();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetPlayerDamage();
    }

    protected virtual void LoadPlayerAttack()
    {
        if (this.playerAttack != null) return;
        this.playerAttack = transform.GetComponentInParent<PlayerAttack>();
        Debug.Log(transform.name + ": LoadPlayerAttack", gameObject);
    }

    protected virtual void ResetPlayerDamage()
    {
        this.damage = this.playerDamage;
        this.collid2D.isTrigger = true;
        Debug.Log(transform.name + ": Reset Damage", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.SendDamageToObj(collision.transform);

        DamageReceiver damageReceiver = collision.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;

        this.RecoveryManaToShoot(this.manaToRecovery);

        Vector3 spawnPos = collision.transform.position;
        spawnPos.z = -1;
        this.SpawnFX(spawnPos, collision.transform.rotation);
        AudioManager.Instance.PlayImpactBodySound();

        //Rigidbody2D rigi2D = collision.transform.parent.gameObject.GetComponent<Rigidbody2D>();
        //if (rigi2D == null) return;

        //Vector2 awayFromPlayer = collision.transform.position - transform.position;
        //rigi2D.AddForce(awayFromPlayer * this.repel, ForceMode2D.Impulse);
    }

    protected virtual void RecoveryManaToShoot(int manaToRecover)
    {
        int mana = this.playerAttack.PlayerCtrl.PlayerShooting.manaShoot;
        int maxMana = this.playerAttack.PlayerCtrl.PlayerShooting.MaxManaShoot;

        if (mana >= maxMana) return;
        this.playerAttack.PlayerCtrl.PlayerShooting.manaShoot += manaToRecover;
    }

    protected virtual void SpawnFX(Vector3 pos, Quaternion rot)
    {
        Transform blood = FXSpawner.Instance.SpawnPrefab(FXSpawner.BloodFX, pos, rot);
        blood.gameObject.SetActive(true);
    }
}
