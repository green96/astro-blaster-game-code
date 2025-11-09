using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectZ : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;

    // Update is called once per frame
    void FixedUpdate()
    {

        //transform.Rotate ==> Xoay liên tục quanh trục X,Y,Z 

        //Xoay liên tục quanh Z
        transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
    }
}
