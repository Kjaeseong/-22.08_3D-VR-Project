using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float RotateMoveY;
    public float RotateY;
    public float RotateSpeed = 200f;

    private float _moveSpeed;

    private PlayerStatus _player;

    private void Awake()
    {
        _player = GetComponent<PlayerStatus>();
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

        if (h != 0 || v != 0)
            _player.IsMoving = true;
        else
            _player.IsMoving = false;
        
        Vector3 Direction = Vector3.right * h + Vector3.forward * v;
        transform.Translate(Direction.normalized * Time.deltaTime * _moveSpeed, Space.Self);

        RotateMoveY = Input.GetAxis("Mouse X") * Time.deltaTime * RotateSpeed;
        RotateY = transform.eulerAngles.y + RotateMoveY;
        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, RotateY, 0);
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
        if (_player.Battery >= 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _player.FlashOn = _player.FlashOn ? false : true;
            }
        }
        else 
        {
            _player.FlashOn = false;
        }
    }
}
