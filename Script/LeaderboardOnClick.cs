using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardOnClick : MonoBehaviour
{
    [SerializeField] private GameObject leaderboard;
    [SerializeField] private GameObject deathmenu;
    [SerializeField] private GameObject CurrentScore;
    public void TurnOnLeaderBoard()
    {
        leaderboard.SetActive(true);
        deathmenu.SetActive(false);
        CurrentScore.SetActive(false);
        Cursor.visible = false;
    }
}
