using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHitbullet : MonoBehaviour
{
    [SerializeField] private int health = 40;
    [SerializeField] private GameObject TurnOffAsteroid;
    [SerializeField] private GameObject TurnOnAsteroidExplode;

    

    Material material;
    float flash = 0f;
    void Start()
    {
        // lấy material trong SpriteRender ==> GetComponent < SpriteRenderer > Vì ta đã gắn shader material trong SpriteRenderer rồi
        material = GetComponent<SpriteRenderer>().material;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health = health - 20;
            //cộng flash lên 1
            flash = flash + 1;
            // gửi giá trị flash mới lên material có này
            material.SetFloat("_FlashAmount", flash);
            //gọi hàm sau 0.3 giây
            Invoke("TurnOffFlashAfterDamage", 0.3f);
        }

        if (health <= 0)
        {
            TurnOffAsteroid.SetActive(false);
            TurnOnAsteroidExplode.SetActive(true);

            Invoke("TurnOffAsteroidExplode", 0.5f);
        }
    }
    void TurnOffAsteroidExplode()
    {
        TurnOnAsteroidExplode.SetActive(false);
    }
    void TurnOffFlashAfterDamage()
    {
        //trừ flash xuống 1
        flash = flash - 1;
        // gửi giá trị flash mới lên material có này
        material.SetFloat("_FlashAmount", flash);
    }
}
