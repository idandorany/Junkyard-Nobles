using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    [SerializeField] private PlayerController rhythmInput;

    private void OnEnable()
    {
        rhythmInput.OnKeyPressed += HandleRhythmKeyPress;
    }

    private void OnDisable()
    {
        rhythmInput.OnKeyPressed -= HandleRhythmKeyPress;
    }

    private void HandleRhythmKeyPress(string key)
    {
        // Check if the key press matches the beat/timing
        Debug.Log($"Handle key press: {key}");
        // Add your scoring and feedback logic here
    }
}
