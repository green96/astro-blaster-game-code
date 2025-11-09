using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSprite : MonoBehaviour
{
    public static BossSprite Instance;

    public Sprite[] phase1Sprite; 
    public Sprite[] phase2Sprite;
    public float frameRate = 0.15f;

    private SpriteRenderer sr;

    private Sprite[] currentAnimation;
    private int currentFrame = 0;
    private float timer;

    private bool isPhase2 = false;
    private bool phase2Finished = false; // để phase 2 chỉ chạy 1 lần

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        currentAnimation = phase1Sprite;   // bắt đầu phase 1
    }

    void Update()
    {
        // Nếu phase 2 đã chạy xong → không làm gì nữa
        if (phase2Finished) return;

        if (currentAnimation == null || currentAnimation.Length == 0) return;

        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer = 0f;

            currentFrame++;

            //  PHASE 1 → LOOP
            if (!isPhase2)
            {
                if (currentFrame >= currentAnimation.Length)
                    currentFrame = 0;
            }
            //  PHASE 2 → PLAY ONE TIME
            else
            {
                if (currentFrame >= currentAnimation.Length)
                {
                    currentFrame = currentAnimation.Length - 1; // giữ frame cuối
                    phase2Finished = true; // dừng animation
                }
            }

            sr.sprite = currentAnimation[currentFrame];
        }
    }

    //  gọi từ HealthBar khi HP <= 50
    public void SwitchToPhase2()
    {
        if (isPhase2) return;

        isPhase2 = true;
        phase2Finished = false;

        currentAnimation = phase2Sprite;
        currentFrame = 0;  // chạy từ frame đầu tiên
        sr.sprite = currentAnimation[currentFrame];
    }
}
