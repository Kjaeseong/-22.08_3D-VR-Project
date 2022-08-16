using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float _rotateX;
    public float _rotateY;
    public float _rotateMoveX;
    public float _rotateMoveY;
    public float RotateSpeed = 200f;

    void Update()
    {
        _rotateMoveX = -Input.GetAxis("Mouse Y") * Time.deltaTime * RotateSpeed;

        _rotateX += _rotateMoveX;

        _rotateX = Mathf.Clamp(_rotateX, -90, 90);

        transform.eulerAngles = new Vector3(_rotateX, transform.eulerAngles.y, 0);
    }
}
