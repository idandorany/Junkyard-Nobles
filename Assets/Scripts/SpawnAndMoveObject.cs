using UnityEngine;

public class SpawnAndMoveObject3D : MonoBehaviour
{
    public GameObject objectPrefab; 
    public float moveSpeed = 2f; 

    private GameObject spawnedObject;

    
    public void SpawnObject(Vector3 spawnPosition)
    {
        
        spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
    void Start()
    {
        
        SpawnObject(new Vector3(0, 1, 0));

        
        MoveObjectTo(new Vector3(5, 1, 5));
    }


    public void MoveObjectTo(Vector3 targetPosition)
    {
        if (spawnedObject != null)
        {
            StartCoroutine(MoveToPosition(spawnedObject.transform, targetPosition));
        }
        else
        {
            Debug.LogWarning("No object spawned to move!");
        }
    }

    
    private System.Collections.IEnumerator MoveToPosition(Transform objTransform, Vector3 targetPosition)
    {
        while (Vector3.Distance(objTransform.position, targetPosition) > 0.01f)
        {
            objTransform.position = Vector3.MoveTowards(objTransform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        objTransform.position = targetPosition;
    }
}