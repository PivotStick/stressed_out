// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Human/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Human
{
    public class @Inputs : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Inputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Movements"",
            ""id"": ""9150f620-e288-49e1-bc36-c6ce9c51f414"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""c313b68b-f375-4684-8891-5af51f92c33f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""cc351f6d-605c-4f19-9c1b-9eb80abc04ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""fff259e9-540e-4aca-8659-8f7ccdb971b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""93c60f6e-58f7-4f56-b640-5cd99f888861"",
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
                    ""id"": ""83d5dc11-0e2e-46ca-b0cf-d63a3dfd221d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""94eecfde-570c-4fb5-b08a-4a75d5be10ba"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6c1baa96-dbd6-4807-8f5c-c76139871d98"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c0e75b57-341c-4a6d-8047-dc275489a315"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""059893df-9050-45b4-8ca4-df21f7dfb775"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07345421-c7f3-4e6e-9b2b-30b0948aa42b"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Movements
            m_Movements = asset.FindActionMap("Movements", throwIfNotFound: true);
            m_Movements_Move = m_Movements.FindAction("Move", throwIfNotFound: true);
            m_Movements_Sprint = m_Movements.FindAction("Sprint", throwIfNotFound: true);
            m_Movements_Walk = m_Movements.FindAction("Walk", throwIfNotFound: true);
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

        // Movements
        private readonly InputActionMap m_Movements;
        private IMovementsActions m_MovementsActionsCallbackInterface;
        private readonly InputAction m_Movements_Move;
        private readonly InputAction m_Movements_Sprint;
        private readonly InputAction m_Movements_Walk;
        public struct MovementsActions
        {
            private @Inputs m_Wrapper;
            public MovementsActions(@Inputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Movements_Move;
            public InputAction @Sprint => m_Wrapper.m_Movements_Sprint;
            public InputAction @Walk => m_Wrapper.m_Movements_Walk;
            public InputActionMap Get() { return m_Wrapper.m_Movements; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MovementsActions set) { return set.Get(); }
            public void SetCallbacks(IMovementsActions instance)
            {
                if (m_Wrapper.m_MovementsActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnMove;
                    @Sprint.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnSprint;
                    @Walk.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnWalk;
                    @Walk.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnWalk;
                    @Walk.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnWalk;
                }
                m_Wrapper.m_MovementsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                    @Walk.started += instance.OnWalk;
                    @Walk.performed += instance.OnWalk;
                    @Walk.canceled += instance.OnWalk;
                }
            }
        }
        public MovementsActions @Movements => new MovementsActions(this);
        public interface IMovementsActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnWalk(InputAction.CallbackContext context);
        }
    }
}
