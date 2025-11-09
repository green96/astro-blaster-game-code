using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    private static BossAnimation instance;
    public static BossAnimation Instance {get => instance;}
    [SerializeField] private SkillsController skillsController; // Kéo GameObject Skills vào đây trong Inspector
    [SerializeField] private BossHealthBar bossHealthBar; // Kéo GameObject BossHealBar vào đây trong Inspector
    private Animator animator;
    [SerializeField] private float timeAttack = 0f;


    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        animator = GetComponent<Animator>();


    }

    void Update()
    {
        Attacking();
    }

    protected virtual void Attacking()
    {
        // Tránh lỗi null reference
        if (skillsController == null)
        {
            Debug.LogWarning("SkillsController is null, skipping attack logic.");
            return;
        }

        timeAttack += Time.deltaTime;

        if (timeAttack >= 3f)
        {
            animator.SetBool("isAttacking", true);
            if (timeAttack >= 4f)
            {
                skillsController.gameObject.SetActive(true);

                skillsController.UsingSkills(true);
            }

            // Sau khi đánh xong, đợi thêm 1 giây rồi chuyển về idle
            if (timeAttack >= 4.25f) // 4.25s đợi + 1s đánh + 1s tung chiêu
            {
                animator.SetBool("isAttacking", false);
                skillsController.UsingSkills(false);
                skillsController.gameObject.SetActive(false);
                timeAttack = 0f; // Reset để lặp lại
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }




    }

    public virtual void Enrage()
    
    {
        animator.SetBool("isEnrage",true);      
    }


}
