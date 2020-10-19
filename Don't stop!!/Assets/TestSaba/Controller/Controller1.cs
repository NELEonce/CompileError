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
                    ""name"": ""East"",
                    ""type"": ""Button"",
                    ""id"": ""4b88180b-3470-4fa5-acf1-fac478b4dc84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""North"",
                    ""type"": ""Button"",
                    ""id"": ""d8296984-ace3-4697-a1dc-3e4e7e2a6d3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""South"",
                    ""type"": ""Button"",
                    ""id"": ""64fcfa2d-364c-4b3b-b8e2-1e565dabdb75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""West"",
                    ""type"": ""Button"",
                    ""id"": ""696f2d51-3cc0-4f76-98f7-dfcd4d027dce"",
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
                    ""groups"": """",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fa2809c-9782-40ed-ab57-e82856a1cd4b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""395b3597-8fdc-464a-a449-23d764903432"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78094a71-0bdf-47e3-bcb0-24d9de1051ce"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
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
        m_TestPlayer_East = m_TestPlayer.FindAction("East", throwIfNotFound: true);
        m_TestPlayer_North = m_TestPlayer.FindAction("North", throwIfNotFound: true);
        m_TestPlayer_South = m_TestPlayer.FindAction("South", throwIfNotFound: true);
        m_TestPlayer_West = m_TestPlayer.FindAction("West", throwIfNotFound: true);
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
    private readonly InputAction m_TestPlayer_East;
    private readonly InputAction m_TestPlayer_North;
    private readonly InputAction m_TestPlayer_South;
    private readonly InputAction m_TestPlayer_West;
    public struct TestPlayerActions
    {
        private @Controller1 m_Wrapper;
        public TestPlayerActions(@Controller1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_TestPlayer_Move;
        public InputAction @East => m_Wrapper.m_TestPlayer_East;
        public InputAction @North => m_Wrapper.m_TestPlayer_North;
        public InputAction @South => m_Wrapper.m_TestPlayer_South;
        public InputAction @West => m_Wrapper.m_TestPlayer_West;
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
                @East.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnEast;
                @East.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnEast;
                @East.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnEast;
                @North.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnNorth;
                @North.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnNorth;
                @North.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnNorth;
                @South.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnSouth;
                @South.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnSouth;
                @South.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnSouth;
                @West.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnWest;
                @West.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnWest;
                @West.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnWest;
            }
            m_Wrapper.m_TestPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @East.started += instance.OnEast;
                @East.performed += instance.OnEast;
                @East.canceled += instance.OnEast;
                @North.started += instance.OnNorth;
                @North.performed += instance.OnNorth;
                @North.canceled += instance.OnNorth;
                @South.started += instance.OnSouth;
                @South.performed += instance.OnSouth;
                @South.canceled += instance.OnSouth;
                @West.started += instance.OnWest;
                @West.performed += instance.OnWest;
                @West.canceled += instance.OnWest;
            }
        }
    }
    public TestPlayerActions @TestPlayer => new TestPlayerActions(this);
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
        void OnEast(InputAction.CallbackContext context);
        void OnNorth(InputAction.CallbackContext context);
        void OnSouth(InputAction.CallbackContext context);
        void OnWest(InputAction.CallbackContext context);
    }
}
