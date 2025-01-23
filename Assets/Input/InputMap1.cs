//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Input/InputMap1.inputactions
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

public partial class @InputMap1: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMap1()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap1"",
    ""maps"": [
        {
            ""name"": ""InputMap"",
            ""id"": ""439b4903-4272-47c3-8a38-23c1ecd86189"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9a58f434-3ea9-4ead-92e5-384bf12515b6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""48a0f686-3640-4bd5-b8d4-f478ea517729"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b96b9f8e-3b36-4a11-9405-ec396695c18b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c193e2c-385c-455e-8297-c5d4d96afbfe"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""591e0c24-b35f-43db-87b8-85cb6d1ef9c2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InputMap
        m_InputMap = asset.FindActionMap("InputMap", throwIfNotFound: true);
        m_InputMap_Interact = m_InputMap.FindAction("Interact", throwIfNotFound: true);
    }

    ~@InputMap1()
    {
        UnityEngine.Debug.Assert(!m_InputMap.enabled, "This will cause a leak and performance issues, InputMap1.InputMap.Disable() has not been called.");
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

    // InputMap
    private readonly InputActionMap m_InputMap;
    private List<IInputMapActions> m_InputMapActionsCallbackInterfaces = new List<IInputMapActions>();
    private readonly InputAction m_InputMap_Interact;
    public struct InputMapActions
    {
        private @InputMap1 m_Wrapper;
        public InputMapActions(@InputMap1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_InputMap_Interact;
        public InputActionMap Get() { return m_Wrapper.m_InputMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputMapActions set) { return set.Get(); }
        public void AddCallbacks(IInputMapActions instance)
        {
            if (instance == null || m_Wrapper.m_InputMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputMapActionsCallbackInterfaces.Add(instance);
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(IInputMapActions instance)
        {
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
        }

        public void RemoveCallbacks(IInputMapActions instance)
        {
            if (m_Wrapper.m_InputMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputMapActions instance)
        {
            foreach (var item in m_Wrapper.m_InputMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputMapActions @InputMap => new InputMapActions(this);
    public interface IInputMapActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
}
