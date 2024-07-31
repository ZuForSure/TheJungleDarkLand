using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy Damage Receiver")]
    [SerializeField] protected EnemyController enemyController;

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
        if (this.enemyController == null) return;
        this.maxHP = this.enemyController.EnemySO.hp;
        base.ReBorn();  
    }

    protected override void OnDead()
    {
        this.SpawnItemOnDead();
        this.SpawnFXOnDead();
        this.DespawnEnemy();

        if (enemyController.EnemySO.enemyType != EnemyType.Boss) return;
        GameController.Instance.VictoryGame();
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

    protected virtual void SpawnFXOnDead()
    {
        Vector3 spawnPos = transform.parent.position;
        Quaternion spawnRot = transform.parent.rotation;

        Transform bossDeath = FXSpawner.Instance.SpawnPrefab(transform.parent.name + " Death", spawnPos, spawnRot);
        bossDeath.gameObject.SetActive(true);
    }

    //IEnumerator EndGame()
    //{
    //    this.enemyController.EnemyDetectCollision.gameObject.SetActive(false);

    //    yield return new WaitForSeconds(10);

    //    this.victoryUI.SetActive(true);
    //    this.DespawnEnemy();
    //}
}
