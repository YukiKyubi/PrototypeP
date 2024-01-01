using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiMono : MonoBehaviour
{
    protected virtual void Start() {}

    protected virtual void Reset() {
        LoadComponents();
        ResetValues();
    }

    protected virtual void Awake()
    {
        LoadComponents();
    }

    protected virtual void LoadComponents() {}

    protected virtual void ResetValues() {}

    protected virtual void OnEnable() {}

    protected virtual void OnDisable() {}
}
