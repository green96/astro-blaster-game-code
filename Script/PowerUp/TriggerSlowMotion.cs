using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSlowMotion : MonoBehaviour
{
    //[SerializeField] ==> cho tham chiếu trong unity editor mà không cần khai báo public
    [SerializeField]  private GameObject TurnOffPowerup;
    [SerializeField] private GameObject TurnOnWordPowerup;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0.7f;//giảm thời gian ==> tạo hiệu ứng slow motion
            //tắt nó đi
            TurnOffPowerup.SetActive(false);
            //TurnOnWordPowerup
            TurnOnWordPowerup.SetActive(true);

            Invoke("ReturnToNormal", 7f);//gọi hàm này sau 7 giây
        }
    }

    private void ReturnToNormal()
    {
        //thời gian bình thường lại
        Time.timeScale = 1.0f;

        //tắt để giảm lag
        TurnOnWordPowerup.SetActive(false);
    } 
}
