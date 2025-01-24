using UnityEngine;

public class SpawnAndMoveObject3D : MonoBehaviour
{
    public GameObject objectPrefab; 
    public Transform targetLocation; 
    public float moveSpeed = 2f;    
    public float rotationSpeed = 360f; 
    public float verticalMovementHeight = 1f; 

    private GameObject spawnedObject;

    public void SpawnObject(Vector3 spawnPosition)
    {
        spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

        if (spawnedObject != null && targetLocation != null)
        {
            RotateAndMoveObject(spawnedObject.transform, targetLocation.position);
        }
        else
        {
            Debug.LogWarning("No target location assigned!");
        }
    }

    void Start()
    {
        SpawnObject(new Vector3(0, 1, 0));
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

        float startY = startPosition.y; 
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

        objTransform.position = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);


        objTransform.rotation = Quaternion.identity;
    }
}
