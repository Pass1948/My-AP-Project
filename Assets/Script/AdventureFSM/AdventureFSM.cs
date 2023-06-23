using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AdventureState
{
    Idel, Adventuring, Size
}

public class AdventureFSM : MonoBehaviour
{
    private BaseState[] states;
    public AdventureState curState;
    private void Awake()
    {
        states = new BaseState[(int)AdventureState.Size];
        states[(int)AdventureState.Idel] = new AdventureIdelState(this);
        states[(int)AdventureState.Adventuring] = new AdventuringState(this);
    }

    private void Start()
    {
        curState = AdventureState.Adventuring;              // ���� ���� �˸�
        states[(int)curState].Enter();
    }

    private void Update()
    {
        states[(int)curState].Update();                 // ������� ������Ʈ
    }

    public void ChangeState(AdventureState AdventureState)
    {
        states[(int)curState].Exit();
        curState = AdventureState;
        states[(int)curState].Enter();
    }
}
