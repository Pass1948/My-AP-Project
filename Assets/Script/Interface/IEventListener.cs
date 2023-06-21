using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public interface IEventListener
{
    //�̺�Ʈ �߻��� ���۵Ǵ� �̺�Ʈ ����.
    public void OnEvent(EventType eventType, Component Sender, object Param = null);

    // �̺�Ʈ �߻� Ȯ�ο� �ڵ�
    /*
    string result = string.Format("���� �̺�Ʈ ���� :  {0}, �̺�Ʈ ������ ������Ʈ : {1}", eventType, Sender.gameObject.name.ToString());
    Debug.Log(result);
    */
}
