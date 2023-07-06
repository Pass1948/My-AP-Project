using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public float progress { get; protected set; }
    protected abstract IEnumerator LoadingRoutine_BT();
    protected abstract IEnumerator LoadingRoutine_AD();

    public void LoadAsync_BT()
    {
        StartCoroutine(LoadingRoutine_BT());
    }
    public void LoadAsync_AD()
    {
        StartCoroutine(LoadingRoutine_AD());
    }
}
