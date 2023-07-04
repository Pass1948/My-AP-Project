using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;


    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()       // late�� �ٸ� �۾��� ���� �Ϸ�ȵ� �������� ������Ʈ�ȴ�
    {
        // �� ������ ���� �÷��̾ ���缭 ī�޶� ������(��üȸ���� ������ �ʱ�����)
        transform.position = player.transform.position + offset;
    }
}
