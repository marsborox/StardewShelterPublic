using System;

using UnityEngine;

using static HeroTravel;

public enum UnloadBackPackAtHome { NOT, INITIATED, TRAVELING, ARRIVED, MOVINGTOWH, UNLOADING }
public class TasksInBase : MonoBehaviour
{
    public GameObject destinationBuilding;
    UnitMovement unitMovement;
    BackPack backPack;
    UnitAiHeros unitAiHeros;

    float touchDistance = 0.1f;
    public UnloadBackPackAtHome unloadBackPackAtHome;
    HeroTravel heroTravel;
    private void Awake()
    {
        destinationBuilding = GetComponent<GameObject>();
        unitMovement = GetComponent<UnitMovement>();
        backPack = GetComponent<BackPack>();
        unitAiHeros = GetComponent<UnitAiHeros>();
        heroTravel = GetComponent<HeroTravel>();
    }



    void DoWhatWeCameHereFor(Action method, GameObject building)
    {
        unitMovement.Move(destinationBuilding);
        if (Vector2.Distance(this.transform.position, building.transform.position) < touchDistance)
        {
            method();
        }
    }

    public void UnloadBackPackInWarehouse()
    {
        Debug.Log("tasksInBase.Unloading started");
        var warehouse = transform.parent.transform.parent.GetComponentInChildren<WareHouse>();
        Debug.Log(warehouse);


        foreach (Item item in backPack.items)
        { 
            warehouse.AddItemToWareHouse(item);
        }

        
        backPack.items.Clear();
        //
        //
        //
        
        /*
        foreach (Item item in backPack.items)
        {//somewthing wrong here ***********************************
            //this does one item and crashes msut rework to for loop
            Debug.Log("tasksInBase.Unloading Item");
            warehouse.AddItemToWareHouse(item);
            Debug.Log("tasksInBase.Item added to WH");
            backPack.RemoveItemFromBackPack(item);
            Debug.Log("tasksInBase.Item removed from INV");
        }*/
            backPack.backPackFull = false;
            unitAiHeros.performUnload = false;
    }

    
    public void ReturnHomeAndUnloadBackPack()
    {
        switch (unloadBackPackAtHome)
        {
            case UnloadBackPackAtHome.NOT:
                {
                    return;
                }
            case UnloadBackPackAtHome.INITIATED:
                {
                    heroTravel.ReturnHome();
                    heroTravel.arrivedToDestination += AfterArrival;
                    unloadBackPackAtHome = UnloadBackPackAtHome.TRAVELING;

                    return;
                }
            case UnloadBackPackAtHome.TRAVELING:
                {
                    return;
                }
            case UnloadBackPackAtHome.ARRIVED:
                {
                    AfterArrival();
                    return;
                }
            case UnloadBackPackAtHome.MOVINGTOWH:
                {
                    unitMovement.Move(destinationBuilding);
                    if (Vector2.Distance(this.transform.position, destinationBuilding.transform.position) < touchDistance)
                    {
                        unloadBackPackAtHome = UnloadBackPackAtHome.UNLOADING;
                    }
                    return;
                }
            case UnloadBackPackAtHome.UNLOADING:
                {
                    UnloadBackPackInWarehouse();
                    unloadBackPackAtHome = UnloadBackPackAtHome.NOT;
                    return;
                }
        }
    }
    public void AfterArrival()
    {//if we returned home do this
        //Debug.Log("arrived tasksInBase class");

        //find me warehouse need some fix
        destinationBuilding = transform.parent.transform.parent.GetComponentInChildren<WareHouse>().gameObject;
        heroTravel.arrivedToDestination -= AfterArrival;
        unloadBackPackAtHome = UnloadBackPackAtHome.MOVINGTOWH;
        //smthing that would start tasksInBase.UnloadBackPack
    }

}
