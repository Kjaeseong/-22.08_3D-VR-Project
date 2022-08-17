using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mannequin : MonoBehaviour
{
    public int Health = 7;

    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Damage()
    { 
        
    }


}
