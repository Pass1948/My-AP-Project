using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCommand : BaseCommand
{
    public override void Execute()
    {
        // 대미지를 준다
        Run();
    }

    public void Run()
    {
        Debug.Log("니게룽다요~");
    }
}
