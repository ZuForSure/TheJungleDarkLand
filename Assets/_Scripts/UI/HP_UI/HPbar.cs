using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : ZuMonoBehaviour
{
    [SerializeField] protected List<Image> stackHPs;
    [SerializeField] protected PlayerController playerCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemChild();
        this.LoadPlayerCtrl();
    }

    protected override void Update()
    {
        base.Update();
        this.SetStackHPFromPlayer();
    }

    protected virtual void LoadItemChild()
    {
        if (this.stackHPs.Count >= 1) return;
        foreach (Transform child in this.transform)
        {
            Image stackHP = child.GetComponent<Image>();
            this.stackHPs.Add(stackHP);
        }

        //this.HideItem();
        Debug.Log(transform.name + ": LoadStackHP", gameObject);
    }

    protected virtual void HideItem()
    {
        foreach (Image child in this.stackHPs)
        {
            child.gameObject.SetActive(false);
        }
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.FindObjectOfType<PlayerController>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
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
            this.stackHPs[i].gameObject.SetActive(true);
        }

        if (hpLeave <= 0) return;
        for(int i = this.stackHPs.Count - 1; i >= hpRemain; i--)
        {
            this.stackHPs[i].gameObject.SetActive(false);
        }
    }
}
