using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public abstract class EnemyDetectCollision : ZuMonoBehaviour
{
    [Header("Enemy Detect Collision")]
    [SerializeField] protected CircleCollider2D circleCollider2D;
    [SerializeField] protected float detectRadius = 3f;
    [SerializeField] protected string compareTag = "Player";
    public bool isPlayerComeIn = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = transform.GetComponent<CircleCollider2D>();
        this.circleCollider2D.isTrigger = true;
        this.circleCollider2D.radius = this.detectRadius;
        Debug.Log(transform.name + ": LoadCircleCollider2D", gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(this.compareTag))
        {
            this.isPlayerComeIn = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(this.compareTag))
        {
            this.isPlayerComeIn = false;
        }
    }
}
