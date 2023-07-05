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
        transform.position = offset;
    }

    void LateUpdate()       // late는 다른 작업이 전부 완료된뒤 마지막에 업데이트된다
    {
        // 매 프레임 마다 플레이어에 맞춰서 카메라가 움직임(구체회전에 따라가지 않기위해)
        transform.position = player.transform.position + offset;
    }
}
