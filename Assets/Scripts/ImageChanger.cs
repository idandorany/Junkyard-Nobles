using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Video;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject imageObject;
    [SerializeField] private Image image;
    private int _imageListIndex;

    private event UnityAction OnCinematicFinished;

    private void OnEnable()
    {
        gameManager.OnRhythmSectionWin += OnLevelPass;
    }

    private void OnDisable()
    {
        gameManager.OnRhythmSectionWin -= OnLevelPass;
    }

    private void Start()
    {
        StopImageDisplay();
        ImagerChangerCalled(0);
    }

    private IEnumerator StartCinematicSequence()
    {
        videoPlayer.Prepare();
        yield return new WaitForSeconds(1.5f);
        StopImageDisplay();
        StartCinematic();
        yield return new WaitForSeconds((float)videoPlayer.length - 0.3f);//Video duration variable
        StartImageDisplay();
        yield return new WaitForSeconds(3);//sprite display duration
        OnCinematicFinished?.Invoke();
        ++_imageListIndex;
    }

    private IEnumerator PassLevel()
    {
        yield return new WaitForSeconds(12.0f);
        ImagerChangerCalled(0);
    }
    
    private void StartCinematic()
    {
        videoPlayer.Play();
    }

    private void StartImageDisplay()
    {
        imageObject.SetActive(true);
        image.sprite = sprites[_imageListIndex];
    }

    private void StopImageDisplay()
    {
        imageObject.SetActive(false);
    }

    private void ImagerChangerCalled(int index)
    {
        StartCoroutine(StartCinematicSequence());
    }

    private void OnLevelPass(int index)
    {
        StartCoroutine(PassLevel());
    }
}
