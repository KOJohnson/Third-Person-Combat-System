//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Third Person Melee System/Scripts/Player/Player Input Actions/Inputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Object = UnityEngine.Object;

namespace ThirdPersonMeleeSystem
{
    public partial

    class @Inputs : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }

        public @Inputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""15e7a0e5-7560-4b73-abdd-248b0eb4f845"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""66339429-dbcc-48ec-91a6-a0a0fca3e247"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""cf091f83-2ee5-480a-a96e-6052a8b75ce6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""1c652cf4-8fef-45f9-98a8-8a8b43dd3fda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleWalk"",
                    ""type"": ""Button"",
                    ""id"": ""a6c63cd4-eaae-47d6-847e-1752aea7f205"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""53eb1b6c-4440-469c-90f7-c6cf90916efb"",
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
                    ""id"": ""889c9fe2-98ff-41af-9cec-5c6b3ced0ad5"",
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
                    ""id"": ""07d3bcbe-d3d1-40b3-a55c-aa81cf1d8575"",
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
                    ""id"": ""02fa6c2f-047d-443b-947e-9364f4c33cc0"",
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
                    ""id"": ""2337ac4a-b749-474a-939d-701f0222c7d2"",
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
                    ""id"": ""99888f8b-bf6b-462b-9c93-5950dadfe97c"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3950d2da-2069-41ae-8642-308fdb6fba9a"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleWalk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bd7d127-676e-4137-9658-6d98e7c7c35b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""1c117354-3b77-45c9-8453-ec8f50232310"",
            ""actions"": [
                {
                    ""name"": ""DrawWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""2d12a571-eaa1-4fbd-92d6-05a2041c96f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttackModifier"",
                    ""type"": ""Button"",
                    ""id"": ""37eae0b7-24d7-4f7f-bc3b-c71e1012335b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LightAttack"",
                    ""type"": ""Button"",
                    ""id"": ""253cd379-17c1-41be-ba3b-48bd7669ea19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HeavyAttack"",
                    ""type"": ""Button"",
                    ""id"": ""53c5f37a-02c7-4270-a7dd-79421a6aa384"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""34296c99-99f2-4c3d-934b-21b00059e9d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TargetSwitchLeft"",
                    ""type"": ""Button"",
                    ""id"": ""f8360a55-a3fa-4d66-bb8d-335ef724f55f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TargetSwitchRIght"",
                    ""type"": ""Button"",
                    ""id"": ""e99b9568-ef3e-4f50-b60f-c4dd3af60b9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""05b6aed6-2d62-4162-8913-d7250622d0de"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DrawWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc887947-9f78-4add-9122-40a7d1fc481e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be195f01-a6a9-4678-b926-73dbf701f45e"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackModifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1970554b-7fbe-46c9-8417-db0d9c355315"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53ed0cf4-9ce3-4b95-b8ae-0af3d9e07698"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a34ddc5d-3f41-4c41-b0be-31024a075425"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TargetSwitchLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b4c5151-65c0-421f-82e9-d5b6f32c4678"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TargetSwitchRIght"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
            m_Gameplay_Look = m_Gameplay.FindAction("Look", throwIfNotFound: true);
            m_Gameplay_Sprint = m_Gameplay.FindAction("Sprint", throwIfNotFound: true);
            m_Gameplay_ToggleWalk = m_Gameplay.FindAction("ToggleWalk", throwIfNotFound: true);
            // Combat
            m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
            m_Combat_DrawWeapon = m_Combat.FindAction("DrawWeapon", throwIfNotFound: true);
            m_Combat_AttackModifier = m_Combat.FindAction("AttackModifier", throwIfNotFound: true);
            m_Combat_LightAttack = m_Combat.FindAction("LightAttack", throwIfNotFound: true);
            m_Combat_HeavyAttack = m_Combat.FindAction("HeavyAttack", throwIfNotFound: true);
            m_Combat_LockOn = m_Combat.FindAction("LockOn", throwIfNotFound: true);
            m_Combat_TargetSwitchLeft = m_Combat.FindAction("TargetSwitchLeft", throwIfNotFound: true);
            m_Combat_TargetSwitchRIght = m_Combat.FindAction("TargetSwitchRIght", throwIfNotFound: true);
        }

        public void Dispose()
        {
            Object.Destroy(asset);
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
        private readonly InputAction m_Gameplay_Move;
        private readonly InputAction m_Gameplay_Look;
        private readonly InputAction m_Gameplay_Sprint;
        private readonly InputAction m_Gameplay_ToggleWalk;

        public struct GameplayActions
        {
            private @Inputs m_Wrapper;

            public GameplayActions(@Inputs wrapper)
            {
                m_Wrapper = wrapper;
            }

            public InputAction @Move => m_Wrapper.m_Gameplay_Move;
            public InputAction @Look => m_Wrapper.m_Gameplay_Look;
            public InputAction @Sprint => m_Wrapper.m_Gameplay_Sprint;
            public InputAction @ToggleWalk => m_Wrapper.m_Gameplay_ToggleWalk;

            public InputActionMap Get()
            {
                return m_Wrapper.m_Gameplay;
            }

            public void Enable()
            {
                Get().Enable();
            }

            public void Disable()
            {
                Get().Disable();
            }

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(GameplayActions set)
            {
                return set.Get();
            }

            public void AddCallbacks(IGameplayActions instance)
            {
                if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @ToggleWalk.started += instance.OnToggleWalk;
                @ToggleWalk.performed += instance.OnToggleWalk;
                @ToggleWalk.canceled += instance.OnToggleWalk;
            }

            private void UnregisterCallbacks(IGameplayActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Look.started -= instance.OnLook;
                @Look.performed -= instance.OnLook;
                @Look.canceled -= instance.OnLook;
                @Sprint.started -= instance.OnSprint;
                @Sprint.performed -= instance.OnSprint;
                @Sprint.canceled -= instance.OnSprint;
                @ToggleWalk.started -= instance.OnToggleWalk;
                @ToggleWalk.performed -= instance.OnToggleWalk;
                @ToggleWalk.canceled -= instance.OnToggleWalk;
            }

            public void RemoveCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IGameplayActions instance)
            {
                foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }

        public GameplayActions @Gameplay => new GameplayActions(this);

        // Combat
        private readonly InputActionMap m_Combat;
        private List<ICombatActions> m_CombatActionsCallbackInterfaces = new List<ICombatActions>();
        private readonly InputAction m_Combat_DrawWeapon;
        private readonly InputAction m_Combat_AttackModifier;
        private readonly InputAction m_Combat_LightAttack;
        private readonly InputAction m_Combat_HeavyAttack;
        private readonly InputAction m_Combat_LockOn;
        private readonly InputAction m_Combat_TargetSwitchLeft;
        private readonly InputAction m_Combat_TargetSwitchRIght;

        public struct CombatActions
        {
            private @Inputs m_Wrapper;

            public CombatActions(@Inputs wrapper)
            {
                m_Wrapper = wrapper;
            }

            public InputAction @DrawWeapon => m_Wrapper.m_Combat_DrawWeapon;
            public InputAction @AttackModifier => m_Wrapper.m_Combat_AttackModifier;
            public InputAction @LightAttack => m_Wrapper.m_Combat_LightAttack;
            public InputAction @HeavyAttack => m_Wrapper.m_Combat_HeavyAttack;
            public InputAction @LockOn => m_Wrapper.m_Combat_LockOn;
            public InputAction @TargetSwitchLeft => m_Wrapper.m_Combat_TargetSwitchLeft;
            public InputAction @TargetSwitchRIght => m_Wrapper.m_Combat_TargetSwitchRIght;

            public InputActionMap Get()
            {
                return m_Wrapper.m_Combat;
            }

            public void Enable()
            {
                Get().Enable();
            }

            public void Disable()
            {
                Get().Disable();
            }

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(CombatActions set)
            {
                return set.Get();
            }

            public void AddCallbacks(ICombatActions instance)
            {
                if (instance == null || m_Wrapper.m_CombatActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_CombatActionsCallbackInterfaces.Add(instance);
                @DrawWeapon.started += instance.OnDrawWeapon;
                @DrawWeapon.performed += instance.OnDrawWeapon;
                @DrawWeapon.canceled += instance.OnDrawWeapon;
                @AttackModifier.started += instance.OnAttackModifier;
                @AttackModifier.performed += instance.OnAttackModifier;
                @AttackModifier.canceled += instance.OnAttackModifier;
                @LightAttack.started += instance.OnLightAttack;
                @LightAttack.performed += instance.OnLightAttack;
                @LightAttack.canceled += instance.OnLightAttack;
                @HeavyAttack.started += instance.OnHeavyAttack;
                @HeavyAttack.performed += instance.OnHeavyAttack;
                @HeavyAttack.canceled += instance.OnHeavyAttack;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @TargetSwitchLeft.started += instance.OnTargetSwitchLeft;
                @TargetSwitchLeft.performed += instance.OnTargetSwitchLeft;
                @TargetSwitchLeft.canceled += instance.OnTargetSwitchLeft;
                @TargetSwitchRIght.started += instance.OnTargetSwitchRIght;
                @TargetSwitchRIght.performed += instance.OnTargetSwitchRIght;
                @TargetSwitchRIght.canceled += instance.OnTargetSwitchRIght;
            }

            private void UnregisterCallbacks(ICombatActions instance)
            {
                @DrawWeapon.started -= instance.OnDrawWeapon;
                @DrawWeapon.performed -= instance.OnDrawWeapon;
                @DrawWeapon.canceled -= instance.OnDrawWeapon;
                @AttackModifier.started -= instance.OnAttackModifier;
                @AttackModifier.performed -= instance.OnAttackModifier;
                @AttackModifier.canceled -= instance.OnAttackModifier;
                @LightAttack.started -= instance.OnLightAttack;
                @LightAttack.performed -= instance.OnLightAttack;
                @LightAttack.canceled -= instance.OnLightAttack;
                @HeavyAttack.started -= instance.OnHeavyAttack;
                @HeavyAttack.performed -= instance.OnHeavyAttack;
                @HeavyAttack.canceled -= instance.OnHeavyAttack;
                @LockOn.started -= instance.OnLockOn;
                @LockOn.performed -= instance.OnLockOn;
                @LockOn.canceled -= instance.OnLockOn;
                @TargetSwitchLeft.started -= instance.OnTargetSwitchLeft;
                @TargetSwitchLeft.performed -= instance.OnTargetSwitchLeft;
                @TargetSwitchLeft.canceled -= instance.OnTargetSwitchLeft;
                @TargetSwitchRIght.started -= instance.OnTargetSwitchRIght;
                @TargetSwitchRIght.performed -= instance.OnTargetSwitchRIght;
                @TargetSwitchRIght.canceled -= instance.OnTargetSwitchRIght;
            }

            public void RemoveCallbacks(ICombatActions instance)
            {
                if (m_Wrapper.m_CombatActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ICombatActions instance)
            {
                foreach (var item in m_Wrapper.m_CombatActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_CombatActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }

        public CombatActions @Combat => new CombatActions(this);

        public interface IGameplayActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnToggleWalk(InputAction.CallbackContext context);
        }

        public interface ICombatActions
        {
            void OnDrawWeapon(InputAction.CallbackContext context);
            void OnAttackModifier(InputAction.CallbackContext context);
            void OnLightAttack(InputAction.CallbackContext context);
            void OnHeavyAttack(InputAction.CallbackContext context);
            void OnLockOn(InputAction.CallbackContext context);
            void OnTargetSwitchLeft(InputAction.CallbackContext context);
            void OnTargetSwitchRIght(InputAction.CallbackContext context);
        }
    }
}
