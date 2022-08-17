using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DetectionScope : MonoBehaviour
{
    private PlayerStatus _target;
    private bool _playerinCollider;
    public bool IsTargetOn { get; private set; }
    public float viewAngle = 90f;

    public bool LockOn;
    private ZombieStatus _zombie;
    private Vector3 _arcStartVector;

    

    private void Awake()
    {
        _zombie = GetComponent<ZombieStatus>();
    }

    private void Start()
    {

        float angle = 150f - transform.eulerAngles.y;
        Debug.Log(angle);
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float z = Mathf.Sin(angle * Mathf.Deg2Rad);

        _arcStartVector = new Vector3(0f, 0f, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _target = null;
            _target = other.GetComponent<PlayerStatus>();
            _playerinCollider = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerinCollider = false;
            _target = null;
        }
    }

    private void Update()
    {
        LockOnPlayer();
        IsTargetOn = LockOn;
        //Debug.Log($"지금 플레이어 위치는 : {_target.transform.position}");
    }

    void LockOnPlayer()
    {
        if (_playerinCollider)
        {
            if (_target.IsRunning == true && _target.IsMoving == true)
            {
                LockOn = true;
            }
            if (LookTarget(_target.transform.position))
            {
                LockOn = true;
                Debug.Log("각도 안에 들어왔다");
            }
            else
            {
                LockOn = false;
            }

        }
        
    }

    private bool LookTarget(Vector3 targetPosition)
    {
        Vector3 distanceVector = targetPosition - transform.position;


         float angle = Vector3.Angle(transform.forward, distanceVector);
         if (0f <= angle && angle <= 60f)
         {
             return true;
         }
         
        float dotResult = Vector3.Dot(transform.forward, distanceVector.normalized);
        if (dotResult < 0.5f || dotResult > 0.5f)
        {
            return false;
        }

        return true;
    }

    private Color _red = new Color(1f, 0f, 0f, 0.1f);
    private Color _blue = new Color(0f, 0f, 1f, 0.1f);
    void OnDrawGizmos()
    {
        Handles.color = IsTargetOn ? _red : _blue;
        Handles.DrawSolidArc(transform.position, transform.up, _arcStartVector, -30f, 20f);
        Handles.DrawSolidArc(transform.position, transform.up, _arcStartVector, 30f, 20f);
    }




}
