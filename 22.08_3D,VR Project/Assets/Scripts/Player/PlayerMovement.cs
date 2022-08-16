using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed;


    private PlayerStatus _player;
    private CameraRotate _camera;

    private void Awake()
    {
        _player = GetComponent<PlayerStatus>();
        _camera = GetComponentInChildren<CameraRotate>();
    }

    private void Update()
    {
        PlayerRunning();
        PlayerMove();
        TurnOnFlash();

    }

    void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 Direction = Vector3.right * h + Vector3.forward * v;

        transform.eulerAngles = new Vector3(0f, _camera._rotateY, 0f);
        transform.position += _moveSpeed * Time.deltaTime * Direction;
    }

    void PlayerRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _player.IsRunning = true;
            _moveSpeed = _player.RunSpeed;
        }
        else 
        {
            _player.IsRunning = false;
            _moveSpeed = _player.WalkSpeed;
        }
    }

    void TurnOnFlash()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _player.FlashOn = _player.FlashOn ? false : true;
        }
    }
}
