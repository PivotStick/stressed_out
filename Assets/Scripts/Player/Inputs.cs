// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Player
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
            ""id"": ""49f98d90-bffb-43c5-b1e3-b2dea5e732d8"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""0ec76828-1727-4f67-ac11-6ead23de7c95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keys"",
                    ""id"": ""db804f0d-76da-4c4b-a79d-3dc963aea9ed"",
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
                    ""id"": ""e5b5ab58-9840-4525-baf8-2cd32e447f84"",
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
                    ""id"": ""75ebfcf0-3550-4535-9d31-5a60db31c01f"",
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
                    ""id"": ""5b9f4575-2420-4a64-a923-ee64a06a66ba"",
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
                    ""id"": ""3b9ee6db-7a6b-4678-8c06-2d1b6ac36d4d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""45a868e4-a48a-49e7-83b1-fc8e4abae420"",
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
                    ""id"": ""44493d43-ca06-45bf-9300-0871aa3d2571"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d0f88ff3-2356-42d8-93cd-27db55f51a66"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2d10748d-b73c-49ff-a350-e27f84f6a9ab"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""29701944-e697-4db7-bd92-28700f7de024"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Interactions"",
            ""id"": ""3d64bee5-0912-4019-a69d-9e8a1845838d"",
            ""actions"": [
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""c53bdb5c-68d3-40d5-a32e-9df6beca9fbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Button"",
                    ""id"": ""3aaf6148-3a55-41ac-86dd-57140bb1baec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""be071352-9368-4553-a1dd-fc23729f30e7"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""keys"",
                    ""id"": ""f4651121-1352-4129-93c6-a020e1f3637e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4d28da2a-42cf-4dac-8fa3-b9f168224d3a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ffdf337c-6012-4c02-8426-36c943c907aa"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Movements
            m_Movements = asset.FindActionMap("Movements", throwIfNotFound: true);
            m_Movements_Move = m_Movements.FindAction("Move", throwIfNotFound: true);
            // Interactions
            m_Interactions = asset.FindActionMap("Interactions", throwIfNotFound: true);
            m_Interactions_Use = m_Interactions.FindAction("Use", throwIfNotFound: true);
            m_Interactions_Scroll = m_Interactions.FindAction("Scroll", throwIfNotFound: true);
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
        public struct MovementsActions
        {
            private @Inputs m_Wrapper;
            public MovementsActions(@Inputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Movements_Move;
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
                }
                m_Wrapper.m_MovementsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                }
            }
        }
        public MovementsActions @Movements => new MovementsActions(this);

        // Interactions
        private readonly InputActionMap m_Interactions;
        private IInteractionsActions m_InteractionsActionsCallbackInterface;
        private readonly InputAction m_Interactions_Use;
        private readonly InputAction m_Interactions_Scroll;
        public struct InteractionsActions
        {
            private @Inputs m_Wrapper;
            public InteractionsActions(@Inputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Use => m_Wrapper.m_Interactions_Use;
            public InputAction @Scroll => m_Wrapper.m_Interactions_Scroll;
            public InputActionMap Get() { return m_Wrapper.m_Interactions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InteractionsActions set) { return set.Get(); }
            public void SetCallbacks(IInteractionsActions instance)
            {
                if (m_Wrapper.m_InteractionsActionsCallbackInterface != null)
                {
                    @Use.started -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnUse;
                    @Use.performed -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnUse;
                    @Use.canceled -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnUse;
                    @Scroll.started -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnScroll;
                    @Scroll.performed -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnScroll;
                    @Scroll.canceled -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnScroll;
                }
                m_Wrapper.m_InteractionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Use.started += instance.OnUse;
                    @Use.performed += instance.OnUse;
                    @Use.canceled += instance.OnUse;
                    @Scroll.started += instance.OnScroll;
                    @Scroll.performed += instance.OnScroll;
                    @Scroll.canceled += instance.OnScroll;
                }
            }
        }
        public InteractionsActions @Interactions => new InteractionsActions(this);
        public interface IMovementsActions
        {
            void OnMove(InputAction.CallbackContext context);
        }
        public interface IInteractionsActions
        {
            void OnUse(InputAction.CallbackContext context);
            void OnScroll(InputAction.CallbackContext context);
        }
    }
}
