using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ZombieDetected : MonoBehaviour
{
    [Range(0, 100)]
    public float DetectedScope = 60f;

    private float _distance;

    private PlayerStatus _player;

    public LayerMask TargetMask;

    private void Awake()
    {
        _player = GetComponent<PlayerStatus>();
    }

    void Update()
    {
        _player.MinDistance = 50f;

        Collider[] ZombieInCollier = Physics.OverlapSphere(transform.position, DetectedScope, TargetMask);

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

    public Vector3 GetAngle(float AngleInDegree)
    {
        return new Vector3(Mathf.Sin(AngleInDegree * Mathf.Deg2Rad), 0, Mathf.Cos(AngleInDegree * Mathf.Deg2Rad));
    }


    private void OnDrawGizmos()
    {
        Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, 360, DetectedScope);
    }

}
