using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int Health = 5;
    public int Battery = 100;

    public float WalkSpeed = 4f;
    public float RunSpeed = 10f;
    public bool IsRunning { get; set; }

    public bool FlashOn = false;
}
