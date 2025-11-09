using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Tạo biến static để script khác có thể truy cập
    public static GameManager instance;

    // Lưu điểm hiện tại
    public int score = 0;

    // Liên kết với Text UI hiển thị điểm
    public Text scoreText;

    private void Awake()
    {
        // Đảm bảo chỉ có 1 GameManager tồn tại
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // Cập nhật điểm ban đầu (0)
        UpdateScoreUI();
    }

    // Hàm cộng điểm (được gọi khi player ăn coin)
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    // Hàm cập nhật chữ "Score: x" trên UI
    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }
}
