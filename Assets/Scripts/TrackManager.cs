using System;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private TrackController[] trackControllers;
    [SerializeField] private GameManager gameManager;
    private int _trackCounter;

    private void OnEnable()
    {
        gameManager.OnRhythmSectionWin += ChangeActiveTrack;
    }

    private void OnDisable()
    {
        gameManager.OnRhythmSectionWin -= ChangeActiveTrack;
    }

    private void ChangeActiveTrack(int index)
    {
        trackControllers[_trackCounter].gameObject.SetActive(false);
        ++_trackCounter;
        if(_trackCounter < trackControllers.Length)
            trackControllers[_trackCounter].gameObject.SetActive(true);
    }
}
