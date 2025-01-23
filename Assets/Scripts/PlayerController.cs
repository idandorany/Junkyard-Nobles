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

    private void OnEnable()
    {
        
        inputActions.interact.Up.Enable();
        inputActions.interact.Down.Enable();
        inputActions.interact.Left.Enable();
        inputActions.interact.Right.Enable();

        inputActions.interact.Up.performed += ctx => HandleKeyPress("Up");
        inputActions.interact.Down.performed += ctx => HandleKeyPress("Down");
        inputActions.interact.Left.performed += ctx => HandleKeyPress("Left");
        inputActions.interact.Right.performed += ctx => HandleKeyPress("Right");
    }

    private void OnDisable()
    {
        
        inputActions.interact.Up.Disable();
        inputActions.interact.Down.Disable();
        inputActions.interact.Left.Disable();
        inputActions.interact.Right.Disable();

        inputActions.interact.Up.performed -= ctx => HandleKeyPress("Up");
        inputActions.interact.Down.performed -= ctx => HandleKeyPress("Down");
        inputActions.interact.Left.performed -= ctx => HandleKeyPress("Left");
        inputActions.interact.Right.performed -= ctx => HandleKeyPress("Right");
    }

    private void HandleKeyPress(string key)
    {
        Debug.Log($"Key Pressed: {key}");
        OnKeyPressed?.Invoke(key); 
    }
}
