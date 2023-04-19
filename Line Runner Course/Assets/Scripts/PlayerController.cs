using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject paticle;
    float playerYPosition;

    void Start()
    {
        playerYPosition = transform.position.y;
    }

    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            if (!paticle.activeInHierarchy)
            {
                paticle.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                PositionSwitch();
            }
        }
    }

    void PositionSwitch()
    {
        playerYPosition = -playerYPosition;

        transform.position = new Vector3(transform.position.x, playerYPosition, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            GameManager.instance.UpdateLives();
            GameManager.instance.Shake();
        }
    }
}
