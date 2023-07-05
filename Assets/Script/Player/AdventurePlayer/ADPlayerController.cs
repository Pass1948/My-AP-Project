using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ADPlayerController : MonoBehaviour
{
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float jumpPower;

    private CharacterController controller;
    private Animator animator;

    private Vector3 moveDir;

    private float ySpeed = 0;
    private float curSpeed;
    
    private bool isRun = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Fall();
    }

    private void FixedUpdate()
    {
        Move();
        GroundCheck();
        transform.Rotate(moveDir, Space.World);
    }

    void Move()
    {
        // Mathf.Lerp() 애니메이션에 부드러운 전환을 넣기위한 정밀작업
        if (moveDir.magnitude == 0)
        {
            curSpeed = Mathf.Lerp(curSpeed, 0f, 0.5f);
            animator.SetFloat("MoveSpeed", curSpeed);
            animator.SetBool("IsRun", false);
            isRun = false;
            return;
        }
        if (isRun)
        {
            curSpeed = runSpeed;
            animator.SetBool("IsRun", true);
        }
        else
        {
            curSpeed = Mathf.Lerp(curSpeed, walkSpeed, 1f);
            animator.SetBool("IsRun", false);
        }

        Vector3 vecFor = new Vector3(moveDir.x, 0, moveDir.z).normalized;

        controller.Move(vecFor * curSpeed * Time.deltaTime);
        animator.SetFloat("MoveSpeed", curSpeed);
        transform.rotation = Quaternion.LookRotation(moveDir);
        
    }

    private void OnRun(InputValue value)
    {
        isRun = true;
    }

    void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
            
    }

    private void Fall()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded && ySpeed < 0)
        {
            ySpeed = 0;
        }

        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void Jump()
    {
        animator.SetTrigger("IsJump");
        ySpeed = jumpPower;
    }

    private void OnJump(InputValue value)
    {
        if (GroundCheck())
        {
            Jump();
        }
    }

    private bool GroundCheck()
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position + Vector3.up * 1, 0.5f, Vector3.down, out hit, 0.6f);
    }
}
