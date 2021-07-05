// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Alien/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Alien
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
            ""id"": ""560e93cb-217c-4764-b299-543f7e040abe"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""97c95506-a11a-4cc5-bb89-dbfcf1904608"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Speed"",
                    ""type"": ""Button"",
                    ""id"": ""ebc0b151-bd87-4209-aeb7-0c09b5b7f992"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keys"",
                    ""id"": ""71f283ac-d5e1-4a12-bb9a-90393cc14e53"",
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
                    ""id"": ""f0687399-d5df-43af-81c8-7effb01a508a"",
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
                    ""id"": ""768185de-817a-4eef-8e2f-e6f6afb49daa"",
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
                    ""id"": ""2bd928c0-b463-490c-b050-79f6d54cd92c"",
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
                    ""id"": ""73a25d0f-411e-46c3-b4e7-6e29e247705b"",
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
                    ""id"": ""5d42f99a-ec71-447f-9d3e-f2cf1363d0be"",
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
                    ""id"": ""6c6c21f0-db46-4190-b737-63825d359ee7"",
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
                    ""id"": ""f2df6913-fcdb-4df2-8dd8-9adc21aecf21"",
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
                    ""id"": ""f052f957-7a6a-4b16-b5cf-defd2fc540d0"",
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
                    ""id"": ""9d343bb2-6dab-44f6-a01e-b15e77aa56d5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ceaa5ef5-75e2-4ce7-96d2-c26fdcd09bc1"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Sounds"",
            ""id"": ""ab5a0b6a-065e-4076-bfaf-e3a287a94db4"",
            ""actions"": [
                {
                    ""name"": ""Roar"",
                    ""type"": ""Button"",
                    ""id"": ""183f36f4-958e-4715-940f-69d12c27a320"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Warning"",
                    ""type"": ""Button"",
                    ""id"": ""75ebfb78-266a-40c0-8e85-82dd257118dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""29b07104-ae49-47a0-a265-1255a0a57854"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""197e27a3-1f4c-4e5a-a3f7-df984750a59d"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Warning"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Attacks"",
            ""id"": ""67caaf1d-fc77-4957-a7ea-63037551c868"",
            ""actions"": [
                {
                    ""name"": ""Swipe"",
                    ""type"": ""Button"",
                    ""id"": ""bfeb62c2-8c11-45df-940e-c72eb3e7f463"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b7e9dd42-5995-459e-aca3-36d006422139"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swipe"",
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
            m_Movements_Speed = m_Movements.FindAction("Speed", throwIfNotFound: true);
            // Sounds
            m_Sounds = asset.FindActionMap("Sounds", throwIfNotFound: true);
            m_Sounds_Roar = m_Sounds.FindAction("Roar", throwIfNotFound: true);
            m_Sounds_Warning = m_Sounds.FindAction("Warning", throwIfNotFound: true);
            // Attacks
            m_Attacks = asset.FindActionMap("Attacks", throwIfNotFound: true);
            m_Attacks_Swipe = m_Attacks.FindAction("Swipe", throwIfNotFound: true);
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
        private readonly InputAction m_Movements_Speed;
        public struct MovementsActions
        {
            private @Inputs m_Wrapper;
            public MovementsActions(@Inputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Movements_Move;
            public InputAction @Speed => m_Wrapper.m_Movements_Speed;
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
                    @Speed.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnSpeed;
                    @Speed.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnSpeed;
                    @Speed.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnSpeed;
                }
                m_Wrapper.m_MovementsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Speed.started += instance.OnSpeed;
                    @Speed.performed += instance.OnSpeed;
                    @Speed.canceled += instance.OnSpeed;
                }
            }
        }
        public MovementsActions @Movements => new MovementsActions(this);

        // Sounds
        private readonly InputActionMap m_Sounds;
        private ISoundsActions m_SoundsActionsCallbackInterface;
        private readonly InputAction m_Sounds_Roar;
        private readonly InputAction m_Sounds_Warning;
        public struct SoundsActions
        {
            private @Inputs m_Wrapper;
            public SoundsActions(@Inputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Roar => m_Wrapper.m_Sounds_Roar;
            public InputAction @Warning => m_Wrapper.m_Sounds_Warning;
            public InputActionMap Get() { return m_Wrapper.m_Sounds; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SoundsActions set) { return set.Get(); }
            public void SetCallbacks(ISoundsActions instance)
            {
                if (m_Wrapper.m_SoundsActionsCallbackInterface != null)
                {
                    @Roar.started -= m_Wrapper.m_SoundsActionsCallbackInterface.OnRoar;
                    @Roar.performed -= m_Wrapper.m_SoundsActionsCallbackInterface.OnRoar;
                    @Roar.canceled -= m_Wrapper.m_SoundsActionsCallbackInterface.OnRoar;
                    @Warning.started -= m_Wrapper.m_SoundsActionsCallbackInterface.OnWarning;
                    @Warning.performed -= m_Wrapper.m_SoundsActionsCallbackInterface.OnWarning;
                    @Warning.canceled -= m_Wrapper.m_SoundsActionsCallbackInterface.OnWarning;
                }
                m_Wrapper.m_SoundsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Roar.started += instance.OnRoar;
                    @Roar.performed += instance.OnRoar;
                    @Roar.canceled += instance.OnRoar;
                    @Warning.started += instance.OnWarning;
                    @Warning.performed += instance.OnWarning;
                    @Warning.canceled += instance.OnWarning;
                }
            }
        }
        public SoundsActions @Sounds => new SoundsActions(this);

        // Attacks
        private readonly InputActionMap m_Attacks;
        private IAttacksActions m_AttacksActionsCallbackInterface;
        private readonly InputAction m_Attacks_Swipe;
        public struct AttacksActions
        {
            private @Inputs m_Wrapper;
            public AttacksActions(@Inputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Swipe => m_Wrapper.m_Attacks_Swipe;
            public InputActionMap Get() { return m_Wrapper.m_Attacks; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(AttacksActions set) { return set.Get(); }
            public void SetCallbacks(IAttacksActions instance)
            {
                if (m_Wrapper.m_AttacksActionsCallbackInterface != null)
                {
                    @Swipe.started -= m_Wrapper.m_AttacksActionsCallbackInterface.OnSwipe;
                    @Swipe.performed -= m_Wrapper.m_AttacksActionsCallbackInterface.OnSwipe;
                    @Swipe.canceled -= m_Wrapper.m_AttacksActionsCallbackInterface.OnSwipe;
                }
                m_Wrapper.m_AttacksActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Swipe.started += instance.OnSwipe;
                    @Swipe.performed += instance.OnSwipe;
                    @Swipe.canceled += instance.OnSwipe;
                }
            }
        }
        public AttacksActions @Attacks => new AttacksActions(this);
        public interface IMovementsActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnSpeed(InputAction.CallbackContext context);
        }
        public interface ISoundsActions
        {
            void OnRoar(InputAction.CallbackContext context);
            void OnWarning(InputAction.CallbackContext context);
        }
        public interface IAttacksActions
        {
            void OnSwipe(InputAction.CallbackContext context);
        }
    }
}
