using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<Sprite> _sprites;
    private int _imageListIndex = 0;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private GameObject _imageObject;
    [SerializeField] private Image _image;

    private event UnityAction OnCinematicFinished;
    
    private void Start()
    {
        gameManager.OnRhythmSectionWin += ImagerChangerCalled;
        StopImageDisplay();
    }

    void Update()
    {
    }

    private IEnumerator StartCinematicSequence()
    {
        _videoPlayer.Prepare();
        yield return new WaitForSeconds(1.5f);
        StopImageDisplay();
        StartCinematic();
        yield return new WaitForSeconds((float)_videoPlayer.length - 0.3f);//Video duration variable
        StartImageDisplay();
        yield return new WaitForSeconds(3);//sprite display duration
        OnCinematicFinished?.Invoke();
    }
    
    private void StartCinematic()
    {
        _videoPlayer.Play();
    }

    private void StartImageDisplay()
    {
        _imageObject.SetActive(true);
        _image.sprite = _sprites[_imageListIndex];
    }

    private void StopImageDisplay()
    {
        _imageObject.SetActive(false);
    }

    private void ImagerChangerCalled(int index)
    {
        _imageListIndex = index;
        StartCoroutine(StartCinematicSequence());
    }

    
}
