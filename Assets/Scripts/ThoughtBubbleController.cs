using UnityEngine;

public class ThoughtBubbleController : MonoBehaviour
{
    [SerializeField] private GameObject _trackOfNotes;

    [SerializeField] private float speedOfTrackScroll = 0f;
    private bool isTrackMoving;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _trackOfNotes.transform.Translate(Vector2.left * speedOfTrackScroll * Time.deltaTime);
    }
}
