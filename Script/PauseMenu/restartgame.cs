using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartgame : MonoBehaviour
{
    //public để có thể gọi qua sự kiện onclick
    public void Restart()
    {
        Time.timeScale = 1.0f;//tắt đóng băng game khi restart

        //restart lại Scene theo ActiveScene().name ==> tên cùa Scene đang chạy
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
