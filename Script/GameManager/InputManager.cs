using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance { get => instance; }

    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    private void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 InputManager allow to exist!");
        instance = this;
        this.InvisibleCursor();
    }

    private void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    protected virtual void InvisibleCursor()
    {
        Cursor.visible = false;
    }

}
