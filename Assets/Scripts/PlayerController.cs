using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private RhythmInputActions inputActions;

    public event System.Action<string> OnKeyPressed; 

    private void Awake()
    {
        inputActions = new RhythmInputActions();
    }

    private event System.Action<InputAction.CallbackContext> onUpPressed;
    private event System.Action<InputAction.CallbackContext> onDownPressed;
    private event System.Action<InputAction.CallbackContext> onLeftPressed;
    private event System.Action<InputAction.CallbackContext> onRightPressed;

    private void OnEnable()
    {
        onUpPressed = ctx => HandleKeyPress("Up");
        onDownPressed = ctx => HandleKeyPress("Down");
        onLeftPressed = ctx => HandleKeyPress("Left");
        onRightPressed = ctx => HandleKeyPress("Right");

        inputActions.interact.Up.performed += onUpPressed;
        inputActions.interact.Down.performed += onDownPressed;
        inputActions.interact.Left.performed += onLeftPressed;
        inputActions.interact.Right.performed += onRightPressed;

        inputActions.interact.Up.Enable();
        inputActions.interact.Down.Enable();
        inputActions.interact.Left.Enable();
        inputActions.interact.Right.Enable();
    }

    private void OnDisable()
    {
        inputActions.interact.Up.performed -= onUpPressed;
        inputActions.interact.Down.performed -= onDownPressed;
        inputActions.interact.Left.performed -= onLeftPressed;
        inputActions.interact.Right.performed -= onRightPressed;

        inputActions.interact.Up.Disable();
        inputActions.interact.Down.Disable();
        inputActions.interact.Left.Disable();
        inputActions.interact.Right.Disable();
    }

    private void HandleKeyPress(string key)
    {
        Debug.Log($"Key Pressed: {key}");
        OnKeyPressed?.Invoke(key); 
    }
}
