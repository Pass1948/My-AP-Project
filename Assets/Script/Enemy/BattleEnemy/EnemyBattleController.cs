using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking.Types;

public class EnemyBattleController : MonoBehaviour, IEventListener
{
    private Animator animator;
    private GameObject spawnPoint;
    private GameObject AttackPosition;
    private float Speed = 5f;


    private void Awake()
    {
        AttackPosition = GameManager.Resource.Load<GameObject>("Enemy/EnemyAttackPoint");
        spawnPoint = GameManager.Resource.Load<GameObject>("Enemy/EnemySpawn");

        GameManager.Event.AddListener(EventType.EnemyTurn, this);
        GameManager.Event.AddListener(EventType.EnemyAttack, this);
        GameManager.Event.AddListener(EventType.Sucess_ET, this);
        GameManager.Event.AddListener(EventType.fail_ET, this);
        GameManager.Event.AddListener(EventType.PlayerAttack, this);
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
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case (EventType.EnemyTurn):
                TatgetInMoving();
                break;
            case (EventType.EnemyAttack):
                GameManager.Event.RemoveEvent(EventType.EnemyAttack);
                animator.SetBool("Attack", true);
                break;
            case (EventType.Sucess_ET):
                GameManager.Event.RemoveEvent(EventType.Sucess_ET);
                animator.SetBool("Attack", false);
                break;
            case (EventType.fail_ET):
                GameManager.Event.RemoveEvent(EventType.fail_ET);
                animator.SetBool("Attack", false);
                break;
            case (EventType.PlayerAttack):
                GameManager.Event.RemoveEvent(EventType.PlayerAttack);
                StartCoroutine(GetHitRoutine());
                break;

        }
    }

    IEnumerator GetHitRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("GetHit", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("GetHit", false);
        yield return new WaitForSeconds(0.5f);
    }
}
