using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareHouse : MonoBehaviour
{
    public List<Item> items = new List<Item>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddItemToWareHouse(Item item)
    { 
        items.Add(item);
    }
    public void RemoveItemToWareHouse(Item item)
    { 
        items.Remove(item);
    }
}
