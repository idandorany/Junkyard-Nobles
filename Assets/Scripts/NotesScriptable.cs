using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NotesScriptable", menuName = "Scriptable Objects/NotesScriptable")]
public class NotesScriptable : ScriptableObject
{
    public List<ArrowKey> inputSequence;
}

public enum ArrowKey
{
    ArrowUp,
    ArrowDown,
    ArrowRight,
    ArrowLeft,
    ArrowNone,
} 