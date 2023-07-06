using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerController : MonoBehaviour, IEventListener
{
    private GameObject spawnPoint;
    private GameObject AttackPosition;
    private Animator animator;
    private bool sliding1 = false;
    private bool sliding2 = false;

    private float Speed = 5f;

    private void Awake()
    {
        AttackPosition = GameManager.Resource.Load<GameObject>("Player/Battle/PlayerAttackPoint");
        spawnPoint = GameManager.Resource.Load<GameObject>("Player/Battle/PlayerSpawn");
        animator = gameObject.GetComponent<Animator>();
        GameManager.Event.AddListener(EventType.SelectTarget, this);
        GameManager.Event.AddListener(EventType.Sucess_Ani, this);
        GameManager.Event.AddListener(EventType.Fail_Ani, this);
    }

    private void Update()
    {
        Sliding();
    }

    private void Sliding()
    {
        if (sliding1 == true)
        {
            TatgetInMoving();
        }

        if (sliding2 == true)
        {
            ReturnPosition();
            
        }
    }

    public void TatgetInMoving()
    {
        animator.SetBool("Move", true);
        transform.position += (AttackPosition.transform.position - GetPosition()) * Speed * Time.deltaTime;
        float reachedDistance = 0.5f;
        if (Vector3.Distance(GetPosition(), AttackPosition.transform.position) < reachedDistance)
        {
            transform.position = AttackPosition.transform.position;
            animator.SetBool("Move", false);
            sliding1 = false;
        }
    }

    public void ReturnPosition()
    {
        animator.SetBool("Move", true);
        transform.position += (spawnPoint.transform.position - GetPosition()) * Speed * Time.deltaTime;
        float reachedDistance = 0.5f;
        if (Vector3.Distance(GetPosition(), spawnPoint.transform.position) < reachedDistance)
        {
            transform.position = spawnPoint.transform.position;
            animator.SetBool("Move", false);
            sliding2 = false;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.SelectTarget)
        {
            sliding1 = true;
            GameManager.Event.RemoveEvent(EventType.SelectTarget);
        }
        if (eventType == EventType.Sucess_Ani)
        {
            animator.Play("CriticalAttack");
            StartCoroutine(ReturnRoutine());
            GameManager.Event.RemoveEvent(EventType.Sucess_Ani);
        }
        if (eventType == EventType.Fail_Ani)
        {
            animator.Play("NomalAttack");
            StartCoroutine(ReturnRoutine());
            GameManager.Event.RemoveEvent(EventType.Fail_Ani);
        }
    }

    IEnumerator ReturnRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        sliding2 = true;
        yield return new WaitForSeconds(0.5f);
    }

}
