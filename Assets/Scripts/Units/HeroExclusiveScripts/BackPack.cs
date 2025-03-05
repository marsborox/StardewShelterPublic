using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackPack : MonoBehaviour
{
    public bool backPackFull;
    public int _backPackCap;
    public int _itemsInBackPack;
    public List<Item> items = new List<Item>();

    HeroStatsAndInfo heroStatsAndInfo;
    TasksInBase tasksInBase;
    


    

    private void Awake()
    {
        heroStatsAndInfo = GetComponent<HeroStatsAndInfo>();
    }
    private void Start()
    {
        CalcBackPackSize();
    }

    public void CalcBackPackSize()
    {
        _backPackCap = heroStatsAndInfo.backPackSize;
    }
    public void AddItemToBackPack(Item item,int ammount)
    {
        for (int i = ammount; i == 0; i--)
        {
            AddItemToBackPack(item);
        }
    }
    public void AddItemToBackPack(Item item)
    {
        if (!backPackFull)
        {
            //Debug.Log("Adding item");
            _itemsInBackPack++;
            //Debug.Log("Adding Item");
            items.Add(item);
            //Debug.Log("Checking Fullness of inventory");
            if ((_itemsInBackPack >= _backPackCap))
            {
                //Debug.Log("BackPack full");
                backPackFull = true;
            }
            
        }
        //add weight
    }

    public void RemoveItemFromBackPack(Item item)
    {
        if (_itemsInBackPack > 0)
        {
            _itemsInBackPack--;
            items.Remove(item);
            backPackFull = false;
        }
        //remove weight
    }
    public void InventoryFull()
    { 
        
        //move to camp
        //do travel back method
        //unload inventory
        //be idle
    }


   
}
