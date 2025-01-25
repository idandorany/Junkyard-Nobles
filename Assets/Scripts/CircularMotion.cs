using UnityEngine;

public class LoopingBubblyMotion : MonoBehaviour
{
    public Vector3[] points;
    public float speed = 2f;
    public float verticalAmplitude = 0.5f;
    public float verticalFrequency = 2f;

    private int currentPointIndex = 0;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private float progress = 0f;

    void Start()
    {
        if (points.Length < 2) return;

        startPoint = points[0];
        endPoint = points[1];
    }

    void Update()
    {
        if (points.Length < 2) return;

        progress += speed * Time.deltaTime / Vector3.Distance(startPoint, endPoint);

        if (progress >= 1f)
        {
            progress = 0f;
            currentPointIndex = (currentPointIndex + 1) % points.Length;
            startPoint = endPoint;
            endPoint = points[currentPointIndex];
        }

        Vector3 horizontalPosition = Vector3.Lerp(startPoint, endPoint, progress);
        float verticalOffset = Mathf.Sin(progress * Mathf.PI * 2 * verticalFrequency) * verticalAmplitude;
        transform.position = horizontalPosition + new Vector3(0, verticalOffset, 0);
    }
}