using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void Save()
    {
       
        PlayerInfo target = FindObjectOfType<PlayerInfo>();
        if(target != null)
        {
            BaseSaveData.current.objectSaves = new List<ObjectSaveData>();
            ObjectSaveData objectSave = new ObjectSaveData();
            objectSave.name = target.PlayerName;
            objectSave.position = target.transform.position;
            objectSave.rotation = target.transform.rotation;
            BaseSaveData.current.objectSaves.Add(objectSave);
        }

        string json = JsonUtility.ToJson(BaseSaveData.current, true);
        Debug.Log(json);
        string path = Path.Combine(Application.dataPath, "save.json");
        File.WriteAllText(path, json);
    }

    public void Load()
    {
        string path = Path.Combine(Application.dataPath, "save.json");
        string loadJson = File.ReadAllText(path);
        BaseSaveData.current = JsonUtility.FromJson<BaseSaveData>(loadJson);
        PlayerInfo target = FindObjectOfType<PlayerInfo>();

        if (target != null && BaseSaveData.current.objectSaves != null)
        {
             foreach(ObjectSaveData obj in BaseSaveData.current.objectSaves)
             {
                 if(obj.name == target.gameObject.name)
                 {
                     target.gameObject.name = obj.name;
                     target.transform.position = obj.position;
                     target.transform.rotation = obj.rotation;
                 }
             }

        }
    }
}
