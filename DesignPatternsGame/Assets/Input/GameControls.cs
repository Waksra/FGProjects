// GENERATED AUTOMATICALLY FROM 'Assets/Input/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""40af04aa-92bf-4d34-b0d8-7f552802cb3f"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""ae15bd70-a855-4820-98ea-c94209909236"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""a84661e2-e785-4fa5-baef-4aeffac88785"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""5f96032d-ed94-42c2-95fb-9af15cbf1b78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""20d7bf7b-7851-4e4c-baff-6f1dbc57cbd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cd3b614f-3e2d-4412-939a-de70d4bddba0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLeft"",
                    ""type"": ""Button"",
                    ""id"": ""4710ce54-63e7-4da6-b3d4-04d810358e6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseRight"",
                    ""type"": ""Button"",
                    ""id"": ""1fee68ce-e6aa-4b66-a4ed-31cffe33b0ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3f8c84a2-299b-4890-bd02-bb7850ba3b34"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6811853-ec0b-46e0-a662-49d44b8e6f17"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a3289f8-df40-4959-89fe-d9ab7f97801c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d6d81be-2887-44af-99f8-5c59ec5390f9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea95905f-3e63-4458-951e-02d41e2b3dba"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22991e6b-4258-4dd5-8fd5-88bf245043c1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36089516-fc7d-45b6-938c-de6527c14c01"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_Up = m_Default.FindAction("Up", throwIfNotFound: true);
        m_Default_Down = m_Default.FindAction("Down", throwIfNotFound: true);
        m_Default_Left = m_Default.FindAction("Left", throwIfNotFound: true);
        m_Default_Right = m_Default.FindAction("Right", throwIfNotFound: true);
        m_Default_MousePosition = m_Default.FindAction("MousePosition", throwIfNotFound: true);
        m_Default_MouseLeft = m_Default.FindAction("MouseLeft", throwIfNotFound: true);
        m_Default_MouseRight = m_Default.FindAction("MouseRight", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_Up;
    private readonly InputAction m_Default_Down;
    private readonly InputAction m_Default_Left;
    private readonly InputAction m_Default_Right;
    private readonly InputAction m_Default_MousePosition;
    private readonly InputAction m_Default_MouseLeft;
    private readonly InputAction m_Default_MouseRight;
    public struct DefaultActions
    {
        private @GameControls m_Wrapper;
        public DefaultActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Default_Up;
        public InputAction @Down => m_Wrapper.m_Default_Down;
        public InputAction @Left => m_Wrapper.m_Default_Left;
        public InputAction @Right => m_Wrapper.m_Default_Right;
        public InputAction @MousePosition => m_Wrapper.m_Default_MousePosition;
        public InputAction @MouseLeft => m_Wrapper.m_Default_MouseLeft;
        public InputAction @MouseRight => m_Wrapper.m_Default_MouseRight;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRight;
                @MousePosition.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                @MouseLeft.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMouseLeft;
                @MouseLeft.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMouseLeft;
                @MouseLeft.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMouseLeft;
                @MouseRight.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMouseRight;
                @MouseRight.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMouseRight;
                @MouseRight.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMouseRight;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseLeft.started += instance.OnMouseLeft;
                @MouseLeft.performed += instance.OnMouseLeft;
                @MouseLeft.canceled += instance.OnMouseLeft;
                @MouseRight.started += instance.OnMouseRight;
                @MouseRight.performed += instance.OnMouseRight;
                @MouseRight.canceled += instance.OnMouseRight;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseLeft(InputAction.CallbackContext context);
        void OnMouseRight(InputAction.CallbackContext context);
    }
}
