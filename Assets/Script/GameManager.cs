using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject GameOverText;

    public bool IsGameOver = false;

    public float ScrollSpeed = -1.5f;

    private int score = 0;
    public TextMeshProUGUI ScoreText;

    // Background settings
    public GameObject[] backgrounds; // Array of background GameObjects
    public int[] scoreThresholds;    // Scores to change backgrounds
    private int currentBackgroundIndex = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (IsGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdDie()
    {
        GameOverText.SetActive(true);
        IsGameOver = true;
    }

    public void BirdScored()
    {
        if (IsGameOver)
            return;

        score++;

        ScoreText.text = "SCORE : " + score.ToString();

        // Check if we need to change the background
        if (currentBackgroundIndex < scoreThresholds.Length &&
            score >= scoreThresholds[currentBackgroundIndex])
        {
            ChangeBackground();
        }
    }

    private void ChangeBackground()
    {
        // Deactivate current background
        backgrounds[currentBackgroundIndex].SetActive(false);

        // Move to the next background
        currentBackgroundIndex++;

        // Activate the new background
        if (currentBackgroundIndex < backgrounds.Length)
        {
            backgrounds[currentBackgroundIndex].SetActive(true);
        }
    }
}