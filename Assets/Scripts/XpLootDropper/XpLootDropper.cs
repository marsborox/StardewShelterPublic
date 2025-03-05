using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpLootDropper : MonoBehaviour
{
    private void OnWillRenderObject()
    {
        //will use this later
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    //some method that dying characters runs passes attacker in input and it receives some loot and xp
    //because it can be calculated
    public void XpLootDrop(GameObject attacker, Item item)
    {
        attacker.GetComponent<BackPack>().AddItemToBackPack(item);
    
    }
}
