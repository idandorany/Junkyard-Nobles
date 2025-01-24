using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerExitLose : MonoBehaviour
{
    public event UnityAction LoseEvent;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("ArrowImage")) return;
        
        LoseEvent?.Invoke();
    }
}
