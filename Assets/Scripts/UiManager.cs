using System;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject[] bubbles;
    private int _bubbleCounter;

    private void OnEnable()
    {
        gameManager.OnInputSuccession += PopBubble;
    }

    private void OnDisable()
    {
        gameManager.OnInputSuccession -= PopBubble;
    }

    public void PopBubble()
    {
        if (_bubbleCounter >= bubbles.Length) return;
        
        bubbles[_bubbleCounter].SetActive(false);
        ++_bubbleCounter;
    }
}
