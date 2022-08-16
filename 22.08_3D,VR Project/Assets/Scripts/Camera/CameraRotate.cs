using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float _rotateX, _rotateY, _rotateMoveX, _rotateMoveY;
    public float RotateSpeed = 200.0f;

    void Update()
    {
        _rotateMoveX = -Input.GetAxis("Mouse Y") * Time.deltaTime * RotateSpeed;
        _rotateMoveY = Input.GetAxis("Mouse X") * Time.deltaTime * RotateSpeed;

        _rotateY = transform.eulerAngles.y + _rotateMoveY;

        _rotateX += _rotateMoveX;

        _rotateX = Mathf.Clamp(_rotateX, -90, 90);

        transform.eulerAngles = new Vector3(_rotateX, _rotateY, 0);
       
    }
}
