using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private NotesScriptable notesScriptable;
    public List<ArrowKey> inputSequence;
    
    void Start()
    {
        foreach (var arrowKey in notesScriptable.inputSequence)
        {
            inputSequence.Add(arrowKey);
        }
    }

}
