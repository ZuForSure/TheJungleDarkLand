using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : ZuMonoBehaviour
{
    [SerializeField] protected static SpawnPoints instance;
    public static SpawnPoints Instance => instance;

    [SerializeField] protected List<Transform> points;
    public List<Transform> Points => points;

    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("Only 1 SpawnPoints are allowed to exist");
        SpawnPoints.instance = this;
    }

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
}
