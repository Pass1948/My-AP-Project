using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Stack<ICommandable> m_CommandsBuffer;

    private void Awake()
    {
        m_CommandsBuffer = new Stack<ICommandable>();
    }

    public void AddCommand(ICommandable command)         // 행동 추가
    {
        m_CommandsBuffer.Push(command);
        Debug.Log("나는야 퉁퉁이");
    }
    public void CencelCommand(ICommandable command)      // 최신 행동 취소 이전행동으로 이동
    {
        if (m_CommandsBuffer.Count > 0)
        {
            command = m_CommandsBuffer.Pop();
            Debug.Log("취소된 명령: " + command);
        }

        if (m_CommandsBuffer.Count >= 2)
        {
            m_CommandsBuffer.Pop(); // 현재 명령 제거
            command = m_CommandsBuffer.Peek(); // 이전 명령 가져오기
            Debug.Log("현재 명령 취소, 이전 명령 실행: " + command);
        }
        else if (m_CommandsBuffer.Count == 1)
        {
            m_CommandsBuffer.Pop(); // 현재 명령 제거
            Debug.Log("현재 명령 취소, 이전 명령 없음");
        }
        else
        {
            Debug.Log("명령 버퍼가 비어있습니다.");
        }
    }

    public void UseCommand()                            // 최신 행동 실행
    {
        if (m_CommandsBuffer.Count > 0)
        {
            ICommandable usedCommand = m_CommandsBuffer.Pop();
            Debug.Log("사용된 명령: " + usedCommand);
        }
        else
        {
            Debug.Log("명령 버퍼가 비었습니다.");
        }
    }

    public void RefreshCommand()                         // 모든 명령 제거
    {
        m_CommandsBuffer.Clear();
    }
}
