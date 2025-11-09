using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolvePlantOnStart : MonoBehaviour
{
    Material material;
    float fade = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //lấy material trong SpriteRender ==> GetComponent<SpriteRenderer> Vì ta đã gắn shader material trong SpriteRenderer rồi 
        material = GetComponent<SpriteRenderer>().material;


    }

    // Update is called once per frame
    void Update()
    {
        if (fade > 0f)
        {
            //trừ dần dần giá trị biến fade theo giấy của khung hình(Time.deltaTime)
            fade = fade - Time.deltaTime;

            // gửi giá trị fade mới lên material có này
            material.SetFloat("_Fade", fade);
        }

    }
}
