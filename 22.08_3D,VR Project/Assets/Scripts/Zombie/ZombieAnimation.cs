using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    private Animator _anim;
    private ZombieStatus _zombie;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _zombie = GetComponentInParent<ZombieStatus>();
    }
    private void Update()
    {
        _anim.SetBool("Walk", _zombie.IsWalk);
        _anim.SetBool("Run", _zombie.IsRun);
    }
}
