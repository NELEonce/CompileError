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
                    ""name"": ""wasd"",
                    ""type"": ""Button"",
                    ""id"": ""458b67d6-94c8-4176-a81b-8b554281d657"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""ecebe322-5a62-4f21-bdce-50d437e1c683"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""45f61378-492d-48cc-bc3c-51c0fe7d925f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""wasd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6961b6f7-a19d-4b77-b74c-2817e3512263"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""wasd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00752bd5-087e-4591-8978-9bd7127591cb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""wasd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e365e06-5e56-46d8-a8c6-cbd477373e30"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""wasd"",
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
        }
    ]
}");
        // TestPlayer
        m_TestPlayer = asset.FindActionMap("TestPlayer", throwIfNotFound: true);
        m_TestPlayer_wasd = m_TestPlayer.FindAction("wasd", throwIfNotFound: true);
        m_TestPlayer_Newaction = m_TestPlayer.FindAction("New action", throwIfNotFound: true);
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
    private readonly InputAction m_TestPlayer_wasd;
    private readonly InputAction m_TestPlayer_Newaction;
    public struct TestPlayerActions
    {
        private @Controller1 m_Wrapper;
        public TestPlayerActions(@Controller1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @wasd => m_Wrapper.m_TestPlayer_wasd;
        public InputAction @Newaction => m_Wrapper.m_TestPlayer_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_TestPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestPlayerActions set) { return set.Get(); }
        public void SetCallbacks(ITestPlayerActions instance)
        {
            if (m_Wrapper.m_TestPlayerActionsCallbackInterface != null)
            {
                @wasd.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnWasd;
                @wasd.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnWasd;
                @wasd.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnWasd;
                @Newaction.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_TestPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @wasd.started += instance.OnWasd;
                @wasd.performed += instance.OnWasd;
                @wasd.canceled += instance.OnWasd;
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
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
    public interface ITestPlayerActions
    {
        void OnWasd(InputAction.CallbackContext context);
        void OnNewaction(InputAction.CallbackContext context);
    }
}
