using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BossController : MonoBehaviour
{
    [SerializeField] protected GameObject boss;

    [SerializeField] private GameObject DefaultSkillLane1;
    [SerializeField] private GameObject DefaultSkillLane2;
    [SerializeField] private GameObject DefaultSkillLane3;


    [SerializeField] private float spawnTime = 30f; // Thời gian để Boss xuất hiện
    private float occurTime = 0f;
    private float alertTime = 0f;
    private bool hasSpawned = false; // Đảm bảo chỉ spawn 1 lần

    [SerializeField] GameObject alertPanel;
    [SerializeField] TextMeshProUGUI text;
    private int timeCountDown = 5;
    void Start()
    {
        if (boss == null)
        {
            Debug.LogError("Boss GameObject is NULL! Please assign it in Inspector.");
            return;
        }

        boss.SetActive(false);
        alertPanel.SetActive(false);
    }

    void Update()
    {
        if (!hasSpawned) // Chỉ chạy nếu chưa spawn
        {
            OccurAfter30Seconds();
        }
        this.AlertAfter25Seconds();
    }

    protected virtual void OccurAfter30Seconds()
    {
        occurTime += Time.deltaTime;



        if (occurTime >= spawnTime)
        {
            if (boss != null)
            {
                boss.SetActive(true);
                hasSpawned = true;

                //Spawn Skill
                DefaultSkillLane1.SetActive(true);
                Invoke("SkillLane2", 5f);

            }

        }
    }


    protected virtual void AlertAfter25Seconds()
    {
        alertTime += Time.deltaTime;
        if (alertTime >= 25f && alertTime < 30)
        {

            alertPanel.SetActive(true);
            text.color = Color.red;
            timeCountDown = 5 - (int)(alertTime - 25f);
            if (timeCountDown <= 0) timeCountDown = 0;
            text.text = timeCountDown.ToString();







        }
        if (alertTime >= 30f)
        {
            alertPanel.SetActive(false);
        }
    }

    void SkillLane1()
    {
        DefaultSkillLane1.SetActive(true);
        DefaultSkillLane2.SetActive(false);
        DefaultSkillLane3.SetActive(false);
        Invoke("SkillLane2", 5f);
    }

    void SkillLane2()
    {
        DefaultSkillLane1.SetActive(false);
        DefaultSkillLane2.SetActive(true);
        DefaultSkillLane3.SetActive(false);
        Invoke("SkillLane3", 5f);
    }

    void SkillLane3()
    {
        DefaultSkillLane1.SetActive(false);
        DefaultSkillLane2.SetActive(false);
        DefaultSkillLane3.SetActive(true);
        Invoke("SkillLane1", 5f);
    }
}
