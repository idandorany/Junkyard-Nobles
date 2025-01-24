using System.Collections.Generic;
using UnityEngine;

public class Rhythm : MonoBehaviour
{
    public List<Note> notes;
    [SerializeField] private GameManager gameManager;
    private int _inNoteCounter;
    private int _insideScore;

    private void OnEnable()
    {
        gameManager.OnRhythmSectionFail += ResetInNoteCounter;
    }

    private void OnDisable()
    {
        gameManager.OnRhythmSectionFail += ResetInNoteCounter;
    }

    public bool IsMatchingInput(ArrowKey arrowKey, int index)
    {
        if (index >= notes.Count) return false;
        
        var isMatchingInput = notes[index].inputSequence[_inNoteCounter] == arrowKey;

        if (!isMatchingInput) return false;
        
        ++_inNoteCounter;
        
        return true;
    }

    public bool IsEndOfStep(int index)
    {
        if (index >= notes.Count) return false;
        
        var isEndOfStep = _inNoteCounter == notes[index].inputSequence.Count;
        //Debug.Log(_inNoteCounter);
        if (isEndOfStep)
            _inNoteCounter = 0;
        Debug.Log(_inNoteCounter);
        return isEndOfStep;
    }

    public bool IsEndOfRhythm(int index)
    {
        return index >= notes.Count;
    }

    public AudioClip GetNoteClip(int index)
    {
        return index >= notes.Count ? null : notes[index].noteAudioClip;
    }

    public void ResetInNoteCounter()
    {
        _inNoteCounter = 0;
    }
}
