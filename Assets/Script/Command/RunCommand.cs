using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCommand : BaseCommand
{
    public override void Execute()
    {
        // ������� �ش�
        Run();
    }

    public void Run()
    {
        Debug.Log("�ϰԷ�ٿ�~");
    }
}
