using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using static Player;

public class PlayerController : MonoBehaviour, IMovementActions, IShootActions, IWeaponSwapActions, IOtherActions
{
    private static PlayerController instance;
    private Player playerActions;
    public Rigidbody rb;
    public List<GameObject> cameras;
    public GameObject activeCamera;
    public GameObject weapon;
    public Animator animator;

    public bool isWaiting = true;
    private bool isWalking = false;
    private bool isSprinting = false;
    private bool canSprint = false;
    private bool isShotgun = true;
    private bool isBurst = false;
    private bool isAuto = false;

    private Vector2 movementInput;
    private Vector2 lookInput;

    private float moveSpeed = 10f;
    private float walkSpeed = 5f;
    private float runSpeed = 10f;
    private float sprintSpeed = 15f;

    public GameObject followObject;
    private float cameraSensitivity = 1f;
    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerActions = new Player();
        playerActions.Movement.SetCallbacks(this);
        playerActions.Shoot.SetCallbacks(this);
        playerActions.WeaponSwap.SetCallbacks(this);
        playerActions.Other.SetCallbacks(this);
        activeCamera = cameras[0];
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Look();
    }
    private void Look()
    {
        xRotation += lookInput.x * cameraSensitivity;
        yRotation -= lookInput.y * cameraSensitivity;

        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(0f, xRotation, 0f);
        followObject.transform.rotation = Quaternion.Euler(yRotation, xRotation, 0f);
    }
    private void Move()
    {
        if (isWaiting)
        {
            Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;
            rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
            if (movementInput.y > 0)
            {
                animator.SetBool("movingFront", true);
                animator.SetBool("movingBack", false);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", false);
                canSprint = true;
            }
            else if (movementInput.y < 0)
            {
                animator.SetBool("movingFront", false);
                animator.SetBool("movingBack", true);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", false);
                canSprint = false;
            }
            else if (movementInput.x > 0)
            {
                animator.SetBool("movingFront", false);
                animator.SetBool("movingBack", false);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", true);
                canSprint = false;
            }
            else if (movementInput.x < 0)
            {
                animator.SetBool("movingFront", false);
                animator.SetBool("movingBack", false);
                animator.SetBool("movingLeft", true);
                animator.SetBool("movingRight", false);
                canSprint = false;
            }
            else
            {
                animator.SetBool("movingFront", false);
                animator.SetBool("movingBack", false);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", false);
                canSprint = true;
            }
        }
        else
        {
            animator.SetBool("movingFront", false);
            animator.SetBool("movingBack", false);
            animator.SetBool("movingLeft", false);
            animator.SetBool("movingRight", false);
            rb.velocity = Vector3.zero;
            canSprint = true;
        }
    }
    private void OnEnable()
    {
        playerActions.Enable();
    }
    private void OnDisable()
    {
        playerActions.Disable();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetBool("crouching", true);
        }
        else if (context.canceled)
        {
            animator.SetBool("crouching", false);
        }
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started && canSprint)
        {
            animator.SetBool("sprint", true);
            isSprinting = true;
        }
        else if (context.canceled)
        {
            animator.SetBool("sprint", false);
            isSprinting = false;
        }
        moveSpeed = isSprinting ? sprintSpeed : isWalking ? walkSpeed : runSpeed;
    }
    public void OnToggleWalk(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetBool("walk", !isWalking);
            isWalking = !isWalking;
        }
        moveSpeed = isSprinting ? sprintSpeed : isWalking ? walkSpeed : runSpeed;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && isWaiting)
        {
            isWaiting = false;
            animator.SetTrigger("jump");
        }
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (isAuto)
        {
            if (context.started && isWaiting)
            {
                isWaiting = false;
                animator.SetBool("shooting", true);
            } if (context.canceled)
            {
                animator.SetBool("shooting", false);
                isWaiting = true;
            }
        }
        else
        {
            if (context.started && isWaiting)
            {
                isWaiting = false;
                animator.SetTrigger("shoot");
                StartCoroutine(PerformShooting());
            }
        }
    }
    public IEnumerator PerformShooting()
    {
        yield return new WaitForSeconds(0.1f);
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot_SingleShot_AR") || animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot_BurstShot_AR"))
        {
            yield return null;
        }
        isWaiting = true;
    }
    public void OnAim(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger("aim");
            animator.SetBool("aiming", true);
        }
        else if (context.canceled)
        {
            animator.SetBool("aiming", false);
        }
    }
    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.started && isWaiting)
        {
            isWaiting = false;
            animator.SetTrigger("reload");
        }
    }
    public void OnSwapShotgun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isShotgun = true;
            isBurst = false;
            isAuto = false;
            animator.SetBool("singleShot", isShotgun);
            animator.SetBool("burstShot", isBurst);
            animator.SetBool("autoShot", isAuto);
        }
    }
    public void OnSwapBurst(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isShotgun = false;
            isBurst = true;
            isAuto = false;
            animator.SetBool("singleShot", isShotgun);
            animator.SetBool("burstShot", isBurst);
            animator.SetBool("autoShot", isAuto);
        }
    }
    public void OnSwapAuto(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isShotgun = false;
            isBurst = false;
            isAuto = true;
            animator.SetBool("singleShot", isShotgun);
            animator.SetBool("burstShot", isBurst);
            animator.SetBool("autoShot", isAuto);
        }
    }
    public void OnEmote(InputAction.CallbackContext context)
    {
        if (context.started && isWaiting)
        {
            isWaiting = false;
            weapon.SetActive(false);
            StartCoroutine(PerformEmote());
        }
    }
    public IEnumerator PerformEmote()
    {
        animator.SetTrigger("emote");
        yield return new WaitForSeconds(1f);
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Emote"))
        {
            yield return null;
        }
        weapon.SetActive(true);
        isWaiting = true;
    }
    public void OnSwapToFirstPerson(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (activeCamera != cameras[0])
            {
                activeCamera.SetActive(false);
                activeCamera = cameras[0];
                activeCamera.SetActive(true);
            }
        }
    }
    public void OnSwapToThirdPerson(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (activeCamera != cameras[1])
            {
                activeCamera.SetActive(false);
                activeCamera = cameras[1];
                activeCamera.SetActive(true);
            }
        }
    }
}
