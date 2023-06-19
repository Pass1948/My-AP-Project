using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
       
    private bool isExecuting = false;
    private Queue<ICommand> m_CommandsBuffer;

    private void Awake()
    {
        m_CommandsBuffer = new Queue<ICommand>();
    }

    public void AddCommand(ICommand command)
    {
        m_CommandsBuffer.Enqueue(command);
        command.Execute();
        Debug.Log("나는야 퉁퉁이");
        UseCommand();
    }

    public void UseCommand()
    {
        if (m_CommandsBuffer.Count == 0)
        {
            return;
        }
        else
        {
            ICommand command = m_CommandsBuffer.Dequeue();
            
            Debug.Log("나는야 비실이");
        }
    }
}
