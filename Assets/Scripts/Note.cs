using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public List<ArrowKey> inputSequence;
    
    [SerializeField] private NotesScriptable notesScriptable;
    public AudioClip noteAudioClip;
    
    void Start()
    {
        foreach (var arrowKey in notesScriptable.inputSequence)
        {
            inputSequence.Add(arrowKey);
        }
    }

}
