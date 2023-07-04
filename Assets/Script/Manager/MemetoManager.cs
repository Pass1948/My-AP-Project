using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemetoManager : MonoBehaviour
{
    private List<BaseSaveData> saveDataList = new List<BaseSaveData>();


    //오토 세이브 데이터를 리스트에 넣어 보존.
    public void PushAutoSaveData(BaseSaveData data)
    {
        if (saveDataList == null)
        {
            saveDataList = new List<BaseSaveData>();
        }
        saveDataList.Add(data);
    }

    //오토 세이브 데이터를 리스트에서 빼오고 리스트에서 삭제. 
    public BaseSaveData PopLastAutoSaveData()
    {
        BaseSaveData data = GetLastAutoSaveData();

        //최근 데이터가 존재한다면 list에서 삭제
        if (data != null)
        {
            saveDataList.Remove(data);
        }

        return data;
    }

    //가장 최근 오토 세이브 데이터 불러오기.
    public BaseSaveData GetLastAutoSaveData()
    {
        //최소한의 예외처리
        if (!CheckListUsable())
        {
            Debug.Log("데이터 불러오기 실패 : GetLastAutoSaveData");
            return null;
        }

        //프로그래밍 언어는 숫자를 셀 때 0부터 시작하므로, 마지막 세이브 데이터의 순번은 1을 빼준다.
        return saveDataList[saveDataList.Count - 1];
    }

    //특정위치의 오토 세이브 데이터 불러오기
    public BaseSaveData GetAutoSaveDataAt(int index)
    {
        //최소한의 예외처리
        if (!CheckListUsable())
        {
            Debug.Log("데이터 불러오기 실패 : GetAutoSaveDataAt.");
            return null;
        }
        else if (saveDataList.Count <= index)
        {
            Debug.Log("요청한 인덱스가 리스트의 크기를 넘어섬.");
            return null;
        }

        return saveDataList[index];
    }

    //autoSaveDataList가 정의되어있는지, 혹은 비어있는지 체크
    private bool CheckListUsable()
    {
        if (saveDataList == null)
        {
            Debug.Log("오토 세이브 데이터 리스트가 정의되지 않음.");
        }
        else if (saveDataList.Count == 0)
        {
            Debug.Log("오토 세이트 데이터 리스트에 저장된 데이터가 없음.");
        }
        else
        {
            return true;
        }

        return false;
    }

    //데이터 클리어
    public void ClearAutoSaveDataList()
    {
        saveDataList.Clear();
    }
}
