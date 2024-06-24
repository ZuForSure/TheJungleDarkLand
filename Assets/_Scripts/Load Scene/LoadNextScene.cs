using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]

public class LoadNextScene : ZuMonoBehaviour
{
    [SerializeField] protected BoxCollider2D box2D;
    [SerializeField] protected Inventory playerInven;
    [SerializeField] protected Animator transitionAnim;
    [SerializeField] protected int requestKeys = 6;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBox2D();
        this.LoadPlayerInven();
    }

    protected virtual void LoadBox2D()
    {
        if (this.box2D != null) return;
        this.box2D = transform.GetComponent<BoxCollider2D>();
        this.box2D.isTrigger = true;
        Debug.Log(transform.name + (": LoadBox2D"), gameObject);
    }

    protected virtual void LoadPlayerInven()
    {
        if (this.playerInven != null) return;
        this.playerInven = GameObject.FindObjectOfType<Inventory>();
        Debug.Log(transform.name + (": LoadPlayerInven"), gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
            
        if (transform.name != "BossMap") 
        {
            StartCoroutine(this.LoadScene());
            return;
        };

        if (transform.name == "BossMap" && !this.IsEnoughKeys())
        {
            Debug.Log("Not Enough Keys");
            return;
        }

        //SceneManager.LoadScene("BossMap");
        StartCoroutine(this.LoadScene());
    }

    protected virtual bool IsEnoughKeys()
    {
        int currentKeys = 0;
        foreach (ItemInventory item in this.playerInven.ItemInventoryList)
        {
            if(item.itemSO == null) continue;
            if (item.itemSO.itemType != ItemType.Key) continue;
            currentKeys++;
        }

        if (currentKeys < this.requestKeys) return false;
        return true;
    }

    IEnumerator LoadScene()
    {
        this.transitionAnim.SetTrigger("End");

        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        yield return waitForSeconds;

        SceneManager.LoadScene(transform.name);
        this.transitionAnim.SetTrigger("Start");
    }
}
