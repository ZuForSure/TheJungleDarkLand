using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : ZuMonoBehaviour
{
    [SerializeField] protected List<Transform> points;
    public List<Transform> Points => points;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach (Transform child in this.transform)
        {
            this.points.Add(child);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }

    public virtual Transform GetRandomPoint()
    {
        int rand = Random.Range(0, this.points.Count);
        return this.points[rand];
    }
}
