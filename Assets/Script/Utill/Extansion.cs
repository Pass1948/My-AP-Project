using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extansion
{
    public static bool IsContaion(this LayerMask laterMask, int layer)
    {
        return ((1 << layer) & laterMask) != 0;
    }
}
