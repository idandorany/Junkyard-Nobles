using UnityEngine;

public class MovingScreen : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

       //if (transform.position.x < 10f)
       //{
       //    transform.position = new Vector3(-10f, transform.position.y, transform.position.z);
       //}
    }
}
