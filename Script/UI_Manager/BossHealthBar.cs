using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthBar : MonoBehaviour
{

    private static BossHealthBar instance;

    public static BossHealthBar Instance { get => instance; }


    [SerializeField] private Slider healthBar;
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100; // Lưu max health để reset
    [SerializeField] private GameObject LeaderBoard;

    [SerializeField] private GameObject Boss;

    [SerializeField] private AudioSource audioSourcedamageSound;
    private bool state = true;

    Material material;
    float flash = 0f;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        maxHealth = health; // Lưu max health ban đầu
        healthBar.maxValue = health;

        //lấy material trong SpriteRender ==> GetComponent<SpriteRenderer> Vì ta đã gắn shader material trong SpriteRenderer rồi 
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        this.CheckIfLessThan50HP();
    }

    public virtual int DecreaseHealth(int damage)
    {
        health -= damage;
        //play hiệu ứng âm thanh khi boss bị - máu
        audioSourcedamageSound.Play();
        //cộng flash lên 1
        flash = flash + 1;
        // gửi giá trị flash mới lên material có này
        material.SetFloat("_FlashAmount", flash);

        //gọi hàm sau 0.3 giây
        Invoke("TurnOffFlashAfterDamage", 0.3f);



        if (health <= 0)
        {
            Death(health);
            Time.timeScale = 0;
        }

        return health;
    }
    public virtual int Death(int health)
    {
        LeaderBoard.SetActive(true);
        Cursor.visible = true;
        if (health <= 0)
        {
            Boss.SetActive(false);
        }
        return health;
    }

    void TurnOffFlashAfterDamage()
    {
        //trừ flash xuống 1
        flash = flash - 1;
        // gửi giá trị flash mới lên material có này
        material.SetFloat("_FlashAmount", flash);
    }

    public void CheckIfLessThan50HP()
    {
        if (health <= 300 && state == true)
        {
            BossAnimation.Instance.Enrage();
            state = false;
        }

    }
}
