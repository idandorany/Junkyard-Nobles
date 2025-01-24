using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private RhythmInputActions _inputActions;

    public event System.Action OnUpPressed;
    public event System.Action OnDownPressed;
    public event System.Action OnLeftPressed;
    public event System.Action OnRightPressed;

    public event System.Action<string> OnKeyPressed;

    private void Awake()
    {
        _inputActions = new RhythmInputActions();
    }

    private void OnEnable()
    {
        // Subscribe to input actions with explicit methods
        _inputActions.interact.Up.performed += OnUpInput;
        _inputActions.interact.Down.performed += OnDownInput;
        _inputActions.interact.Left.performed += OnLeftInput;
        _inputActions.interact.Right.performed += OnRightInput;

        // Enable input actions
        _inputActions.interact.Up.Enable();
        _inputActions.interact.Down.Enable();
        _inputActions.interact.Left.Enable();
        _inputActions.interact.Right.Enable();
    }

    private void OnDisable()
    {
        // Unsubscribe using explicit methods
        _inputActions.interact.Up.performed -= OnUpInput;
        _inputActions.interact.Down.performed -= OnDownInput;
        _inputActions.interact.Left.performed -= OnLeftInput;
        _inputActions.interact.Right.performed -= OnRightInput;

        // Disable input actions
        _inputActions.interact.Up.Disable();
        _inputActions.interact.Down.Disable();
        _inputActions.interact.Left.Disable();
        _inputActions.interact.Right.Disable();
    }

    private void OnUpInput(InputAction.CallbackContext _)
    {
        HandleKeyPress("Up", OnUpPressed);
    }

    private void OnDownInput(InputAction.CallbackContext _)
    {
        HandleKeyPress("Down", OnDownPressed);
    }

    private void OnLeftInput(InputAction.CallbackContext _)
    {
        HandleKeyPress("Left", OnLeftPressed);
    }

    private void OnRightInput(InputAction.CallbackContext _)
    {
        HandleKeyPress("Right", OnRightPressed);
    }

    private void HandleKeyPress(string key, System.Action keyEvent)
    {
        //Debug.Log($"Key Pressed: {key}");
        OnKeyPressed?.Invoke(key); // Invoke the generic key event
        keyEvent?.Invoke();       // Invoke the specific key event
    }
}


