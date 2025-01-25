using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public event UnityAction<ArrowKey> ArrowTriggeredEvent;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("ArrowImage")) return;
        
        var arrowTrigger = other.GetComponent<ArrowTrigger>();
        gameManager.AddToQueue(arrowTrigger);
    }
}
