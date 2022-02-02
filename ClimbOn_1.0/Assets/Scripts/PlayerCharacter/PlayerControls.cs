// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerCharacter/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""e23465a0-51b6-4fd4-bc57-67b898e3e2e5"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""caf96dba-5abd-4116-9320-45728e2e3445"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""10d69b32-dc84-483f-a160-3c28d9fee532"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""a50a79ad-2b42-442c-8a95-4c68a3ea6da6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""SprintRelease"",
                    ""type"": ""Button"",
                    ""id"": ""89a68841-62dc-4676-8947-93657ceff8b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""GrappleShoot"",
                    ""type"": ""Button"",
                    ""id"": ""7fdd21c5-ab3d-44df-b5ce-34fc1dfc4f4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""LegLeft"",
                    ""type"": ""Button"",
                    ""id"": ""3ef4c516-9e7c-4fe1-8706-6e3e33468ee8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""LegRight"",
                    ""type"": ""Button"",
                    ""id"": ""4b98130a-5fc7-4711-8266-b73354ae3e7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""55e3f232-9ba7-45cc-8259-5817ebbc6e93"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""226a34a8-ce7b-42fd-9d82-1e97864b4f46"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reach"",
                    ""type"": ""Button"",
                    ""id"": ""27ef7427-fe71-4ca0-b7f9-a38df57a2b69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7c270392-d733-45d4-9a74-9896bee0b59a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93831843-49ca-4263-84b2-c3afda268c93"",
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
                    ""id"": ""590da265-ed56-44a2-a64a-e751a9cd7df6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09a24aff-107e-4398-86f0-a7267a225494"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd2afb8f-e8b5-4233-82f8-3ae8a5d7d1a3"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23007ea9-97c9-4487-a7b1-a080798103df"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""550ae9da-1e57-4477-ade0-b80def9cbf63"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrappleShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e03439b6-c7d5-4d62-aea2-3039449a8346"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrappleShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91667949-4a27-4896-9fdd-84b7cc4e3422"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LegLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7907ebf-75a7-4594-9ac6-f5831d51380e"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LegLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db7a0508-f39b-4b1b-8baa-9457df7cd8be"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LegRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1713c32-2ea2-4fa7-bfd9-2130c10c941a"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LegRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f56e35a7-18f6-4951-a893-cc679e361da4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""f037ceff-5e7f-4d6e-bdb5-19d727fa7780"",
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
                    ""id"": ""67ef37cd-1f73-4420-8959-f7850f3cb0b2"",
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
                    ""id"": ""cc9c540d-ca90-4136-a8a8-92f16dd81f79"",
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
                    ""id"": ""8d5f1f81-1729-413e-aeec-96ee361d88c9"",
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
                    ""id"": ""4f078c7e-d35c-4636-a4e7-7ed787b1e45b"",
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
                    ""id"": ""9e5f45f3-7968-4115-80e7-112d8db252de"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71414fe9-0784-40a3-ab77-4362adcf475a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reach"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5569debe-bd26-4365-ac83-1a30a3e19924"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Drop = m_Gameplay.FindAction("Drop", throwIfNotFound: true);
        m_Gameplay_Sprint = m_Gameplay.FindAction("Sprint", throwIfNotFound: true);
        m_Gameplay_SprintRelease = m_Gameplay.FindAction("SprintRelease", throwIfNotFound: true);
        m_Gameplay_GrappleShoot = m_Gameplay.FindAction("GrappleShoot", throwIfNotFound: true);
        m_Gameplay_LegLeft = m_Gameplay.FindAction("LegLeft", throwIfNotFound: true);
        m_Gameplay_LegRight = m_Gameplay.FindAction("LegRight", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Camera = m_Gameplay.FindAction("Camera", throwIfNotFound: true);
        m_Gameplay_Reach = m_Gameplay.FindAction("Reach", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Drop;
    private readonly InputAction m_Gameplay_Sprint;
    private readonly InputAction m_Gameplay_SprintRelease;
    private readonly InputAction m_Gameplay_GrappleShoot;
    private readonly InputAction m_Gameplay_LegLeft;
    private readonly InputAction m_Gameplay_LegRight;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Camera;
    private readonly InputAction m_Gameplay_Reach;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Drop => m_Wrapper.m_Gameplay_Drop;
        public InputAction @Sprint => m_Wrapper.m_Gameplay_Sprint;
        public InputAction @SprintRelease => m_Wrapper.m_Gameplay_SprintRelease;
        public InputAction @GrappleShoot => m_Wrapper.m_Gameplay_GrappleShoot;
        public InputAction @LegLeft => m_Wrapper.m_Gameplay_LegLeft;
        public InputAction @LegRight => m_Wrapper.m_Gameplay_LegRight;
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Camera => m_Wrapper.m_Gameplay_Camera;
        public InputAction @Reach => m_Wrapper.m_Gameplay_Reach;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Drop.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @SprintRelease.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprintRelease;
                @SprintRelease.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprintRelease;
                @SprintRelease.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprintRelease;
                @GrappleShoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleShoot;
                @GrappleShoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleShoot;
                @GrappleShoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrappleShoot;
                @LegLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLegLeft;
                @LegLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLegLeft;
                @LegLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLegLeft;
                @LegRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLegRight;
                @LegRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLegRight;
                @LegRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLegRight;
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @Reach.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReach;
                @Reach.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReach;
                @Reach.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReach;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @SprintRelease.started += instance.OnSprintRelease;
                @SprintRelease.performed += instance.OnSprintRelease;
                @SprintRelease.canceled += instance.OnSprintRelease;
                @GrappleShoot.started += instance.OnGrappleShoot;
                @GrappleShoot.performed += instance.OnGrappleShoot;
                @GrappleShoot.canceled += instance.OnGrappleShoot;
                @LegLeft.started += instance.OnLegLeft;
                @LegLeft.performed += instance.OnLegLeft;
                @LegLeft.canceled += instance.OnLegLeft;
                @LegRight.started += instance.OnLegRight;
                @LegRight.performed += instance.OnLegRight;
                @LegRight.canceled += instance.OnLegRight;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Reach.started += instance.OnReach;
                @Reach.performed += instance.OnReach;
                @Reach.canceled += instance.OnReach;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnSprintRelease(InputAction.CallbackContext context);
        void OnGrappleShoot(InputAction.CallbackContext context);
        void OnLegLeft(InputAction.CallbackContext context);
        void OnLegRight(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnReach(InputAction.CallbackContext context);
    }
}
