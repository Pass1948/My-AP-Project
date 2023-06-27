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
        Move();
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    void Move()
    {
        // Mathf.Lerp() 애니메이션에 부드러운 전환을 넣기위한 정밀작업
        if (moveDir.magnitude == 0)
        {
            curSpeed = Mathf.Lerp(curSpeed, 0, 0.5f);
            animator.SetFloat("MoveSpeed", curSpeed);
            isRun = false;
            return;
        }
        else if (isRun)
        {
            curSpeed = runSpeed;
            animator.SetBool("IsRun", true);
        }
        else
        {
            curSpeed = walkSpeed;
            animator.SetBool("IsRun", false);
        }


        Vector3 vecFor = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 vecRig = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;

        controller.Move(vecFor * moveDir.z * curSpeed * Time.deltaTime);
        controller.Move(vecRig * moveDir.x * curSpeed * Time.deltaTime);
        animator.SetFloat("MoveSpeed", curSpeed);

        Quaternion lookRotation = Quaternion.LookRotation(vecFor * moveDir.z + vecRig * moveDir.x);
        transform.rotation = Quaternion.Lerp(lookRotation, transform.rotation, 0.1f);
    }

    private void OnRun(InputValue value)
    {
            isRun = value.isPressed;
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
        ySpeed = jumpPower;
    }

    private void OnJump(InputValue value)
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
