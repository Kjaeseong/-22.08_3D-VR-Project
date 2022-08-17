using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DetectionTarget : MonoBehaviour
{
    [Range(0, 100)]
    public float viewArea = 40f;
    [Range(0, 360)]
    public float viewAngle = 90f;

    public LayerMask targetMask;

    private float _minDistance;
    public Transform TargetTransform;
    private PlayerStatus _player;

    [HideInInspector]
    public List<Transform> Targets = new List<Transform>();

    void Update()
    {
        GetTarget();
    }

    public void GetTarget()
    {
        TargetTransform = null;
        _player = null;
        _minDistance = viewArea;
        Targets.Clear();

        Collider[] TargetCollider = Physics.OverlapSphere(transform.position, viewArea, targetMask);
        Transform target;
        float distance;

        for (int i = 0; i < TargetCollider.Length; i++)
        {
            target = TargetCollider[i].transform;
            Vector3 direction = target.position - transform.position;

            if (Vector3.Dot(direction.normalized, transform.forward) > GetAngle(viewAngle / 2).z)
            {

                Targets.Add(target);
                distance = Vector3.Distance(transform.position, target.position);
                if (distance < _minDistance)
                {
                    _minDistance = distance;
                    TargetTransform = target;
                }
            }
            if (TargetTransform == null)
            {
                if (target.name == "Mannequin")
                {
                    TargetTransform = target;
                }
                else if (target.name == "Player")
                {
                    _player = target.GetComponent<PlayerStatus>();
                    if (_player.IsMoving == true && _player.IsRunning == true)
                    {
                        TargetTransform = target;
                    }
                }
            }
        }
        if (TargetTransform != null)
        {
            
        }
    }

    public Vector3 GetAngle(float AngleInDegree)
    {
        return new Vector3(Mathf.Sin(AngleInDegree * Mathf.Deg2Rad), 0, Mathf.Cos(AngleInDegree * Mathf.Deg2Rad));
    }

    private void OnDrawGizmos()
    {
        Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, 360, viewArea);
        //Handles.DrawLine(transform.position, transform.position + GetAngle(-viewAngle / 2) * viewArea);
        //Handles.DrawLine(transform.position, transform.position + GetAngle(viewAngle / 2) * viewArea);

        foreach (Transform Target in Targets)
        {
            Handles.DrawLine(transform.position, Target.position);
        }
    }
}