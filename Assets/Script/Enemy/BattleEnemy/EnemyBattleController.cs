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
    private bool sliding1 = false;
    private bool sliding2 = false;


    private void Awake()
    {
        AttackPosition = GameManager.Resource.Load<GameObject>("Enemy/EnemyAttackPoint");
        spawnPoint = GameManager.Resource.Load<GameObject>("Enemy/EnemySpawn");
        animator = GetComponent<Animator>();
        GameManager.Event.AddListener(EventType.EnemyTurn, this);
        GameManager.Event.AddListener(EventType.EnemyAttack, this);
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
            sliding1 = false;
            TatgetInMoving();
        }
            
        if (sliding2 == true)
        {
            sliding2 = false;
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
                sliding1 = true;
                TatgetInMoving();
                break;
            case (EventType.EnemyAttack):
                GameManager.Event.RemoveEvent(EventType.EnemyAttack);
                animator.Play("jungle_monster_blowpipe_attack");
                StartCoroutine(ReturnRoutine());
                sliding2 = true;
                break;
            case (EventType.Sucess_Ani):
                animator.Play("jungle_monster_blowpipe_gethit");
                break;
            case (EventType.Fail_Ani):
                animator.Play("jungle_monster_blowpipe_gethit");
                break;
        }
    }
    IEnumerator ReturnRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        sliding2 = true;
        yield return new WaitForSeconds(0.5f);
    }
}
