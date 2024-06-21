using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public string objectID;

    private void Awake()
    {
        this.objectID = name + transform.position.ToString() + transform.eulerAngles.ToString();
    }

    private void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroy>()[i] == this) continue;
            if (Object.FindObjectsOfType<DontDestroy>()[i].objectID != this.objectID) continue;
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
