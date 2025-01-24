using UnityEngine;

public class SpawnAndMoveObject3D : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnPoint;
    public Transform targetLocation;
    public float moveSpeed = 2f;
    public float rotationSpeed = 360f;
    public float verticalMovementHeight = 1f;

    private GameObject spawnedObject;
    private float startY;

    public void SpawnObject()
    {
        if (spawnPoint != null)
        {
            spawnedObject = Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);
            startY = spawnPoint.position.y;

            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false;
                rb.isKinematic = true;
            }

            if (spawnedObject != null && targetLocation != null)
            {
                RotateAndMoveObject(spawnedObject.transform, targetLocation.position);
            }
        }
    }

    void Start()
    {
        SpawnObject();
    }

    public void RotateAndMoveObject(Transform objTransform, Vector3 targetPosition)
    {
        StartCoroutine(RotateWhileMoving(objTransform, targetPosition));
    }

    private System.Collections.IEnumerator RotateWhileMoving(Transform objTransform, Vector3 targetPosition)
    {
        Vector3 startPosition = objTransform.position;
        float totalDistance = Vector3.Distance(startPosition, targetPosition);
        float distanceTraveled = 0f;
        float verticalMovementProgress = 0f;

        while (distanceTraveled < totalDistance)
        {
            objTransform.position = Vector3.MoveTowards(objTransform.position, targetPosition, moveSpeed * Time.deltaTime);
            distanceTraveled = Vector3.Distance(startPosition, objTransform.position);

            verticalMovementProgress += Time.deltaTime * moveSpeed / totalDistance;
            float verticalOffset = Mathf.Sin(verticalMovementProgress * Mathf.PI) * verticalMovementHeight;
            objTransform.position = new Vector3(objTransform.position.x, startY + verticalOffset, objTransform.position.z);

            float rotationStep = (rotationSpeed / totalDistance) * distanceTraveled;
            objTransform.rotation = Quaternion.Euler(0, rotationStep, 0);

            yield return null;
        }

        objTransform.position = new Vector3(targetPosition.x, startY, targetPosition.z);
        objTransform.rotation = Quaternion.identity;
    }
}
