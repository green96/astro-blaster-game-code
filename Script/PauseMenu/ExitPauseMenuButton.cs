using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPauseMenuButton : MonoBehaviour
{
    public GameObject Pausemenu; // Kéo thả PauseMenu vào

    public void CloseMenu()
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;

        //Hide mouse cursor again
        Cursor.visible = false;
    }
}
