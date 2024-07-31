using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : PowerBar
{
    protected override void Update()
    {
        base.Update();
        this.SetStackHPFromPlayer();
    }

    protected virtual void SetStackHPFromPlayer()
    {
        int hpLeave;
        int hpRemain;
        hpLeave = this.playerCtrl.PlayerDamageReceiver.maxPlayerHP - this.playerCtrl.PlayerDamageReceiver.hp;
        hpRemain = this.playerCtrl.PlayerDamageReceiver.hp;

        if (hpRemain > 10) hpRemain = 10;

        for (int i = 0; i < hpRemain; i++)
        {
            this.stackObjects[i].gameObject.SetActive(true);
        }

        if (hpLeave <= 0) return;
        for(int i = this.stackObjects.Count - 1; i >= hpRemain; i--)
        {
            this.stackObjects[i].gameObject.SetActive(false);
        }
    }
}
