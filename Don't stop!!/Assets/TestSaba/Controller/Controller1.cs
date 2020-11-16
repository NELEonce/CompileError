// GENERATED AUTOMATICALLY FROM 'Assets/TestSaba/Controller/Controller1.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller1 : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller1()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller1"",
    ""maps"": [
        {
            ""name"": ""TestPlayer"",
            ""id"": ""ad33ea5c-de19-4796-b822-5e8ae678fa01"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2b4a6446-0e09-41b8-bae0-3108b7de5a82"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Direction"",
                    ""type"": ""Value"",
                    ""id"": ""fe43cf06-fe95-4b03-8f77-b6b15f130967"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""4b88180b-3470-4fa5-acf1-fac478b4dc84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WpChange"",
                    ""type"": ""Button"",
                    ""id"": ""d8296984-ace3-4697-a1dc-3e4e7e2a6d3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""64fcfa2d-364c-4b3b-b8e2-1e565dabdb75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""696f2d51-3cc0-4f76-98f7-dfcd4d027dce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""b8b05440-eddb-4a07-835a-3f68f0ecf441"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""d5550bbd-ab3b-406f-bfe5-f45003961f81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a2918471-d167-4c72-a682-96e6d6565503"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1b922f45-282e-423e-972d-ebf122f1e61a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6daad400-1d4b-4f4f-bc46-0beb1533513d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""02ab080c-166e-435c-b885-c1bcdd31303e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a1387e6d-c5bb-41f9-a517-e55834529752"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f797a95f-7407-47d8-8688-05645efc1fa1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0525385-0684-4a8d-aa60-015398996de1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfa2bfe9-71e5-40de-b220-ca86cf396f8f"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c4a55a7-9003-4aa6-b1b0-8235fdd9c412"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fa2809c-9782-40ed-ab57-e82856a1cd4b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""WpChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""395b3597-8fdc-464a-a449-23d764903432"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f3d27a4-cf4b-4fe4-b221-108de1200859"",
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
                    ""id"": ""78094a71-0bdf-47e3-bcb0-24d9de1051ce"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86a7064a-07dd-40bd-8e3e-96fb4ffe3cab"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d6cfa85-ee1d-401f-bc51-d505b4a2f5c3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ee58c15-f8d2-4aa5-a625-5fa34e43052c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df13aca1-0faa-4669-b187-0dba7a86a0d6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eebcde24-4d40-48d7-9a4f-ba3301507551"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e6d382b-cc5e-4b72-9fda-9329b1677651"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69772b5b-8c8f-4ec9-8d76-97b94e168002"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7851f7ce-7996-4f80-b0c9-856157fec28a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Option"",
<<<<<<< HEAD
            ""id"": ""4ee6ace3-2217-46da-8cf9-041d28a9f2a0"",
=======
            ""id"": ""ad279b73-ba85-4df5-97d1-091c656d6eb0"",
>>>>>>> 3536063ee738a77ec813195ce14169c204b3dcc5
            ""actions"": [
                {
                    ""name"": ""Open"",
                    ""type"": ""Button"",
<<<<<<< HEAD
                    ""id"": ""0330cea3-849f-459a-9fa9-aff71d37cec4"",
=======
                    ""id"": ""38760103-8c34-4877-bcc6-9f8f6f591913"",
>>>>>>> 3536063ee738a77ec813195ce14169c204b3dcc5
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
<<<<<<< HEAD
                    ""id"": ""5db14484-7ccb-466b-8e6a-ab7018bec8cb"",
=======
                    ""id"": ""a4f65a14-53d7-4f59-b3b1-e5b76a8fe892"",
>>>>>>> 3536063ee738a77ec813195ce14169c204b3dcc5
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Open"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XboxOneGampadiOS>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // TestPlayer
        m_TestPlayer = asset.FindActionMap("TestPlayer", throwIfNotFound: true);
        m_TestPlayer_Move = m_TestPlayer.FindAction("Move", throwIfNotFound: true);
        m_TestPlayer_Direction = m_TestPlayer.FindAction("Direction", throwIfNotFound: true);
        m_TestPlayer_Crouch = m_TestPlayer.FindAction("Crouch", throwIfNotFound: true);
        m_TestPlayer_WpChange = m_TestPlayer.FindAction("WpChange", throwIfNotFound: true);
        m_TestPlayer_Jump = m_TestPlayer.FindAction("Jump", throwIfNotFound: true);
        m_TestPlayer_Reload = m_TestPlayer.FindAction("Reload", throwIfNotFound: true);
        m_TestPlayer_Shoot = m_TestPlayer.FindAction("Shoot", throwIfNotFound: true);
        m_TestPlayer_Aim = m_TestPlayer.FindAction("Aim", throwIfNotFound: true);
        // Option
        m_Option = asset.FindActionMap("Option", throwIfNotFound: true);
        m_Option_Open = m_Option.FindAction("Open", throwIfNotFound: true);
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

    // TestPlayer
    private readonly InputActionMap m_TestPlayer;
    private ITestPlayerActions m_TestPlayerActionsCallbackInterface;
    private readonly InputAction m_TestPlayer_Move;
    private readonly InputAction m_TestPlayer_Direction;
    private readonly InputAction m_TestPlayer_Crouch;
    private readonly InputAction m_TestPlayer_WpChange;
    private readonly InputAction m_TestPlayer_Jump;
    private readonly InputAction m_TestPlayer_Reload;
    private readonly InputAction m_TestPlayer_Shoot;
    private readonly InputAction m_TestPlayer_Aim;
    public struct TestPlayerActions
    {
        private @Controller1 m_Wrapper;
        public TestPlayerActions(@Controller1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_TestPlayer_Move;
        public InputAction @Direction => m_Wrapper.m_TestPlayer_Direction;
        public InputAction @Crouch => m_Wrapper.m_TestPlayer_Crouch;
        public InputAction @WpChange => m_Wrapper.m_TestPlayer_WpChange;
        public InputAction @Jump => m_Wrapper.m_TestPlayer_Jump;
        public InputAction @Reload => m_Wrapper.m_TestPlayer_Reload;
        public InputAction @Shoot => m_Wrapper.m_TestPlayer_Shoot;
        public InputAction @Aim => m_Wrapper.m_TestPlayer_Aim;
        public InputActionMap Get() { return m_Wrapper.m_TestPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestPlayerActions set) { return set.Get(); }
        public void SetCallbacks(ITestPlayerActions instance)
        {
            if (m_Wrapper.m_TestPlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnMove;
                @Direction.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnDirection;
                @Direction.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnDirection;
                @Direction.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnDirection;
                @Crouch.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnCrouch;
                @WpChange.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnWpChange;
                @WpChange.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnWpChange;
                @WpChange.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnWpChange;
                @Jump.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnJump;
                @Reload.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnReload;
                @Shoot.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnShoot;
                @Aim.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_TestPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Direction.started += instance.OnDirection;
                @Direction.performed += instance.OnDirection;
                @Direction.canceled += instance.OnDirection;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @WpChange.started += instance.OnWpChange;
                @WpChange.performed += instance.OnWpChange;
                @WpChange.canceled += instance.OnWpChange;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public TestPlayerActions @TestPlayer => new TestPlayerActions(this);

    // Option
    private readonly InputActionMap m_Option;
    private IOptionActions m_OptionActionsCallbackInterface;
    private readonly InputAction m_Option_Open;
    public struct OptionActions
    {
        private @Controller1 m_Wrapper;
        public OptionActions(@Controller1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Open => m_Wrapper.m_Option_Open;
        public InputActionMap Get() { return m_Wrapper.m_Option; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OptionActions set) { return set.Get(); }
        public void SetCallbacks(IOptionActions instance)
        {
            if (m_Wrapper.m_OptionActionsCallbackInterface != null)
            {
                @Open.started -= m_Wrapper.m_OptionActionsCallbackInterface.OnOpen;
                @Open.performed -= m_Wrapper.m_OptionActionsCallbackInterface.OnOpen;
                @Open.canceled -= m_Wrapper.m_OptionActionsCallbackInterface.OnOpen;
            }
            m_Wrapper.m_OptionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Open.started += instance.OnOpen;
                @Open.performed += instance.OnOpen;
                @Open.canceled += instance.OnOpen;
            }
        }
    }
    public OptionActions @Option => new OptionActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ITestPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnDirection(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnWpChange(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
    public interface IOptionActions
    {
        void OnOpen(InputAction.CallbackContext context);
    }
}
