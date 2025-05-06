using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using static Player;

public class NewPlayerController : MonoBehaviour, IMovementActions, IShootActions, IWeaponSwapActions, IOtherActions
{
    private static NewPlayerController instance;
    private Player playerActions;
    public Rigidbody rb;
    public List<GameObject> cameras;
    public GameObject activeCamera;
    public List<GameObject> weapons;
    public GameObject weapon;
    public Animator animator;
    public GameObject mesh;

    public float shootCooldown = 0.5f;
    public bool shootInCooldown = false;
    public bool hasBurstWeapon = false;
    public bool hasAutoWeapon = false;
    public bool isWaiting = true;
    private bool isWalking = false;
    private bool isSprinting = false;
    private bool isCrouching = false;
    private bool isShotgun = true;
    private bool isBurst = false;
    private bool isAuto = false;
    private bool firstPerson = false;

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

    private float transitionSpeed = 2f;
    private float targetWeightLayer1 = 0f;
    private float targetWeightLayer2 = 0f;
    private bool isTransitioning = false;

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

        yRotation = Mathf.Clamp(yRotation, -60f, 60f);

        if (firstPerson)
        {
            mesh.transform.rotation = Quaternion.Euler(yRotation, xRotation, 0f);
        }
        transform.rotation = Quaternion.Euler(0f, xRotation, 0f);
        followObject.transform.rotation = Quaternion.Euler(yRotation, xRotation, 0f);
    }
    private void Move()
    {
        float xValue = (movementInput.x > 0.7 && movementInput.x < 0.8f) || (movementInput.x < -0.7f && movementInput.x > -0.8f) ? 0 : movementInput.x;
        float yValue = movementInput.y > 0 ? isSprinting ? 1.5f : isWalking ? 0.5f : 1 : movementInput.y;
        animator.SetFloat("x", xValue);
        animator.SetFloat("y", yValue);
        Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveSpeed = movementInput.y > 0 ? isSprinting ? sprintSpeed : isWalking || isCrouching ? walkSpeed : runSpeed : walkSpeed;
        moveDirection *= moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
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
        if (context.started)
        {
            animator.SetBool("moving", true);
        }
        else if (context.canceled)
        {
            animator.SetBool("moving", false);
        }
    }
    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isCrouching = true;
            targetWeightLayer1 = 0f;
            targetWeightLayer2 = 1f;
            if (!isTransitioning) StartCoroutine(SmoothWeightTransition());
        }
        else if (context.canceled)
        {
            isCrouching = false;
            targetWeightLayer1 = 1f;
            targetWeightLayer2 = 0f;
            if (!isTransitioning) StartCoroutine(SmoothWeightTransition());
        }
    }
    private IEnumerator SmoothWeightTransition()
    {
        isTransitioning = true;
        float currentWeight1 = animator.GetLayerWeight(1);
        float currentWeight2 = animator.GetLayerWeight(2);
        
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * transitionSpeed;
            animator.SetLayerWeight(1, Mathf.Lerp(currentWeight1, targetWeightLayer1, elapsedTime));
            animator.SetLayerWeight(2, Mathf.Lerp(currentWeight2, targetWeightLayer2, elapsedTime));
            yield return null;
        }

        animator.SetLayerWeight(1, targetWeightLayer1);
        animator.SetLayerWeight(2, targetWeightLayer2);
        isTransitioning = false;
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (movementInput.x > 0.2)
        {
            animator.SetBool("sprinting", true);
            animator.SetTrigger("sprint");
        }
        if (context.started && !isCrouching)
        {
            isSprinting = true;
        }
        else if (context.canceled)
        {
            animator.SetBool("sprinting", false);
            isSprinting = false;
        }
    }
    public void OnToggleWalk(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isWalking = !isWalking;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && isWaiting && !isCrouching)
        {
            isWaiting = false;
            StartCoroutine(PerformJump());
        }
    }
    public IEnumerator PerformJump()
    {
        animator.SetTrigger("jump");
        yield return new WaitForSeconds(0.1f);
        rb.AddForce(Vector3.up * 30f, ForceMode.Impulse);
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            yield return null;
        }
        isWaiting = true;
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (isAuto)
        {
            if (context.started && isWaiting && !shootInCooldown)
            {
                isWaiting = false;
                animator.SetBool("shooting", true);
            } if (context.canceled)
            {
                StartCoroutine(ShootCooldown());
                animator.SetBool("shooting", false);
                isWaiting = true;
            }
        }
        else
        {
            if (context.started && isWaiting && !shootInCooldown)
            {
                isWaiting = false;
                animator.SetTrigger("shoot");
                StartCoroutine(ShootCooldown());
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
    public IEnumerator ShootCooldown()
    {
        shootInCooldown = true;
        yield return new WaitForSeconds(shootCooldown);
        shootInCooldown = false;
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
        if (context.started && weapon != weapons[0])
        {
            isShotgun = true;
            isBurst = false;
            isAuto = false;
            foreach (GameObject w in weapons)
            {
                w.SetActive(false);
            }
            weapon = weapons[0];
            weapon.SetActive(true);
            animator.SetBool("singleShot", isShotgun);
            animator.SetBool("burstShot", isBurst);
            animator.SetBool("autoShot", isAuto);
        }
    }
    public void OnSwapBurst(InputAction.CallbackContext context)
    {
        if (context.started && hasBurstWeapon && weapon != weapons[1])
        {
            isShotgun = false;
            isBurst = true;
            isAuto = false;
            foreach (GameObject w in weapons)
            {
                w.SetActive(false);
            }
            weapon = weapons[1];
            weapon.SetActive(true);
            animator.SetBool("singleShot", isShotgun);
            animator.SetBool("burstShot", isBurst);
            animator.SetBool("autoShot", isAuto);
        }
    }
    public void OnSwapAuto(InputAction.CallbackContext context)
    {
        if (context.started && hasAutoWeapon && weapon != weapons[2])
        {
            isShotgun = false;
            isBurst = false;
            isAuto = true;
            foreach (GameObject w in weapons)
            {
                w.SetActive(false);
            }
            weapon = weapons[2];
            weapon.SetActive(true);
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
        animator.SetLayerWeight(1, 0);
        animator.SetTrigger("emote");
        yield return new WaitForSeconds(1f);
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Emote"))
        {
            yield return null;
        }
        animator.SetLayerWeight(1, 1);
        weapon.SetActive(true);
        isWaiting = true;
    }
    public void OnSwapToFirstPerson(InputAction.CallbackContext context)
    {
        if (context.started && !firstPerson)
        {
            firstPerson = true;
            if (activeCamera != cameras[1])
            {
                cameras[1].GetComponent<CinemachineVirtualCamera>().Priority = 10;
                cameras[0].GetComponent<CinemachineVirtualCamera>().Priority = 1;
                activeCamera = cameras[1];
            }
        }
    }
    public void OnSwapToThirdPerson(InputAction.CallbackContext context)
    {
        if (context.started && firstPerson)
        {
            mesh.transform.localRotation = Quaternion.Euler(0f, mesh.transform.localRotation.y, 0f);
            firstPerson = false;
            if (activeCamera != cameras[0])
            {
                cameras[0].GetComponent<CinemachineVirtualCamera>().Priority = 10;
                cameras[1].GetComponent<CinemachineVirtualCamera>().Priority = 1;
                activeCamera = cameras[0];
            }
        }
    }
}
