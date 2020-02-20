// GENERATED AUTOMATICALLY FROM 'Assets/Player/PlayerControls.inputactions'

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
            ""name"": ""Fish"",
            ""id"": ""0884fb35-7406-4f04-b425-5d72391ea42f"",
            ""actions"": [
                {
                    ""name"": ""PressButtonSouth"",
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
                    ""groups"": ""Gamepad"",
                    ""action"": ""PressButtonSouth"",
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
        },
        {
            ""name"": ""Tower"",
            ""id"": ""774c61dd-cfd4-486c-b54b-9d1693d4e41f"",
            ""actions"": [
                {
                    ""name"": ""MoveStick"",
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
                    ""action"": ""MoveStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91930aca-c76b-4b1c-8f03-fccbc0f49852"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoveStick"",
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
        // Fish
        m_Fish = asset.FindActionMap("Fish", throwIfNotFound: true);
        m_Fish_PressButtonSouth = m_Fish.FindAction("PressButtonSouth", throwIfNotFound: true);
        m_Fish_MoveLeftStick = m_Fish.FindAction("MoveLeftStick", throwIfNotFound: true);
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_PressSpace = m_Keyboard.FindAction("PressSpace", throwIfNotFound: true);
        // Tower
        m_Tower = asset.FindActionMap("Tower", throwIfNotFound: true);
        m_Tower_MoveStick = m_Tower.FindAction("MoveStick", throwIfNotFound: true);
        m_Tower_PressDPad = m_Tower.FindAction("PressDPad", throwIfNotFound: true);
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

    // Fish
    private readonly InputActionMap m_Fish;
    private IFishActions m_FishActionsCallbackInterface;
    private readonly InputAction m_Fish_PressButtonSouth;
    private readonly InputAction m_Fish_MoveLeftStick;
    public struct FishActions
    {
        private @PlayerControls m_Wrapper;
        public FishActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PressButtonSouth => m_Wrapper.m_Fish_PressButtonSouth;
        public InputAction @MoveLeftStick => m_Wrapper.m_Fish_MoveLeftStick;
        public InputActionMap Get() { return m_Wrapper.m_Fish; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FishActions set) { return set.Get(); }
        public void SetCallbacks(IFishActions instance)
        {
            if (m_Wrapper.m_FishActionsCallbackInterface != null)
            {
                @PressButtonSouth.started -= m_Wrapper.m_FishActionsCallbackInterface.OnPressButtonSouth;
                @PressButtonSouth.performed -= m_Wrapper.m_FishActionsCallbackInterface.OnPressButtonSouth;
                @PressButtonSouth.canceled -= m_Wrapper.m_FishActionsCallbackInterface.OnPressButtonSouth;
                @MoveLeftStick.started -= m_Wrapper.m_FishActionsCallbackInterface.OnMoveLeftStick;
                @MoveLeftStick.performed -= m_Wrapper.m_FishActionsCallbackInterface.OnMoveLeftStick;
                @MoveLeftStick.canceled -= m_Wrapper.m_FishActionsCallbackInterface.OnMoveLeftStick;
            }
            m_Wrapper.m_FishActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PressButtonSouth.started += instance.OnPressButtonSouth;
                @PressButtonSouth.performed += instance.OnPressButtonSouth;
                @PressButtonSouth.canceled += instance.OnPressButtonSouth;
                @MoveLeftStick.started += instance.OnMoveLeftStick;
                @MoveLeftStick.performed += instance.OnMoveLeftStick;
                @MoveLeftStick.canceled += instance.OnMoveLeftStick;
            }
        }
    }
    public FishActions @Fish => new FishActions(this);

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

    // Tower
    private readonly InputActionMap m_Tower;
    private ITowerActions m_TowerActionsCallbackInterface;
    private readonly InputAction m_Tower_MoveStick;
    private readonly InputAction m_Tower_PressDPad;
    public struct TowerActions
    {
        private @PlayerControls m_Wrapper;
        public TowerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveStick => m_Wrapper.m_Tower_MoveStick;
        public InputAction @PressDPad => m_Wrapper.m_Tower_PressDPad;
        public InputActionMap Get() { return m_Wrapper.m_Tower; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TowerActions set) { return set.Get(); }
        public void SetCallbacks(ITowerActions instance)
        {
            if (m_Wrapper.m_TowerActionsCallbackInterface != null)
            {
                @MoveStick.started -= m_Wrapper.m_TowerActionsCallbackInterface.OnMoveStick;
                @MoveStick.performed -= m_Wrapper.m_TowerActionsCallbackInterface.OnMoveStick;
                @MoveStick.canceled -= m_Wrapper.m_TowerActionsCallbackInterface.OnMoveStick;
                @PressDPad.started -= m_Wrapper.m_TowerActionsCallbackInterface.OnPressDPad;
                @PressDPad.performed -= m_Wrapper.m_TowerActionsCallbackInterface.OnPressDPad;
                @PressDPad.canceled -= m_Wrapper.m_TowerActionsCallbackInterface.OnPressDPad;
            }
            m_Wrapper.m_TowerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveStick.started += instance.OnMoveStick;
                @MoveStick.performed += instance.OnMoveStick;
                @MoveStick.canceled += instance.OnMoveStick;
                @PressDPad.started += instance.OnPressDPad;
                @PressDPad.performed += instance.OnPressDPad;
                @PressDPad.canceled += instance.OnPressDPad;
            }
        }
    }
    public TowerActions @Tower => new TowerActions(this);
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
    public interface IFishActions
    {
        void OnPressButtonSouth(InputAction.CallbackContext context);
        void OnMoveLeftStick(InputAction.CallbackContext context);
    }
    public interface IKeyboardActions
    {
        void OnPressSpace(InputAction.CallbackContext context);
    }
    public interface ITowerActions
    {
        void OnMoveStick(InputAction.CallbackContext context);
        void OnPressDPad(InputAction.CallbackContext context);
    }
}
