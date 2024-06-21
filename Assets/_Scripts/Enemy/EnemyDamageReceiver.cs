using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy Damage Receiver")]
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected GameObject victoryUI;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
        this.ReBorn();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyController != null) return;
        this.enemyController = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    public override void ReBorn()
    {
        this.maxHP = this.enemyController.EnemySO.hp;
        base.ReBorn();  
    }

    protected override void OnDead()
    {
        this.SpawnItemOnDead();

        if(enemyController.EnemySO.enemyType == EnemyType.Boss)
        {
            StartCoroutine(this.EndGame());
            return;
        }

        this.DespawnEnemy();
    }

    protected virtual void SpawnItemOnDead()
    {
        Vector3 dropPos = transform.parent.position;
        Quaternion dropRot = transform.rotation;
        ItemSpawner.Instance.SpawnItem(this.enemyController.EnemySO.itemSpawnList, dropPos, dropRot);
    }

    protected virtual void DespawnEnemy()
    {
        EnemySpawner.Instance.DespawnToPool(transform.parent);
    }

    IEnumerator EndGame()
    {
        this.enemyController.EnemyDetectCollision.gameObject.SetActive(false);

        yield return new WaitForSeconds(10);
        this.DespawnEnemy();
        this.victoryUI.SetActive(true);
    }
}
