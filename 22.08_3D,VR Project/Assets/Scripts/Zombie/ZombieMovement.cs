using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    private ZombieMovement _zombie;

    private void Awake()
    {
        _zombie = GetComponent<ZombieMovement>();
    }


}
