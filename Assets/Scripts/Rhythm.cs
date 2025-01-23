using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Rhythm", menuName = "Scriptable Objects/Rhythm")]
public class Rhythm : ScriptableObject
{
    public List<Note> notes;

    public bool IsMatchingNote(Note note, int index)
    {
        if (index >= notes.Count) return false;

        return notes[index] == note;
    }
}

public enum Note
{
    // The whole 4-6 notes will be here.
} 
