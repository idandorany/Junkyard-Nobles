using System;
using UnityEngine;

public class VfxManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject movingNote;
    [SerializeField] private Transform startPosition;

    private void OnEnable()
    {
        gameManager.OnRhythmSectionWin += PlayMovingNote;
    }

    private void PlayMovingNote(int index)
    {
        Instantiate(movingNote, startPosition.position, Quaternion.identity);
    }
}
