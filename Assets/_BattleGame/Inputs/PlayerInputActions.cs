// GENERATED AUTOMATICALLY FROM 'Assets/_BattleGame/Inputs/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""29feeb1e-a17b-406d-bc4c-8e63eb23f5da"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a2ac3ead-0c74-4e2e-822a-46369111ce99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""0bb03eeb-026e-40a8-8b52-fd6d6a2ed76c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""03516720-a2e1-45c9-b566-505d6eb6f8dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrevWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""49ebce91-a6a9-4c59-b278-16a6192f2051"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""04c335d4-4217-44f4-b6d6-5f8f5fc0ac71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""660077eb-d1ae-4962-90cb-be03f6de3be2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f9cbe6d-c274-44c8-8ab5-43dfa6866f21"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""67014764-1447-4bd3-bbc5-15d32dc6d689"",
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
                    ""id"": ""95a6e2e8-4e97-49ff-bfff-1ac03f4fcaf0"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""89a7df81-ab6d-4620-9932-358f20514939"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7a64dcf9-104f-4fee-9593-fc480f110727"",
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
                    ""id"": ""c322bcca-df16-45ae-92d8-afa3bd11119d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f6d4b179-02ef-41b4-a62a-b0e3f6c709b7"",
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
                    ""id"": ""c58af59e-0f22-4837-b41b-d5d7b506c0d2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7c1848d2-a049-4bc3-90ac-62ae71459016"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2c27c074-0c89-4a5a-bdb5-3c62ef319e9a"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5f3516d2-ad06-462a-b217-c045d605c38b"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0f2ed9b9-7325-473a-8935-41a66943ac41"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50e81c4f-c9bd-4e22-a07b-cd25ebc25c61"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c4cb704-da68-4996-9f7c-aae6670bccd4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d3a51ad-a422-4acd-acc2-fec332cf012a"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46266cd7-e136-468f-b5e3-33482a1b22fc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7261a64-b1e4-400d-8a72-574d620d9e5b"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CharacterSelect"",
            ""id"": ""3330a272-5a63-43ac-aa67-8e384a8d31d8"",
            ""actions"": [
                {
                    ""name"": ""ChangeCharacter"",
                    ""type"": ""Button"",
                    ""id"": ""c551d299-223b-45f1-addf-56df783ea6ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b7bea4b9-5a88-48a6-8922-8c6b35d554f8"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97321234-b488-41ac-8404-e1656b683131"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""ChangeCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_NextWeapon = m_Player.FindAction("NextWeapon", throwIfNotFound: true);
        m_Player_PrevWeapon = m_Player.FindAction("PrevWeapon", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        // CharacterSelect
        m_CharacterSelect = asset.FindActionMap("CharacterSelect", throwIfNotFound: true);
        m_CharacterSelect_ChangeCharacter = m_CharacterSelect.FindAction("ChangeCharacter", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_NextWeapon;
    private readonly InputAction m_Player_PrevWeapon;
    private readonly InputAction m_Player_Fire;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @NextWeapon => m_Wrapper.m_Player_NextWeapon;
        public InputAction @PrevWeapon => m_Wrapper.m_Player_PrevWeapon;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @NextWeapon.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextWeapon;
                @NextWeapon.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextWeapon;
                @NextWeapon.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextWeapon;
                @PrevWeapon.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevWeapon;
                @PrevWeapon.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevWeapon;
                @PrevWeapon.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevWeapon;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @NextWeapon.started += instance.OnNextWeapon;
                @NextWeapon.performed += instance.OnNextWeapon;
                @NextWeapon.canceled += instance.OnNextWeapon;
                @PrevWeapon.started += instance.OnPrevWeapon;
                @PrevWeapon.performed += instance.OnPrevWeapon;
                @PrevWeapon.canceled += instance.OnPrevWeapon;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // CharacterSelect
    private readonly InputActionMap m_CharacterSelect;
    private ICharacterSelectActions m_CharacterSelectActionsCallbackInterface;
    private readonly InputAction m_CharacterSelect_ChangeCharacter;
    public struct CharacterSelectActions
    {
        private @PlayerInputActions m_Wrapper;
        public CharacterSelectActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ChangeCharacter => m_Wrapper.m_CharacterSelect_ChangeCharacter;
        public InputActionMap Get() { return m_Wrapper.m_CharacterSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterSelectActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterSelectActions instance)
        {
            if (m_Wrapper.m_CharacterSelectActionsCallbackInterface != null)
            {
                @ChangeCharacter.started -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnChangeCharacter;
                @ChangeCharacter.performed -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnChangeCharacter;
                @ChangeCharacter.canceled -= m_Wrapper.m_CharacterSelectActionsCallbackInterface.OnChangeCharacter;
            }
            m_Wrapper.m_CharacterSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ChangeCharacter.started += instance.OnChangeCharacter;
                @ChangeCharacter.performed += instance.OnChangeCharacter;
                @ChangeCharacter.canceled += instance.OnChangeCharacter;
            }
        }
    }
    public CharacterSelectActions @CharacterSelect => new CharacterSelectActions(this);
    public interface IPlayerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnNextWeapon(InputAction.CallbackContext context);
        void OnPrevWeapon(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
    public interface ICharacterSelectActions
    {
        void OnChangeCharacter(InputAction.CallbackContext context);
    }
}
