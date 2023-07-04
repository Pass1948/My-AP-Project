using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemetoManager : MonoBehaviour
{
    private List<BaseSaveData> saveDataList = new List<BaseSaveData>();


    //���� ���̺� �����͸� ����Ʈ�� �־� ����.
    public void PushAutoSaveData(BaseSaveData data)
    {
        if (saveDataList == null)
        {
            saveDataList = new List<BaseSaveData>();
        }
        saveDataList.Add(data);
    }

    //���� ���̺� �����͸� ����Ʈ���� ������ ����Ʈ���� ����. 
    public BaseSaveData PopLastAutoSaveData()
    {
        BaseSaveData data = GetLastAutoSaveData();

        //�ֱ� �����Ͱ� �����Ѵٸ� list���� ����
        if (data != null)
        {
            saveDataList.Remove(data);
        }

        return data;
    }

    //���� �ֱ� ���� ���̺� ������ �ҷ�����.
    public BaseSaveData GetLastAutoSaveData()
    {
        //�ּ����� ����ó��
        if (!CheckListUsable())
        {
            Debug.Log("������ �ҷ����� ���� : GetLastAutoSaveData");
            return null;
        }

        //���α׷��� ���� ���ڸ� �� �� 0���� �����ϹǷ�, ������ ���̺� �������� ������ 1�� ���ش�.
        return saveDataList[saveDataList.Count - 1];
    }

    //Ư����ġ�� ���� ���̺� ������ �ҷ�����
    public BaseSaveData GetAutoSaveDataAt(int index)
    {
        //�ּ����� ����ó��
        if (!CheckListUsable())
        {
            Debug.Log("������ �ҷ����� ���� : GetAutoSaveDataAt.");
            return null;
        }
        else if (saveDataList.Count <= index)
        {
            Debug.Log("��û�� �ε����� ����Ʈ�� ũ�⸦ �Ѿ.");
            return null;
        }

        return saveDataList[index];
    }

    //autoSaveDataList�� ���ǵǾ��ִ���, Ȥ�� ����ִ��� üũ
    private bool CheckListUsable()
    {
        if (saveDataList == null)
        {
            Debug.Log("���� ���̺� ������ ����Ʈ�� ���ǵ��� ����.");
        }
        else if (saveDataList.Count == 0)
        {
            Debug.Log("���� ����Ʈ ������ ����Ʈ�� ����� �����Ͱ� ����.");
        }
        else
        {
            return true;
        }

        return false;
    }

    //������ Ŭ����
    public void ClearAutoSaveDataList()
    {
        saveDataList.Clear();
    }
}
