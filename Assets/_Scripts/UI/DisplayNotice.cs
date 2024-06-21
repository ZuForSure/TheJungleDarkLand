using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(BoxCollider2D))]

public class DisplayNotice : ZuMonoBehaviour
{
    [SerializeField] protected BoxCollider2D box2D;
    [SerializeField] protected Transform noticeUI;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBox2D();
        this.LoadNoticeUI();
    }

    protected virtual void LoadBox2D()
    {
        if (this.box2D != null) return;
        this.box2D = transform.GetComponent<BoxCollider2D>();
        this.box2D.isTrigger = true;
        Debug.Log(transform.name + (": LoadBox2D"), gameObject);
    }

    protected virtual void LoadNoticeUI()
    {
        if (this.noticeUI != null) return;
        this.noticeUI = GameObject.Find("Notice UI").transform;
        this.noticeUI.gameObject.SetActive(false);
        Debug.Log(transform.name + (": LoadNoticeUI"), gameObject);
    }

    protected virtual void Displaying()
    {
        this.noticeUI.gameObject.SetActive(true);
    }

    protected virtual void Hiding()
    {
        this.noticeUI.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        this.Displaying();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        this.Hiding();
    }
}
