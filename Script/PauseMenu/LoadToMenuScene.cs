using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadToMenuScene : MonoBehaviour
{
    public void LoadMenuScene()
    {
        Time.timeScale = 1.0f; //ngừng đóng băng rồi load scene mới
        SceneManager.LoadScene("MENU 1");
    }
}
