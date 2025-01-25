using UnityEngine;
using UnityEngine.Serialization;

public class ThoughtBubbleController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager; 
    
    [SerializeField] private GameObject trackOfNotes;

    [SerializeField] private float speedOfTrackScroll;
    [SerializeField] private Transform resetTrackPosition;

    private void OnEnable()
    {
        gameManager.OnRhythmSectionFail += RestartTrack;
    }

    void Update()
    {
        trackOfNotes.transform.Translate(Vector2.left * (speedOfTrackScroll * Time.deltaTime));
    }

    public void RestartTrack()
    {
        trackOfNotes.transform.position = resetTrackPosition.position;
    }
}
