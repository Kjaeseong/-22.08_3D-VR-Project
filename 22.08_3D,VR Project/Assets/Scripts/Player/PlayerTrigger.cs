using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Zombie")
        {
            
            Debug.Log($"{other}적 감지");
        }
    }

    private void Update()
    {
        
    }
}
