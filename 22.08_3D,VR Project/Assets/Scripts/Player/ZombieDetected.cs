using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDetected : MonoBehaviour
{
    [Range(0, 100)]
    public float viewArea;

    private float _distance;

    private PlayerStatus _player;

    public LayerMask TargetMask;

    private List<Transform> _targetslist = new List<Transform>();

    private void Awake()
    {
        _player = GetComponent<PlayerStatus>();
    }

    void Update()
    {
        _player.MinDistance = 50f;

        Collider[] ZombieInCollier = Physics.OverlapSphere(transform.position, viewArea, TargetMask);

        foreach (Collider coll in ZombieInCollier)
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
