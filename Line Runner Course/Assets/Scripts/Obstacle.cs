using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float moveSpeed;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
