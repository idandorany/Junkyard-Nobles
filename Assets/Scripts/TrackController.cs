using UnityEngine;

public class TrackController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager; 
    [SerializeField] private GameObject trackOfNotes;
    [SerializeField] private float speedOfTrackScroll;
    [SerializeField] private Transform resetTrackPosition;
    [SerializeField] private int timeToWait;
    private float _timer;

    private void OnEnable()
    {
        gameManager.OnRhythmSectionFail += RestartTrack;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= timeToWait)
            trackOfNotes.transform.Translate(Vector2.left * (speedOfTrackScroll * Time.deltaTime));
    }

    public void RestartTrack()
    {
        trackOfNotes.transform.position = resetTrackPosition.position;
    }
}
