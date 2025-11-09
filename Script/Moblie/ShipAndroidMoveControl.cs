using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAndroidMoveControl : MonoBehaviour
{
    private float moveSpeed = 5f; // tốc độ di chuyển
    private bool moveLeft, moveRight;

    void Start()
    {
        moveLeft = false;
        moveRight = false;
    }

    // Các hàm gọi từ button
    public void MoveLeft()
    {
        moveLeft = true;
    }

    public void MoveRight()
    {
        moveRight = true;
    }

    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
    }

    void Update()
    {
        Vector3 pos = transform.parent.position; // lấy vị trí cha hiện tại

        if (moveLeft)
            pos.x -= moveSpeed * Time.deltaTime;

        if (moveRight)
            pos.x += moveSpeed * Time.deltaTime;

        // Giới hạn vùng di chuyển (ví dụ -8 đến 8)
        pos.x = Mathf.Clamp(pos.x, -8f, 8f);

        transform.parent.position = pos; // gán lại vị trí cha mới
    }
}


