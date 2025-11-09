using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //dùng TextMeshPro, 
public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance; // Singleton để dễ gọi ở script khác
    public int score = 0;
    public TextMeshProUGUI scoreText; // nếu dùng TextMeshPro
    // public Text scoreText; // nếu dùng Text UI thường

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}

