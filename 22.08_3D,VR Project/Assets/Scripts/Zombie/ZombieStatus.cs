using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStatus : MonoBehaviour
{
    public float WalkSpeed;
    public float RunSpeed;

    public float AttackCoolTime = 1.5f;

    private DetectionScope _scope;

    private void Awake()
    {
        _scope = GetComponentInChildren<DetectionScope>();
    }




}
