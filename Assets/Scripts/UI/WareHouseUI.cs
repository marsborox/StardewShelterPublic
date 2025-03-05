using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareHouseUI : BackPackUI
{
    [SerializeField] WareHouse wareHouse;

    private void Awake()
    {
        
    }
    private void Start()
    {
        //numberOfSlotsToSpawn=wareHouse.items.Count;
    }
    void Update()
    {
        SpawnSlots();
    }
    void SpawnSlots()
    {
        numberOfSlotsToSpawn = wareHouse.items.Count;
        //Debug.Log("WareHouseUI list count= "+ wareHouse.items.Count);
        SlotSpawning(wareHouse.items);
    }

}
