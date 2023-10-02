using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseSaveData
{
    private static BaseSaveData _current;

    public List<ObjectSaveData> objectSaves;


    public static BaseSaveData current
    {
        get
        {
            if( _current == null)
            {
                _current = new BaseSaveData();
            }
            return _current;
        }
        set 
        {
            _current = value; 
        }
    }


}
