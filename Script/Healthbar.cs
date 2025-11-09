using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this to work with Unity UI
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    
    
    public Slider slider;

    public CanvasGroup canvasGroup;//lay phan tu CanvasGroup bỏ vào biến canvasGroup(giúp thay đổi alpha==> tạo hiệu ứng fade in fade out)


    void Start()
    {
        //canvasGroup.alpha = 0f; // ẩn ban đầu
    }

    public void SetMaxHealth(int health)
    {
        // maxValue = health hien tai ==> tuy chinh theo health da khai bao trong object
        slider.maxValue = health;
        slider.value = health;
    }


   public void SetHealth(int health)
    {
        slider.value = health;


        // hiện health bar
        canvasGroup.alpha = 1f;//hiển thị lên

        // sau 2 giây ẩn đi
        CancelInvoke(); // reset nếu gọi nhiều lần(Dùng CancelInvoke() để huỷ các Invoke đang chờ, rồi gọi lại Invoke("Hide", 2f) mới nhất.)
        
        Invoke("Hide", 2f);// Gọi hàm Hide() sau 2 giây
    }


    void Hide()
    {
        canvasGroup.alpha = 0f;//ần
    }
}
