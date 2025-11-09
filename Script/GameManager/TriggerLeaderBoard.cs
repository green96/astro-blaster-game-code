using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLeaderBoard : MonoBehaviour
{
    public GameObject LeaderBoard;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            LeaderBoard.SetActive(true);

            // Hiện con trỏ chuột
            Cursor.visible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LeaderBoard.SetActive(false);

            // Ẩn con trỏ chuột
            Cursor.visible = false;

        }
    }

}
