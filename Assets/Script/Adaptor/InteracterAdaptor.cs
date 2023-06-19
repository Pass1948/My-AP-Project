using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteracterAdaptor : MonoBehaviour, IInteractable
{
    // 마을 NPC 혹은 세이브 박스와 상호작용하도록 설정
    public UnityEvent OnInteract;

    public void Interact()
    {
        OnInteract?.Invoke();
    }
}
