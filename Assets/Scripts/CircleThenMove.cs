using UnityEngine;

public class CircleOnceThenMove : MonoBehaviour
{
    public Transform targetLocation; // Assign the final target location in the Inspector
    public Transform centerPoint;   // Center point for circular motion
    public float circleRadius = 5f; // Radius of the circle
    public float circleSpeed = 2f;  // Speed of circular movement (radians per second)
    public float moveSpeed = 5f;    // Speed for moving to the target

    private bool isMovingToTarget = false; // Flag to switch from circular motion to target movement

    void Start()
    {
        // Start the circular motion coroutine
        StartCoroutine(PerformCircleThenMove());
    }

    void Update()
    {
        if (isMovingToTarget)
        {
            // Move toward the target location
            transform.position = Vector3.MoveTowards(transform.position, targetLocation.position, moveSpeed * Time.deltaTime);

            // Stop moving when close to the target
            if (Vector3.Distance(transform.position, targetLocation.position) < 0.01f)
            {
                isMovingToTarget = false; // Optional: Trigger another action here if needed
            }
        }
    }

    private System.Collections.IEnumerator PerformCircleThenMove()
    {
        float angle = 0f; // Start angle in radians

        // Perform a single 360-degree circular motion
        while (angle < 2 * Mathf.PI) // 2 * PI radians = 360 degrees
        {
            // Increment the angle based on circle speed and time
            angle += circleSpeed * Time.deltaTime;

            // Calculate the circular position
            float x = centerPoint.position.x + Mathf.Cos(angle) * circleRadius;
            float z = centerPoint.position.z + Mathf.Sin(angle) * circleRadius;

            // Update the object's position
            transform.position = new Vector3(x, transform.position.y, z);

            yield return null;
        }

        // Switch to linear movement toward the target
        isMovingToTarget = true;
    }
}