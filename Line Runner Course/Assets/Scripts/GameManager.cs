using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject playGameUI;
    public GameObject spawner;
    public static GameManager instance;
    public bool gameStarted = false;

    Vector3 originalCameraPosition;

    public GameObject player;

    int lives = 2;
    int score = 0;

    public TMP_Text livesText;
    public TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originalCameraPosition = Camera.main.transform.position;
    }

    public void StartGame()
    {
        gameStarted = true;

        menuUI.SetActive(false);
        playGameUI.SetActive(true);
        spawner.SetActive(true);
    }

    public void GameOver()
    {
        player.SetActive(false);
        spawner.SetActive(false);
        AdsManager.instance.ShowAds(this);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateLives()
    {
        if (lives < 1) { return; }

        lives--;
        livesText.text = $"Lives : {lives}";

        if (lives == 0)
        {
            GameOver();
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = $"Score : {score}";
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Shake()
    {
        StartCoroutine("CameraShake");
    }

    IEnumerator CameraShake()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle * 0.5f;

            Camera.main.transform.position = new Vector3(randomPosition.x, randomPosition.y, originalCameraPosition.z);

            yield return null;
        }

        Camera.main.transform.position = originalCameraPosition;
    }
}
