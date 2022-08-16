using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDetected : MonoBehaviour
{
    private PlayerStatus _player;
    private float _distance;

    private void Awake()
    {
        _player = GetComponent<PlayerStatus>();
    }

    void Update()
    {
        _player.MinDistance = 50f;

        Collider[] collisions = Physics.OverlapSphere(transform.position, 50f);
        foreach (Collider coll in collisions)
        {
            if (coll.gameObject.tag == "Zombie")
            { 
                _distance = Vector3.Distance(transform.position, coll.transform.position);
                if (_distance < _player.MinDistance)
                {
                    _player.MinDistance = _distance;
                }
                
            }
        }
    }
}
