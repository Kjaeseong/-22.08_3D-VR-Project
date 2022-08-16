using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float _rotateX;
    public float _rotateY;
    public float RotateSpeed = 200f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        _rotateX += RotateSpeed * mouseY * Time.deltaTime;
        _rotateY += RotateSpeed * mouseX * Time.deltaTime;

        _rotateX = Mathf.Clamp(_rotateX, -80, 80);

        transform.eulerAngles = new Vector3(-_rotateX, _rotateY, 0f);
    }
}
