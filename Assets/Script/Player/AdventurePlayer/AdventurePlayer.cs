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
    private float moveSpeed;
    private float ySpeed = 0;
    private float curSpeed;
    private bool isWalking;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        moveRoutine = StartCoroutine(MoveRoutine());
        jumpRoutine = StartCoroutine(JumpRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(moveRoutine);
        StopCoroutine(jumpRoutine);
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        //Move();
        //GroundCheck();
    }

    Coroutine moveRoutine;
    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            if (moveDir.sqrMagnitude <= 0)
            {
                curSpeed = Mathf.Lerp(curSpeed, 0, 0.1f);
                //animator.SetFloat("MoveSpeed", curSpeed);
                yield return null;
                continue;
            }

            Vector3 fowardVec = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
            Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;

            if (isWalking)
            {
                curSpeed = Mathf.Lerp(curSpeed, walkSpeed, 0.1f);
            }
            else
            {
                curSpeed = Mathf.Lerp(curSpeed, runSpeed, 0.1f);
            }

            controller.Move(fowardVec * moveDir.z * curSpeed * Time.deltaTime);
            controller.Move(rightVec * moveDir.x * curSpeed * Time.deltaTime);
            //animator.SetFloat("MoveSpeed", curSpeed);

            Quaternion lookRotation = Quaternion.LookRotation(fowardVec * moveDir.z + rightVec * moveDir.x);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.2f);

        }
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

        Vector3 vecFor = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 vecRig = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;

        controller.Move(vecFor * moveDir.z * curSpeed * Time.deltaTime);
        controller.Move(vecRig * moveDir.x * curSpeed * Time.deltaTime);
        animator.SetFloat("MoveSpeed", curSpeed);

        Quaternion lookRotation = Quaternion.LookRotation(vecFor * moveDir.z + vecRig * moveDir.x);
        transform.rotation = Quaternion.Lerp(lookRotation, transform.rotation, 0.1f);


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

    Coroutine jumpRoutine;
    private IEnumerator JumpRoutine()
    {
        while (true)
        {
            ySpeed += Physics.gravity.y * Time.deltaTime;

            if (GroundCheck() && ySpeed < 0)
                ySpeed = -1;

            controller.Move(Vector3.up * ySpeed * Time.deltaTime);
            yield return null;
        }
    }
    void Jump()
    {
        //rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    void OnJump(InputValue value)
    {

        if (GroundCheck())
            ySpeed = jumpPower; 
    }

    private bool GroundCheck()
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position + Vector3.up * 1, 0.5f, Vector3.down, out hit, 0.6f);
    }
}
