using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteracterAdaptor : MonoBehaviour, IInteractable
{
    // ���� NPC Ȥ�� ���̺� �ڽ��� ��ȣ�ۿ��ϵ��� ����
    public UnityEvent OnInteract;

    public void Interact()
    {
        OnInteract?.Invoke();
    }
}
