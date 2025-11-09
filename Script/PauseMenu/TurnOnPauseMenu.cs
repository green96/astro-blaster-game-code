using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnPauseMenu : MonoBehaviour
{

    //[SerializeField] để có thể kéo thả(tham chiếu) trên unity editor mà không cần phải để public
    [SerializeField] private GameObject PauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
            //Time.timeScale = 0.0f; đóng băng (pause) toàn bộ các hoạt động dựa trên thời gian trong scene — nói cách khác là dừng game lại.
            Time.timeScale = 0.0f;
        }
    }
}
