using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStatus : MonoBehaviour
{
    public float WalkSpeed = 1f;
    public float RunSpeed = 6f;

    public float AttackCoolTime = 1.5f;

    public bool CanAttack;

    public bool IsRun;
    public bool IsWalk;



    private void Awake()
    {
    }

    private void Update()
    {
        
    }


}
