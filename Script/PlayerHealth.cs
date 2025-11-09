using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;// Singleton để gọi từ script khác
    
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject turnoffplayer;
    [SerializeField] private GameObject turnoffbullet;
    [SerializeField] private GameObject turnondeathcanvas;
    [SerializeField] private GameObject Current_Score;

    [SerializeField] private Healthbar healthbar;//tham chieu class Healthbar

    [SerializeField] private GameObject ShipModelNormal;
    [SerializeField] private GameObject ShipDeathEffect;

    [SerializeField] private AudioSource audioSourcedamageSound;

    Material material;
    float flash = 0f;
    void Start()
    {
        currentHealth = maxHealth;

        // Khởi tạo thanh máu theo maxHealth
        if (healthbar != null)
            healthbar.SetMaxHealth(maxHealth);

        //lấy material trong SpriteRender ==> GetComponent<SpriteRenderer> Vì ta đã gắn shader material trong SpriteRenderer rồi 
        material = GetComponent<SpriteRenderer>().material;


        // In ra kiểm tra khi bắt đầu
        Debug.Log("Player health start = " + currentHealth);
    }
    //hàm này public đề gọi được từ bên ngoài
    public void CollidWithAsteroid()
    {
        //trừ -20 máu
        currentHealth = currentHealth - 20;
        Debug.Log("Player hit! Health = " + currentHealth);
        //play hiệu ứng âm thanh khi collide với Asteroid
        audioSourcedamageSound.Play();


        //cộng flash lên 1
        flash = flash + 1;
        // gửi giá trị flash mới lên material có này
        material.SetFloat("_FlashAmount", flash);

        //gọi hàm sau 0.3 giây
        Invoke("TurnOffFlashAfterDamage", 0.3f);

        // Cập nhật thanh máu
        if (healthbar != null)
            healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            //Bật ship có hiệu ứng death
            ShipDeathEffect.SetActive(true);
            //Tắt ship không có hiệu ứng
            ShipModelNormal.SetActive(false);
            Invoke("PlayerDie", 1.5f);
        }

    }

    public void CollidWithLazer()
    {
        //trừ -100 máu
        currentHealth = currentHealth - 100;
        Debug.Log("Player hit! Health = " + currentHealth);
        //play hiệu ứng âm thanh khi collide với Asteroid
        audioSourcedamageSound.Play();


        //cộng flash lên 1
        flash = flash + 1;
        // gửi giá trị flash mới lên material có này
        material.SetFloat("_FlashAmount", flash);

        //gọi hàm sau 0.3 giây
        Invoke("TurnOffFlashAfterDamage", 0.3f);

        // Cập nhật thanh máu
        if (healthbar != null)
            healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            //Bật ship có hiệu ứng death
            ShipDeathEffect.SetActive(true);
            //Tắt ship không có hiệu ứng
            ShipModelNormal.SetActive(false);
            Invoke("PlayerDie", 1.5f);
        }
    }

    public void CollidWithPikeBoss()
    {
        //trừ -30 máu
        currentHealth = currentHealth - 30;
        Debug.Log("Player hit! Health = " + currentHealth);
        //play hiệu ứng âm thanh khi collide với Asteroid
        audioSourcedamageSound.Play();


        //cộng flash lên 1
        flash = flash + 1;
        // gửi giá trị flash mới lên material có này
        material.SetFloat("_FlashAmount", flash);

        //gọi hàm sau 0.3 giây
        Invoke("TurnOffFlashAfterDamage", 0.3f);

        // Cập nhật thanh máu
        if (healthbar != null)
            healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            //Bật ship có hiệu ứng death
            ShipDeathEffect.SetActive(true);
            //Tắt ship không có hiệu ứng
            ShipModelNormal.SetActive(false);
            Invoke("PlayerDie", 1.5f);
        }
    }

    void PlayerDie()
    {
        Debug.Log("Player is dead, turning off player object!");
        turnoffplayer.SetActive(false);
        turnoffbullet.SetActive(false);
        Cursor.visible = true;
        Time.timeScale = 0.0f;
        turnondeathcanvas.SetActive(true);
        Current_Score.SetActive(true);
    }

    void TurnOffFlashAfterDamage()
    {
        //trừ flash xuống 1
        flash = flash - 1;
        // gửi giá trị flash mới lên material có này
        material.SetFloat("_FlashAmount", flash);
    }
    
}
