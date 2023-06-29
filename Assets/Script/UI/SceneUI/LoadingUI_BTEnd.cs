using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI_BTEnd : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        anim.SetBool("Active", true);
    }

    public void FadeOut()
    {
        anim.SetBool("Active", false);
    }
}
