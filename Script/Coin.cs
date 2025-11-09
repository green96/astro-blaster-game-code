using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem va chạm với player chưa
        if (other.CompareTag("Player"))
        {
            // Cộng điểm
            GameManager.instance.AddScore(1);


            // Cộng điểm lên UI của Leaderboard Và Lên Leaderboard
            ScoreCounter.Instance.AddScore(1);

            // Hủy coin sau khi nhặt
            Destroy(gameObject);
        }
    }
}
