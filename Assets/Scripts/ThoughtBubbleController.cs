using UnityEngine;

public class ThoughtBubbleController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager; 
    
    [SerializeField] private GameObject trackOfNotes;

    [SerializeField] private float speedOfTrackScroll;

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
        trackOfNotes.transform.position = new Vector3(1118, 3, 0);
    }
}
