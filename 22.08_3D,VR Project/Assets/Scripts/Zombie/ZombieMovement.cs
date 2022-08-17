using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    private DetectionTarget _detection;
    private ZombieStatus _zombie;

    public bool IsRunning;
    private float _moveSpeed;

    public bool LockOn;

    private void Awake()
    {
        _detection = GetComponent<DetectionTarget>();
        _zombie = GetComponent<ZombieStatus>();
    }

    private void Update()
    {
        if (_detection.TargetTransform != null)
        {
            
            _moveSpeed = _zombie.RunSpeed;
            LockOn = true;
            RunToTarget();
        }
        else
        {
            _moveSpeed = _zombie.WalkSpeed;
            LockOn = false;
        }
    }

    void RunToTarget()
    {
        IsRunning = true;
        transform.LookAt(_detection.TargetTransform);
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward.normalized);
        



    }

}
