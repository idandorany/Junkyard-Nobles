using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rhythm : MonoBehaviour
{
    public List<Note> notes;
    private int _inNoteCounter;

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
        
        var isEndOfStep = _inNoteCounter >= notes[index].inputSequence.Count;
        
        if (isEndOfStep)
            _inNoteCounter = 0;

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
}
