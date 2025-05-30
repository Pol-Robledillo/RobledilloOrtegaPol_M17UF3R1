//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Player/Player.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Player: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""24105431-9490-4724-95da-1ae3eff687c4"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d57aba1b-f709-47d5-9ac3-76d3cad31b31"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""b0904740-b2d4-40da-9eb9-0b8dd6dbf451"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""44b88e81-5db8-4c8d-869b-0d86682f8f03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleWalk"",
                    ""type"": ""Button"",
                    ""id"": ""4bc99ae0-c5a8-4a16-a87d-5fc0ee557fc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""1f909c92-97cb-4c2e-b5d7-75242867d0d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""b90887bb-53d8-4e28-bb29-026fe6a4fc3d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7d662f03-d145-4733-a50b-e493fb237529"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""50aa14d5-448d-4098-b9c2-126dffaf275d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""762b9e6d-5bea-4258-9ce6-73ac781fc150"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""740f4edc-c926-4442-8033-1ed09e69b7ea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c8f1ff72-6289-4a74-94b1-54b74678f6b9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""17d6997d-1b4a-4982-9675-9cb64960b284"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f169aca7-bdb5-4f05-8045-bab09d777597"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84112bbd-d29f-4ba1-abd1-a847857bad00"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleWalk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f999f98-2045-458f-b7b8-0e614fb7575d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a453513-c406-4622-b5a2-248494bb8b22"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Shoot"",
            ""id"": ""b77e7eee-04b3-4291-9d85-244c8b1144a5"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""3bb9deb4-67c6-4185-85bf-cb231405b356"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""151f7209-1ef4-408a-9355-c643b95d903e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""025d0f57-3ffe-404e-a82d-d822ee5c97ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""401ab1ab-87b1-4b89-8819-7b55ec64f3fb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8266a451-2da8-4776-9f77-222d5ec42002"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab65092b-7710-473b-880d-9a8d683d4f6b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""WeaponSwap"",
            ""id"": ""3fb88a6d-ee3f-4ca2-a2d7-e7e5306edfc1"",
            ""actions"": [
                {
                    ""name"": ""SwapShotgun"",
                    ""type"": ""Button"",
                    ""id"": ""106e33bc-2822-4e46-b556-77bafd2fe56c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwapBurst"",
                    ""type"": ""Button"",
                    ""id"": ""598b72ad-aefd-4303-86c7-ee0e47ba55eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwapAuto"",
                    ""type"": ""Button"",
                    ""id"": ""a007d768-936a-44d0-9c5a-fe73c295951c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""628f9a6c-289c-4313-b68f-36cc249d5489"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapShotgun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0870a02b-63da-40aa-bcd1-5cca11f1c396"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapBurst"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12d43862-e001-4c78-999e-3dcfc913f2ad"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapAuto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Other"",
            ""id"": ""a06ebeb1-1da5-4407-85ef-1639bdc2e01d"",
            ""actions"": [
                {
                    ""name"": ""Emote"",
                    ""type"": ""Button"",
                    ""id"": ""fb395d2b-7db6-4c39-b9b2-f821d5bb08a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwapToFirstPerson"",
                    ""type"": ""Button"",
                    ""id"": ""0ca56ece-eb42-4896-af68-2cf2c4ff455d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwapToThirdPerson"",
                    ""type"": ""Button"",
                    ""id"": ""56f509e1-558d-42b7-b7bd-7a49ddfc5cad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""48a16193-78c3-40f8-80b0-946b1f7cb7a5"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Emote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75caec31-ee5a-40c5-8185-12119bb7e5d4"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapToFirstPerson"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3377a75e-529a-4d18-bdce-f8b1762498b4"",
                    ""path"": ""<Keyboard>/f2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapToThirdPerson"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Movement = m_Movement.FindAction("Movement", throwIfNotFound: true);
        m_Movement_Crouch = m_Movement.FindAction("Crouch", throwIfNotFound: true);
        m_Movement_Sprint = m_Movement.FindAction("Sprint", throwIfNotFound: true);
        m_Movement_ToggleWalk = m_Movement.FindAction("ToggleWalk", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_Look = m_Movement.FindAction("Look", throwIfNotFound: true);
        // Shoot
        m_Shoot = asset.FindActionMap("Shoot", throwIfNotFound: true);
        m_Shoot_Shoot = m_Shoot.FindAction("Shoot", throwIfNotFound: true);
        m_Shoot_Aim = m_Shoot.FindAction("Aim", throwIfNotFound: true);
        m_Shoot_Reload = m_Shoot.FindAction("Reload", throwIfNotFound: true);
        // WeaponSwap
        m_WeaponSwap = asset.FindActionMap("WeaponSwap", throwIfNotFound: true);
        m_WeaponSwap_SwapShotgun = m_WeaponSwap.FindAction("SwapShotgun", throwIfNotFound: true);
        m_WeaponSwap_SwapBurst = m_WeaponSwap.FindAction("SwapBurst", throwIfNotFound: true);
        m_WeaponSwap_SwapAuto = m_WeaponSwap.FindAction("SwapAuto", throwIfNotFound: true);
        // Other
        m_Other = asset.FindActionMap("Other", throwIfNotFound: true);
        m_Other_Emote = m_Other.FindAction("Emote", throwIfNotFound: true);
        m_Other_SwapToFirstPerson = m_Other.FindAction("SwapToFirstPerson", throwIfNotFound: true);
        m_Other_SwapToThirdPerson = m_Other.FindAction("SwapToThirdPerson", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_Movement;
    private readonly InputAction m_Movement_Crouch;
    private readonly InputAction m_Movement_Sprint;
    private readonly InputAction m_Movement_ToggleWalk;
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_Look;
    public struct MovementActions
    {
        private @Player m_Wrapper;
        public MovementActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Movement_Movement;
        public InputAction @Crouch => m_Wrapper.m_Movement_Crouch;
        public InputAction @Sprint => m_Wrapper.m_Movement_Sprint;
        public InputAction @ToggleWalk => m_Wrapper.m_Movement_ToggleWalk;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @Look => m_Wrapper.m_Movement_Look;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @ToggleWalk.started += instance.OnToggleWalk;
            @ToggleWalk.performed += instance.OnToggleWalk;
            @ToggleWalk.canceled += instance.OnToggleWalk;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @ToggleWalk.started -= instance.OnToggleWalk;
            @ToggleWalk.performed -= instance.OnToggleWalk;
            @ToggleWalk.canceled -= instance.OnToggleWalk;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Shoot
    private readonly InputActionMap m_Shoot;
    private List<IShootActions> m_ShootActionsCallbackInterfaces = new List<IShootActions>();
    private readonly InputAction m_Shoot_Shoot;
    private readonly InputAction m_Shoot_Aim;
    private readonly InputAction m_Shoot_Reload;
    public struct ShootActions
    {
        private @Player m_Wrapper;
        public ShootActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Shoot_Shoot;
        public InputAction @Aim => m_Wrapper.m_Shoot_Aim;
        public InputAction @Reload => m_Wrapper.m_Shoot_Reload;
        public InputActionMap Get() { return m_Wrapper.m_Shoot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShootActions set) { return set.Get(); }
        public void AddCallbacks(IShootActions instance)
        {
            if (instance == null || m_Wrapper.m_ShootActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ShootActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Aim.started += instance.OnAim;
            @Aim.performed += instance.OnAim;
            @Aim.canceled += instance.OnAim;
            @Reload.started += instance.OnReload;
            @Reload.performed += instance.OnReload;
            @Reload.canceled += instance.OnReload;
        }

        private void UnregisterCallbacks(IShootActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Aim.started -= instance.OnAim;
            @Aim.performed -= instance.OnAim;
            @Aim.canceled -= instance.OnAim;
            @Reload.started -= instance.OnReload;
            @Reload.performed -= instance.OnReload;
            @Reload.canceled -= instance.OnReload;
        }

        public void RemoveCallbacks(IShootActions instance)
        {
            if (m_Wrapper.m_ShootActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IShootActions instance)
        {
            foreach (var item in m_Wrapper.m_ShootActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ShootActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ShootActions @Shoot => new ShootActions(this);

    // WeaponSwap
    private readonly InputActionMap m_WeaponSwap;
    private List<IWeaponSwapActions> m_WeaponSwapActionsCallbackInterfaces = new List<IWeaponSwapActions>();
    private readonly InputAction m_WeaponSwap_SwapShotgun;
    private readonly InputAction m_WeaponSwap_SwapBurst;
    private readonly InputAction m_WeaponSwap_SwapAuto;
    public struct WeaponSwapActions
    {
        private @Player m_Wrapper;
        public WeaponSwapActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @SwapShotgun => m_Wrapper.m_WeaponSwap_SwapShotgun;
        public InputAction @SwapBurst => m_Wrapper.m_WeaponSwap_SwapBurst;
        public InputAction @SwapAuto => m_Wrapper.m_WeaponSwap_SwapAuto;
        public InputActionMap Get() { return m_Wrapper.m_WeaponSwap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponSwapActions set) { return set.Get(); }
        public void AddCallbacks(IWeaponSwapActions instance)
        {
            if (instance == null || m_Wrapper.m_WeaponSwapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WeaponSwapActionsCallbackInterfaces.Add(instance);
            @SwapShotgun.started += instance.OnSwapShotgun;
            @SwapShotgun.performed += instance.OnSwapShotgun;
            @SwapShotgun.canceled += instance.OnSwapShotgun;
            @SwapBurst.started += instance.OnSwapBurst;
            @SwapBurst.performed += instance.OnSwapBurst;
            @SwapBurst.canceled += instance.OnSwapBurst;
            @SwapAuto.started += instance.OnSwapAuto;
            @SwapAuto.performed += instance.OnSwapAuto;
            @SwapAuto.canceled += instance.OnSwapAuto;
        }

        private void UnregisterCallbacks(IWeaponSwapActions instance)
        {
            @SwapShotgun.started -= instance.OnSwapShotgun;
            @SwapShotgun.performed -= instance.OnSwapShotgun;
            @SwapShotgun.canceled -= instance.OnSwapShotgun;
            @SwapBurst.started -= instance.OnSwapBurst;
            @SwapBurst.performed -= instance.OnSwapBurst;
            @SwapBurst.canceled -= instance.OnSwapBurst;
            @SwapAuto.started -= instance.OnSwapAuto;
            @SwapAuto.performed -= instance.OnSwapAuto;
            @SwapAuto.canceled -= instance.OnSwapAuto;
        }

        public void RemoveCallbacks(IWeaponSwapActions instance)
        {
            if (m_Wrapper.m_WeaponSwapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWeaponSwapActions instance)
        {
            foreach (var item in m_Wrapper.m_WeaponSwapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WeaponSwapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WeaponSwapActions @WeaponSwap => new WeaponSwapActions(this);

    // Other
    private readonly InputActionMap m_Other;
    private List<IOtherActions> m_OtherActionsCallbackInterfaces = new List<IOtherActions>();
    private readonly InputAction m_Other_Emote;
    private readonly InputAction m_Other_SwapToFirstPerson;
    private readonly InputAction m_Other_SwapToThirdPerson;
    public struct OtherActions
    {
        private @Player m_Wrapper;
        public OtherActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Emote => m_Wrapper.m_Other_Emote;
        public InputAction @SwapToFirstPerson => m_Wrapper.m_Other_SwapToFirstPerson;
        public InputAction @SwapToThirdPerson => m_Wrapper.m_Other_SwapToThirdPerson;
        public InputActionMap Get() { return m_Wrapper.m_Other; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OtherActions set) { return set.Get(); }
        public void AddCallbacks(IOtherActions instance)
        {
            if (instance == null || m_Wrapper.m_OtherActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_OtherActionsCallbackInterfaces.Add(instance);
            @Emote.started += instance.OnEmote;
            @Emote.performed += instance.OnEmote;
            @Emote.canceled += instance.OnEmote;
            @SwapToFirstPerson.started += instance.OnSwapToFirstPerson;
            @SwapToFirstPerson.performed += instance.OnSwapToFirstPerson;
            @SwapToFirstPerson.canceled += instance.OnSwapToFirstPerson;
            @SwapToThirdPerson.started += instance.OnSwapToThirdPerson;
            @SwapToThirdPerson.performed += instance.OnSwapToThirdPerson;
            @SwapToThirdPerson.canceled += instance.OnSwapToThirdPerson;
        }

        private void UnregisterCallbacks(IOtherActions instance)
        {
            @Emote.started -= instance.OnEmote;
            @Emote.performed -= instance.OnEmote;
            @Emote.canceled -= instance.OnEmote;
            @SwapToFirstPerson.started -= instance.OnSwapToFirstPerson;
            @SwapToFirstPerson.performed -= instance.OnSwapToFirstPerson;
            @SwapToFirstPerson.canceled -= instance.OnSwapToFirstPerson;
            @SwapToThirdPerson.started -= instance.OnSwapToThirdPerson;
            @SwapToThirdPerson.performed -= instance.OnSwapToThirdPerson;
            @SwapToThirdPerson.canceled -= instance.OnSwapToThirdPerson;
        }

        public void RemoveCallbacks(IOtherActions instance)
        {
            if (m_Wrapper.m_OtherActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IOtherActions instance)
        {
            foreach (var item in m_Wrapper.m_OtherActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_OtherActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public OtherActions @Other => new OtherActions(this);
    public interface IMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnToggleWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IShootActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
    }
    public interface IWeaponSwapActions
    {
        void OnSwapShotgun(InputAction.CallbackContext context);
        void OnSwapBurst(InputAction.CallbackContext context);
        void OnSwapAuto(InputAction.CallbackContext context);
    }
    public interface IOtherActions
    {
        void OnEmote(InputAction.CallbackContext context);
        void OnSwapToFirstPerson(InputAction.CallbackContext context);
        void OnSwapToThirdPerson(InputAction.CallbackContext context);
    }
}
