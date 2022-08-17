using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    int[] Inventory = new int[6];
    private GameObject _item;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            _item = null;
            _item = other.GetComponent<GameObject>();
            GetItem(Random.Range(1, 3));

        }
    }

    private void Awake()
    {
        
    }

    void UseItem()
    { 
    
    }

    void GetItem(int ItemNum)
    {
        if (Inventory[5] != 0)
        {
            for (int i = 1; i <= 5; i++)
            {
                if (Inventory[i] == 0)
                {
                    Inventory[i] = ItemNum;
                    Destroy(_item.gameObject);
                    _item = null;
                    break;
                }
            }
        }
        else 
        { 
        
        }



    }


}
