using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class AdventurePlayer : MonoBehaviour
{
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float jumpPower;

    private Animator animator;
    private Vector3 moveDir;
    private Rigidbody rb;
    private float moveSpeed;
    private bool isWalking;
    private float curSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        Move();
        GroundCheck();
    }

    void Move()
    {
        // Mathf.Lerp() 애니메이션에 부드러운 전환을 넣기위한 정밀작업
        if (moveDir.magnitude == 0)
        {
            curSpeed = Mathf.Lerp(curSpeed, 0, 0.1f);
            //animator.SetFloat("MoveSpeed", curSpeed);
            return;
        }

        else if (isWalking)             // 움직일 경우
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, 0.5f);
        }

        else                            // 뛸경우
        {
            moveSpeed = Mathf.Lerp(moveSpeed, runSpeed, 0.5f);
        }


        Vector3 vecFor = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        Vector3 vecRig = new Vector3(transform.right.x, 0,transform.right.z).normalized;

        transform.Translate(vecFor * moveDir.z* moveSpeed * Time.deltaTime, Space.Self);
        transform.Translate(vecRig * moveDir.x * moveSpeed * Time.deltaTime, Space.Self);

        Quaternion lookRotation = Quaternion.LookRotation(vecFor * moveDir.z + vecFor * moveDir.x);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);


        //animator.SetFloat("XSpeed", moveDir.x, 0.1f, Time.deltaTime);
        //animator.SetFloat("YSpeed", moveDir.z, 0.1f, Time.deltaTime);

        //animator.SetFloat("Speed", moveSpeed);
    }

    void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }
    private void OnWalk(InputValue value)
    {
        isWalking = value.isPressed;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    void OnJump(InputValue value)
    {

        if (GroundCheck())
            Jump();
    }

    private bool GroundCheck()
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position + Vector3.up * 1, 0.5f, Vector3.down, out hit, 0.6f);
    }
}
