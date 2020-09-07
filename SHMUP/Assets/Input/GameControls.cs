// GENERATED AUTOMATICALLY FROM 'Assets/Input/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Input
{
    public class @GameControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Play"",
            ""id"": ""842ea315-7c3a-40aa-9d14-e419ae6cdb52"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a072eacc-746f-42b2-abbb-dd456b8db7fb"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""e91e7827-e6ca-4e64-b6e3-238361503cfe"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""307a8ce3-348d-4a4e-95ba-b694d89d3ba7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ce2a1213-3343-4951-b18a-a3ab6ff62d6c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""c653aafd-643e-437f-899a-b573dd1b322a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fedc900e-bba1-414b-bcff-15825890b2e4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ecaeafc4-1af8-49d5-a223-b24124559830"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""a5859933-52f0-46d9-8015-bb5e90ec7713"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d6bfc53f-2346-457d-b9ef-df069c82ecf0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1f537bfe-02fb-4f07-94ad-d74d989f3e83"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Play
            m_Play = asset.FindActionMap("Play", throwIfNotFound: true);
            m_Play_Move = m_Play.FindAction("Move", throwIfNotFound: true);
            m_Play_Rotate = m_Play.FindAction("Rotate", throwIfNotFound: true);
            m_Play_Brake = m_Play.FindAction("Brake", throwIfNotFound: true);
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

        // Play
        private readonly InputActionMap m_Play;
        private IPlayActions m_PlayActionsCallbackInterface;
        private readonly InputAction m_Play_Move;
        private readonly InputAction m_Play_Rotate;
        private readonly InputAction m_Play_Brake;
        public struct PlayActions
        {
            private @GameControls m_Wrapper;
            public PlayActions(@GameControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Play_Move;
            public InputAction @Rotate => m_Wrapper.m_Play_Rotate;
            public InputAction @Brake => m_Wrapper.m_Play_Brake;
            public InputActionMap Get() { return m_Wrapper.m_Play; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayActions set) { return set.Get(); }
            public void SetCallbacks(IPlayActions instance)
            {
                if (m_Wrapper.m_PlayActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnMove;
                    @Rotate.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnRotate;
                    @Brake.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnBrake;
                    @Brake.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnBrake;
                    @Brake.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnBrake;
                }
                m_Wrapper.m_PlayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                    @Brake.started += instance.OnBrake;
                    @Brake.performed += instance.OnBrake;
                    @Brake.canceled += instance.OnBrake;
                }
            }
        }
        public PlayActions @Play => new PlayActions(this);
        public interface IPlayActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
            void OnBrake(InputAction.CallbackContext context);
        }
    }
}
