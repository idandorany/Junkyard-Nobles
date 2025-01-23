using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Notes", menuName = "Scriptable Objects/Notes")]
public class Notes : ScriptableObject
{
    public List<ArrowKey> inputSequence;
}

public enum ArrowKey
{
    // The whole 4-6 notes will be here.
} 