using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Stack<ICommanable> m_CommandsBuffer;

    private void Awake()
    {
        m_CommandsBuffer = new Stack<ICommanable>();
    }

    public void AddCommand(ICommanable command)         // �ൿ �߰�
    {
        m_CommandsBuffer.Push(command);
        Debug.Log("���¾� ������");
    }
    public void CencelCommand(ICommanable command)      // �ֽ� �ൿ ��� �����ൿ���� �̵�
    {
        if (m_CommandsBuffer.Count > 0)
        {
            command = m_CommandsBuffer.Pop();
            Debug.Log("��ҵ� ���: " + command);
        }

        if (m_CommandsBuffer.Count >= 2)
        {
            m_CommandsBuffer.Pop(); // ���� ��� ����
            command = m_CommandsBuffer.Peek(); // ���� ��� ��������
            Debug.Log("���� ��� ���, ���� ��� ����: " + command);
        }
        else if (m_CommandsBuffer.Count == 1)
        {
            m_CommandsBuffer.Pop(); // ���� ��� ����
            Debug.Log("���� ��� ���, ���� ��� ����");
        }
        else
        {
            Debug.Log("��� ���۰� ����ֽ��ϴ�.");
        }

    }

    public void UseCommand()                            // �ֽ� �ൿ ����
    {
        if (m_CommandsBuffer.Count > 0)
        {
            ICommanable usedCommand = m_CommandsBuffer.Pop();
            Debug.Log("���� ���: " + usedCommand);
        }
        else
        {
            Debug.Log("��� ���۰� ������ϴ�.");
        }
    }

    public void RefreshCommand()                         // ��� ��� ����
    {
        m_CommandsBuffer.Clear();
    }
}
