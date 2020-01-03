// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gamepads"",
            ""id"": ""0884fb35-7406-4f04-b425-5d72391ea42f"",
            ""actions"": [
                {
                    ""name"": ""ClickButtonSouth"",
                    ""type"": ""Button"",
                    ""id"": ""10a4bde5-8e11-42d4-91c9-71fda5e955de"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""45076340-88e1-4e88-b55a-51cdcad41d12"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8417cf79-4c52-4130-97bb-d253740c56a7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickButtonSouth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d980c89-e5aa-4e36-b33f-6438819e99cb"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveLeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""f45ef3a7-f1f4-47ed-91cd-5f81e81eb0a0"",
            ""actions"": [
                {
                    ""name"": ""PressSpace"",
                    ""type"": ""Button"",
                    ""id"": ""4579f1ae-9aac-4bdd-967f-df5f1fb354f0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""606cb066-253b-4ed8-84bc-489568eb6cd7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressSpace"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
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
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gamepads
        m_Gamepads = asset.FindActionMap("Gamepads", throwIfNotFound: true);
        m_Gamepads_ClickButtonSouth = m_Gamepads.FindAction("ClickButtonSouth", throwIfNotFound: true);
        m_Gamepads_MoveLeftStick = m_Gamepads.FindAction("MoveLeftStick", throwIfNotFound: true);
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_PressSpace = m_Keyboard.FindAction("PressSpace", throwIfNotFound: true);
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

    // Gamepads
    private readonly InputActionMap m_Gamepads;
    private IGamepadsActions m_GamepadsActionsCallbackInterface;
    private readonly InputAction m_Gamepads_ClickButtonSouth;
    private readonly InputAction m_Gamepads_MoveLeftStick;
    public struct GamepadsActions
    {
        private @PlayerControls m_Wrapper;
        public GamepadsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ClickButtonSouth => m_Wrapper.m_Gamepads_ClickButtonSouth;
        public InputAction @MoveLeftStick => m_Wrapper.m_Gamepads_MoveLeftStick;
        public InputActionMap Get() { return m_Wrapper.m_Gamepads; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamepadsActions set) { return set.Get(); }
        public void SetCallbacks(IGamepadsActions instance)
        {
            if (m_Wrapper.m_GamepadsActionsCallbackInterface != null)
            {
                @ClickButtonSouth.started -= m_Wrapper.m_GamepadsActionsCallbackInterface.OnClickButtonSouth;
                @ClickButtonSouth.performed -= m_Wrapper.m_GamepadsActionsCallbackInterface.OnClickButtonSouth;
                @ClickButtonSouth.canceled -= m_Wrapper.m_GamepadsActionsCallbackInterface.OnClickButtonSouth;
                @MoveLeftStick.started -= m_Wrapper.m_GamepadsActionsCallbackInterface.OnMoveLeftStick;
                @MoveLeftStick.performed -= m_Wrapper.m_GamepadsActionsCallbackInterface.OnMoveLeftStick;
                @MoveLeftStick.canceled -= m_Wrapper.m_GamepadsActionsCallbackInterface.OnMoveLeftStick;
            }
            m_Wrapper.m_GamepadsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ClickButtonSouth.started += instance.OnClickButtonSouth;
                @ClickButtonSouth.performed += instance.OnClickButtonSouth;
                @ClickButtonSouth.canceled += instance.OnClickButtonSouth;
                @MoveLeftStick.started += instance.OnMoveLeftStick;
                @MoveLeftStick.performed += instance.OnMoveLeftStick;
                @MoveLeftStick.canceled += instance.OnMoveLeftStick;
            }
        }
    }
    public GamepadsActions @Gamepads => new GamepadsActions(this);

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_PressSpace;
    public struct KeyboardActions
    {
        private @PlayerControls m_Wrapper;
        public KeyboardActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PressSpace => m_Wrapper.m_Keyboard_PressSpace;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @PressSpace.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnPressSpace;
                @PressSpace.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnPressSpace;
                @PressSpace.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnPressSpace;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PressSpace.started += instance.OnPressSpace;
                @PressSpace.performed += instance.OnPressSpace;
                @PressSpace.canceled += instance.OnPressSpace;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
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
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IGamepadsActions
    {
        void OnClickButtonSouth(InputAction.CallbackContext context);
        void OnMoveLeftStick(InputAction.CallbackContext context);
    }
    public interface IKeyboardActions
    {
        void OnPressSpace(InputAction.CallbackContext context);
    }
}
