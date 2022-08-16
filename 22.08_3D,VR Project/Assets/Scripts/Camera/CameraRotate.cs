using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float _rotateX;
    private float _rotateMoveX;

    private PlayerMovement _player;

    private void Awake()
    {
        _player = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        _rotateMoveX = -Input.GetAxis("Mouse Y") * Time.deltaTime * _player.RotateSpeed;

        _rotateX += _rotateMoveX;

        _rotateX = Mathf.Clamp(_rotateX, -90, 90);
        transform.eulerAngles = new Vector3(_rotateX, transform.eulerAngles.y, 0);
    }
}
