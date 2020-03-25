// GENERATED AUTOMATICALLY FROM 'Assets/Player/PlayerControls.inputactions'

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
        },
        {
            ""name"": ""Gamepad"",
            ""id"": ""774c61dd-cfd4-486c-b54b-9d1693d4e41f"",
            ""actions"": [
                {
                    ""name"": ""MoveLeftStick"",
                    ""type"": ""Button"",
                    ""id"": ""ee2592c5-197e-46fc-951a-6fc4146e5bcf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressDPad"",
                    ""type"": ""Button"",
                    ""id"": ""5708cd1f-bce6-4abd-90b0-9956e0d21c2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressButtonSouth"",
                    ""type"": ""Button"",
                    ""id"": ""c4d74f5d-1c96-4b49-85c4-8bf60e78833a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ReleaseButtonSouth"",
                    ""type"": ""Button"",
                    ""id"": ""e80791f4-ae21-4aaf-ad4f-4b3f876bac4f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRightStick"",
                    ""type"": ""Button"",
                    ""id"": ""df402b4f-b5c6-446e-9ac8-c5528f9ba3fe"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightShoulder"",
                    ""type"": ""Button"",
                    ""id"": ""13c74b7c-fe4a-4669-bc3f-2782ef79a1d7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftShoulder"",
                    ""type"": ""Button"",
                    ""id"": ""405bd3f7-8850-4981-8651-5e09b6b59f1e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e2badcbe-93c5-4550-a3e7-72b51f5fe2c4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveLeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d81b116f-76d3-43d9-8cb1-e4ff7ce604f6"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressDPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f805fc8-33ee-43c7-90c4-821d52628e89"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PressButtonSouth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acac4e8a-4ecc-4761-8ba3-63b4f5390315"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveRightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c757d76-1f14-422a-be30-3ebf811cad8a"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""047e99ff-caec-4b85-b39c-0ad1b33c7af0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""075c0112-b97c-4d50-a65d-d8a2b6841c96"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ReleaseButtonSouth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""b339e058-032d-4867-975e-deb533a3d6f3"",
            ""actions"": [
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""59a14cd4-9ec2-4de7-ac70-68a46bfd1fe7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""71cd4188-e0b9-41f5-9635-78215da42a42"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""LeftClick"",
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
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_PressSpace = m_Keyboard.FindAction("PressSpace", throwIfNotFound: true);
        // Gamepad
        m_Gamepad = asset.FindActionMap("Gamepad", throwIfNotFound: true);
        m_Gamepad_MoveLeftStick = m_Gamepad.FindAction("MoveLeftStick", throwIfNotFound: true);
        m_Gamepad_PressDPad = m_Gamepad.FindAction("PressDPad", throwIfNotFound: true);
        m_Gamepad_PressButtonSouth = m_Gamepad.FindAction("PressButtonSouth", throwIfNotFound: true);
        m_Gamepad_ReleaseButtonSouth = m_Gamepad.FindAction("ReleaseButtonSouth", throwIfNotFound: true);
        m_Gamepad_MoveRightStick = m_Gamepad.FindAction("MoveRightStick", throwIfNotFound: true);
        m_Gamepad_RightShoulder = m_Gamepad.FindAction("RightShoulder", throwIfNotFound: true);
        m_Gamepad_LeftShoulder = m_Gamepad.FindAction("LeftShoulder", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_LeftClick = m_Mouse.FindAction("LeftClick", throwIfNotFound: true);
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

    // Gamepad
    private readonly InputActionMap m_Gamepad;
    private IGamepadActions m_GamepadActionsCallbackInterface;
    private readonly InputAction m_Gamepad_MoveLeftStick;
    private readonly InputAction m_Gamepad_PressDPad;
    private readonly InputAction m_Gamepad_PressButtonSouth;
    private readonly InputAction m_Gamepad_ReleaseButtonSouth;
    private readonly InputAction m_Gamepad_MoveRightStick;
    private readonly InputAction m_Gamepad_RightShoulder;
    private readonly InputAction m_Gamepad_LeftShoulder;
    public struct GamepadActions
    {
        private @PlayerControls m_Wrapper;
        public GamepadActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeftStick => m_Wrapper.m_Gamepad_MoveLeftStick;
        public InputAction @PressDPad => m_Wrapper.m_Gamepad_PressDPad;
        public InputAction @PressButtonSouth => m_Wrapper.m_Gamepad_PressButtonSouth;
        public InputAction @ReleaseButtonSouth => m_Wrapper.m_Gamepad_ReleaseButtonSouth;
        public InputAction @MoveRightStick => m_Wrapper.m_Gamepad_MoveRightStick;
        public InputAction @RightShoulder => m_Wrapper.m_Gamepad_RightShoulder;
        public InputAction @LeftShoulder => m_Wrapper.m_Gamepad_LeftShoulder;
        public InputActionMap Get() { return m_Wrapper.m_Gamepad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamepadActions set) { return set.Get(); }
        public void SetCallbacks(IGamepadActions instance)
        {
            if (m_Wrapper.m_GamepadActionsCallbackInterface != null)
            {
                @MoveLeftStick.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMoveLeftStick;
                @MoveLeftStick.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMoveLeftStick;
                @MoveLeftStick.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMoveLeftStick;
                @PressDPad.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnPressDPad;
                @PressDPad.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnPressDPad;
                @PressDPad.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnPressDPad;
                @PressButtonSouth.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnPressButtonSouth;
                @PressButtonSouth.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnPressButtonSouth;
                @PressButtonSouth.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnPressButtonSouth;
                @ReleaseButtonSouth.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnReleaseButtonSouth;
                @ReleaseButtonSouth.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnReleaseButtonSouth;
                @ReleaseButtonSouth.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnReleaseButtonSouth;
                @MoveRightStick.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMoveRightStick;
                @MoveRightStick.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMoveRightStick;
                @MoveRightStick.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnMoveRightStick;
                @RightShoulder.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnRightShoulder;
                @RightShoulder.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnRightShoulder;
                @RightShoulder.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnRightShoulder;
                @LeftShoulder.started -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLeftShoulder;
                @LeftShoulder.performed -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLeftShoulder;
                @LeftShoulder.canceled -= m_Wrapper.m_GamepadActionsCallbackInterface.OnLeftShoulder;
            }
            m_Wrapper.m_GamepadActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeftStick.started += instance.OnMoveLeftStick;
                @MoveLeftStick.performed += instance.OnMoveLeftStick;
                @MoveLeftStick.canceled += instance.OnMoveLeftStick;
                @PressDPad.started += instance.OnPressDPad;
                @PressDPad.performed += instance.OnPressDPad;
                @PressDPad.canceled += instance.OnPressDPad;
                @PressButtonSouth.started += instance.OnPressButtonSouth;
                @PressButtonSouth.performed += instance.OnPressButtonSouth;
                @PressButtonSouth.canceled += instance.OnPressButtonSouth;
                @ReleaseButtonSouth.started += instance.OnReleaseButtonSouth;
                @ReleaseButtonSouth.performed += instance.OnReleaseButtonSouth;
                @ReleaseButtonSouth.canceled += instance.OnReleaseButtonSouth;
                @MoveRightStick.started += instance.OnMoveRightStick;
                @MoveRightStick.performed += instance.OnMoveRightStick;
                @MoveRightStick.canceled += instance.OnMoveRightStick;
                @RightShoulder.started += instance.OnRightShoulder;
                @RightShoulder.performed += instance.OnRightShoulder;
                @RightShoulder.canceled += instance.OnRightShoulder;
                @LeftShoulder.started += instance.OnLeftShoulder;
                @LeftShoulder.performed += instance.OnLeftShoulder;
                @LeftShoulder.canceled += instance.OnLeftShoulder;
            }
        }
    }
    public GamepadActions @Gamepad => new GamepadActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_LeftClick;
    public struct MouseActions
    {
        private @PlayerControls m_Wrapper;
        public MouseActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftClick => m_Wrapper.m_Mouse_LeftClick;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @LeftClick.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
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
    public interface IKeyboardActions
    {
        void OnPressSpace(InputAction.CallbackContext context);
    }
    public interface IGamepadActions
    {
        void OnMoveLeftStick(InputAction.CallbackContext context);
        void OnPressDPad(InputAction.CallbackContext context);
        void OnPressButtonSouth(InputAction.CallbackContext context);
        void OnReleaseButtonSouth(InputAction.CallbackContext context);
        void OnMoveRightStick(InputAction.CallbackContext context);
        void OnRightShoulder(InputAction.CallbackContext context);
        void OnLeftShoulder(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnLeftClick(InputAction.CallbackContext context);
    }
}
