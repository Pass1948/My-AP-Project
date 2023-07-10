using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetSetUI : WindowUI, IEventListener
{
    [SerializeField] Transform followTarget;
    public Vector2 follwOffset;
    protected override void Awake()
    {
        base.Awake();
        buttons["TargetButton"].onClick.AddListener(() => {SelectTarget(); });
    }
    public void SelectTarget()
    {
        Debug.Log("타켓선택");
        GameManager.Event.PostNotification(EventType.Attack, this);         // 공격 이벤트 발생
        GameManager.Event.PostNotification(EventType.SelectTarget, this);
        GameManager.UI.ShowWindowUI<WindowUI>("UI/PlayerButtonActUI");
        GameManager.UI.CloseWindowUI(this);
    }

    private void OnEnable()
    {
        buttons["TargetButton"].Select();
    }
    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }

    private void LateUpdate()
    {
        if (followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)follwOffset;
        }
    }

    public void SetTarget(Transform traget)
    {
        this.followTarget = traget;
        if (followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)follwOffset;
        }
    }

    public void SetOffSet(Vector2 traget)
    {
        this.follwOffset = traget;
        if (followTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(followTarget.position) + (Vector3)follwOffset;
        }
    }
}
