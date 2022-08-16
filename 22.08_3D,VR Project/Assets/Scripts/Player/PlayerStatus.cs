using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int Health = 5;
    public float Battery = 100;

    public float WalkSpeed = 4f;
    public float RunSpeed = 10f;
    public bool IsRunning { get; set; }

    public bool FlashOn = false;

    public int HeartBeat = 0;

    public GameObject FlashLight;

    private void Awake()
    {
    }

    private void Update()
    {
        FlashLight.SetActive(FlashOn);
        CostBattery();
    }

    void CostBattery()
    {
        if (FlashOn)
        {
            Battery -= Time.deltaTime * 5f;
        }
    }

}
