using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI_BTStart : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void BattleActive()
    {
        anim.SetBool("BattleActive", true);
    }

    public void BattleActiveEnd()
    {
        anim.SetBool("BattleActive", false);
    }

}
