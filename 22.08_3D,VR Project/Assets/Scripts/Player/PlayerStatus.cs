using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int Health = 5;
    public float Battery = 100;

    public float WalkSpeed = 4f;
    public float RunSpeed = 10f;

    public float MinDistance;
    public int IsScary = 0;

    public bool IsRunning;
    public bool IsMoving;

    public bool FlashOn = false;

    public GameObject FlashLight;


    private void Update()
    {
        FlashLight.SetActive(FlashOn);
        CostBattery();
        Scary();
        /*
        무서움 수치 테스트 코드
        if (IsScary != 0)
        {
            Debug.Log($"무서움 수치{IsScary} / 적과의 거리 {MinDistance}");
        }
        */
    }

    void CostBattery()
    {
        if (FlashOn)
        {
            Battery -= Time.deltaTime;
        }
    }

    void Scary()
    {
        if (MinDistance <= 15)
            IsScary = 5;
        else if (MinDistance <= 20)
            IsScary = 4;
        else if (MinDistance <= 30)
            IsScary = 3;
        else if (MinDistance <= 40)
            IsScary = 2;
        else if (MinDistance <= 49)
            IsScary = 1;
        else
            IsScary = 0;
    }

}
