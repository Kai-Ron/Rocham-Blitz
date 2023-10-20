//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Kieron_Scripts/PlayerActions.inputactions
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

public partial class @PlayerActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""BattleActions"",
            ""id"": ""161759df-8ffb-4de0-9f84-5d3dd8115eeb"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9a932975-ca24-42d2-91f4-ca7e0e6367b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""eaa909a0-f6d3-4c46-9d43-e93ee0972b1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a8f8519a-4ef5-42f8-8cf6-8d895d94cabf"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""780c7d2d-a7d4-49aa-ac17-1e0d1fc670e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9c07bf98-b5eb-4a5e-8689-4228ceb0ae33"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31307e9c-8824-4c69-9ad1-45eebecec439"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. SPEEDLINK COMPETITION PRO>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aef346eb-db9e-4c3b-b059-d7f429ab11c1"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7200a265-2d3d-4e61-b2c1-fafd223babd4"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e88836e9-42bb-4b68-9a1f-489adce46d5b"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. SPEEDLINK COMPETITION PRO>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14993915-c97a-4e39-b193-597bdb442706"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. SPEEDLINK COMPETITION PRO>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BattleActions
        m_BattleActions = asset.FindActionMap("BattleActions", throwIfNotFound: true);
        m_BattleActions_Jump = m_BattleActions.FindAction("Jump", throwIfNotFound: true);
        m_BattleActions_Attack = m_BattleActions.FindAction("Attack", throwIfNotFound: true);
        m_BattleActions_Move = m_BattleActions.FindAction("Move", throwIfNotFound: true);
        m_BattleActions_Throw = m_BattleActions.FindAction("Throw", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // BattleActions
    private readonly InputActionMap m_BattleActions;
    private List<IBattleActionsActions> m_BattleActionsActionsCallbackInterfaces = new List<IBattleActionsActions>();
    private readonly InputAction m_BattleActions_Jump;
    private readonly InputAction m_BattleActions_Attack;
    private readonly InputAction m_BattleActions_Move;
    private readonly InputAction m_BattleActions_Throw;
    public struct BattleActionsActions
    {
        private @PlayerActions m_Wrapper;
        public BattleActionsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_BattleActions_Jump;
        public InputAction @Attack => m_Wrapper.m_BattleActions_Attack;
        public InputAction @Move => m_Wrapper.m_BattleActions_Move;
        public InputAction @Throw => m_Wrapper.m_BattleActions_Throw;
        public InputActionMap Get() { return m_Wrapper.m_BattleActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BattleActionsActions set) { return set.Get(); }
        public void AddCallbacks(IBattleActionsActions instance)
        {
            if (instance == null || m_Wrapper.m_BattleActionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BattleActionsActionsCallbackInterfaces.Add(instance);
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Throw.started += instance.OnThrow;
            @Throw.performed += instance.OnThrow;
            @Throw.canceled += instance.OnThrow;
        }

        private void UnregisterCallbacks(IBattleActionsActions instance)
        {
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Throw.started -= instance.OnThrow;
            @Throw.performed -= instance.OnThrow;
            @Throw.canceled -= instance.OnThrow;
        }

        public void RemoveCallbacks(IBattleActionsActions instance)
        {
            if (m_Wrapper.m_BattleActionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBattleActionsActions instance)
        {
            foreach (var item in m_Wrapper.m_BattleActionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BattleActionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BattleActionsActions @BattleActions => new BattleActionsActions(this);
    public interface IBattleActionsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
    }
}
