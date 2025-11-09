using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected bool isShooting = false;
    private Rigidbody2D rb;
    [SerializeField] protected float bulletSpeed = 1f;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float fireInterval = 1f;


    private void Start()
    {
        InvokeRepeating("Shooting", 1f, fireInterval);
    }
    protected virtual void Shooting()
    {
        if (!isShooting) return;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * bulletSpeed;

        Destroy(bullet, 1.6f);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Boss"))
        {
            BossHealthBar.Instance.DecreaseHealth(10);
            Destroy(gameObject); // 💥 Hủy viên đạn ngay khi chạm Boss
        }

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject); // 💥 Hủy viên đạn ngay khi chạm Thiên thạch
        }

        if (collision.gameObject.CompareTag("Planet"))
        {
            Destroy(gameObject); // 💥 Hủy viên đạn ngay khi chạm Hanh Tinh
        }
    }
}
