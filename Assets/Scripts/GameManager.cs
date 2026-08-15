using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PipeSpawner pipeSpawner;

    [SerializeField]
    PlayerController player;

    [SerializeField]
    GameObject playButton;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    TMPro.TMP_Text scoreText;

    int score = 0;

    public void StartGame()
    {
        playButton.SetActive(false);

        pipeSpawner.StartSpawning();
        player.StartGame();
    }

    public void AddScore()
    {
        score++;

        Debug.Log("Score: " + score);
        
        if (scoreText == null)
        {
            Debug.LogError("ERROR: scoreText is NULL!");
            return;
        }

        Debug.Log("scoreText is assigned: " + scoreText.gameObject.name);

        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);

        pipeSpawner.StopSpawning();

        player.GameOver();

        PipeMovement[] pipes = FindObjectsByType<PipeMovement>();

        foreach (PipeMovement pipe in pipes)
        {
            pipe.StopMoving();
        }
    }

    public void RestartGame()
    {
        gameOverPanel.SetActive(false);

        player.ResetPlayer();

        PipeMovement[] pipes = FindObjectsByType<PipeMovement>();

        foreach (PipeMovement pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }

        score = 0;
        scoreText.text = score.ToString();
    }
}