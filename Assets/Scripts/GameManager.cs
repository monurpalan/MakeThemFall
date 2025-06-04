using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        score = 0;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            gameOverPanel.SetActive(false);
        }

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}