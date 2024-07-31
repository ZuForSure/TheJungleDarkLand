using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : PowerBar
{
    protected override void Update()
    {
        base.Update();
        this.SetStackManaFromPlayer();
    }

    protected virtual void SetStackManaFromPlayer()
    {
        int manaLeave;
        int manaRemain;
        manaLeave = this.playerCtrl.PlayerShooting.MaxManaShoot - this.playerCtrl.PlayerShooting.manaShoot;
        manaRemain = this.playerCtrl.PlayerShooting.manaShoot;

        if (manaRemain > 4) manaRemain = 4;

        for (int i = 0; i < manaRemain; i++)
        {
            this.stackObjects[i].gameObject.SetActive(true);
        }

        if (manaLeave <= 0) return;
        for (int i = this.stackObjects.Count - 1; i >= manaRemain; i--)
        {
            this.stackObjects[i].gameObject.SetActive(false);
        }
    }
}
