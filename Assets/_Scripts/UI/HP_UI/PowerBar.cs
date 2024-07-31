using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PowerBar : ZuMonoBehaviour
{
    [Header("Power Bar")]
    [SerializeField] protected List<Image> stackObjects;
    [SerializeField] protected PlayerController playerCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemChild();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadItemChild()
    {
        if (this.stackObjects.Count >= 1) return;
        foreach (Transform child in this.transform)
        {
            Image stackHP = child.GetComponent<Image>();
            this.stackObjects.Add(stackHP);
        }

        Debug.Log(transform.name + ": LoadStackHP", gameObject);
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.FindObjectOfType<PlayerController>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
